using Gma.System.MouseKeyHook;

using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace WinFormsMouseCapture;


public class ColorPickerControl : Control
{
    private Image? _capturedScreen;

    public event EventHandler? CursorColorChanged;
    
    public bool IsCapturing { get; private set; }
    public Color CursorColor { get; private set; }

    /// <summary>
    /// 마우스 커서 영역 캡쳐 시작
    /// </summary>
    public void Start()
    {
        if (IsCapturing is true)
            return;

        GlobalMouse.CaptureMouse(ColorPickerControl_GlobalMouseCallback);

        IsCapturing = true;
    }

    /// <summary>
    /// 캡쳐 중지
    /// </summary>
    public void Stop()
    {
        if (IsCapturing is false)
            return;

        IsCapturing = false;

        GlobalMouse.ReleaseMouse(ColorPickerControl_GlobalMouseCallback);
    }

    private void ColorPickerControl_GlobalMouseCallback(object? sender, MouseEventExtArgs e)
    {
        CaptureMousePositionScreen(e.Location);

        // 클릭하면 캡쳐 종료
        if (e.Clicks > 0)
        {
            e.Handled = true;
            Stop();
            return;
        }
    }

    private void CaptureMousePositionScreen(Point p)
    {
        //var cp = PointToClient(p);
        //Debug.WriteLine(cp);
        //if (cp.X >= 0 && cp.Y >= 0 && cp.X < Width && cp.Y < Height)
        //    return;

        var size = GetActualRect().Size / 4;
        p = new Point(p.X - size.Width / 2, p.Y - size.Height / 2);

        using var g = CreateGraphics();
        var newScreen = new Bitmap(size.Width, size.Height, g);
        using var mg = Graphics.FromImage(newScreen);
        mg.CopyFromScreen(p, Point.Empty, size);

        var oldCapturedScreen = _capturedScreen;
        _capturedScreen = newScreen;
        if (oldCapturedScreen is not null)
            oldCapturedScreen.Dispose();

        CursorColor = newScreen.GetPixel(size.Width / 2, size.Height / 2);
        CursorColorChanged?.Invoke(this, EventArgs.Empty);

        Invalidate();
    }

    /// <summary>
    /// 배경은 그리지 않음
    /// </summary>
    /// <param name="pevent"></param>
    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
    }

    /// <summary>
    /// 캡쳐한 이미지가 있을 경우 표시. 없으면 배경색으로 배경 그림
    /// </summary>
    /// <param name="e"></param>
    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        var rect = GetActualRect();

        g.InterpolationMode = InterpolationMode.NearestNeighbor;

        // 외곽
        g.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);

        if (_capturedScreen is not null)
            g.DrawImage(_capturedScreen, rect);
        else
        {
            using var brush = new SolidBrush(BackColor);
            g.FillRectangle(brush, rect);
        }

        // 크로스
        var mx = rect.Width / 2 + 1;
        var my = rect.Height / 2 + 1;
        g.DrawLine(Pens.Red, mx, 1, mx, rect.Height);
        g.DrawLine(Pens.Red, 1, my, rect.Width, my);
    }

    private Rectangle GetActualRect() => new(1, 1, Width - 2, Height - 2);
}
