namespace WinFormsTabBackground;

public class TransparentTabControl : TabControl
{
    public new Color BackColor { get; set; } = Color.Red;

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        //base.OnDrawItem(e);
        //e.Graphics.Clear(BackColor);
    }
}
