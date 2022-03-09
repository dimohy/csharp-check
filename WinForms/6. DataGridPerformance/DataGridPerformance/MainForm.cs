using System.ComponentModel;

namespace DataGridPerformance;

public partial class MainForm : Form
{
    private CancellationTokenSource? _simulationCts;


    public BindingList<종목정보> 종목목록 { get; } = new BindingList<종목정보>()
    {
        new(1, "A", 500, 0, 450, 550),
        new(2, "B", 500, 0, 450, 550),
        new(3, "C", 500, 0, 450, 550),
        new(4, "D", 500, 0, 450, 550),
        new(5, "E", 500, 0, 450, 550),
        new(6, "F", 500, 0, 450, 550),
        new(7, "G", 500, 0, 450, 550),
        new(8, "H", 500, 0, 450, 550),
        new(9, "I", 500, 0, 450, 550),
        new(10, "J", 500, 0, 450, 550),
    };

    public MainForm()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);


        itemsGridView.AutoGenerateColumns = true;
        itemsGridView.DataSource = 종목목록;

        종목목록.ListChanged += async (s, e) =>
        {
            if (e.ListChangedType is ListChangedType.ItemChanged)
            {
                var propertyName = e.PropertyDescriptor!.Name;

                var rowIndex = -1;
                int columnIndex;
                for (columnIndex = 0; columnIndex < itemsGridView.Columns.Count; columnIndex++)
                {
                    var column = itemsGridView.Columns[columnIndex];
                    if (column.DataPropertyName == propertyName)
                    {
                        rowIndex = e.NewIndex;
                        break;
                    }
                }

                itemsGridView.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.Red;
                await Task.Delay(100);
                itemsGridView.Rows[rowIndex].Cells[columnIndex].Style.BackColor = default;
            };
        };
    }

    private async void startSimulationButton_Click(object sender, EventArgs e)
    {
        if (_simulationCts is not null && _simulationCts?.IsCancellationRequested is false)
        {
            _simulationCts?.Cancel();
            return;
        }

        startSimulationButton.Text = "중지";

        var interval = (int)intervalNumberic.Value;
        var callCount = (int)callCountNumeric.Value;

        _simulationCts = new CancellationTokenSource();
        await Task.Run(async () =>
        {
            try
            {
                while (_simulationCts.Token.IsCancellationRequested is false)
                {
                    for (var i = 0; i < callCount; i++)
                    {
                        var 종목index = Random.Shared.Next(0, 종목목록.Count);
                        var 종목 = 종목목록[종목index];
                        var cmd = Random.Shared.Next(0, 6);
                        // 매수호가 변경
                        if (cmd is 0 or 1)
                        {
                            종목.매수호가 += cmd is 0 ? +5 : -5; ;
                            종목.FireProeprtChanged(nameof(종목정보.매수호가));
                        }
                        // 매도호가 변경
                        else if (cmd is 2 or 3)
                        {
                            종목.매도호가 += cmd is 2 ? +5 : -5;
                            종목.FireProeprtChanged(nameof(종목정보.매도호가));
                        }
                        // 매수 체결
                        else if (cmd is 4)
                        {
                            종목.현재가 = 종목.매도호가;
                            종목.체결건수++;
                            종목.FireProeprtChanged(nameof(종목정보.현재가));
                            종목.FireProeprtChanged(nameof(종목정보.체결건수));
                        }
                        // 매도 체결
                        else if (cmd is 5)
                        {
                            종목.현재가 = 종목.매수호가;
                            종목.체결건수++;
                            종목.FireProeprtChanged(nameof(종목정보.현재가));
                            종목.FireProeprtChanged(nameof(종목정보.체결건수));
                        }
                    }

                    await Task.Delay(interval, _simulationCts.Token);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }, _simulationCts.Token);
        startSimulationButton.Text = "시작";
    }
}

public class 종목정보 : INotifyPropertyChanged
{
    public int 순번 { get; }
    public string 종목 { get; }
    public decimal 현재가 { get; set; }
    public int 체결건수 { get; set; }
    public decimal 매수호가 { get; set; }
    public decimal 매도호가 { get; set; }

    public 종목정보(int 순번, string 종목, decimal 현재가, int 체결건수, decimal 매수호가, decimal 매도호가)
    {
        this.순번 = 순번;
        this.종목 = 종목;
        this.현재가 = 현재가;
        this.체결건수 = 체결건수;
        this.매수호가 = 매수호가;
        this.매도호가 = 매도호가;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void FireProeprtChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
