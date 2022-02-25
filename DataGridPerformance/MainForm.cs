using System.ComponentModel;

namespace DataGridPerformance;

public partial class MainForm : Form
{
    private CancellationTokenSource? _simulationCts;


    public BindingList<��������> ������ { get; } = new BindingList<��������>()
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
        itemsGridView.DataSource = ������;

        ������.ListChanged += async (s, e) =>
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

        startSimulationButton.Text = "����";

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
                        var ����index = Random.Shared.Next(0, ������.Count);
                        var ���� = ������[����index];
                        var cmd = Random.Shared.Next(0, 6);
                        // �ż�ȣ�� ����
                        if (cmd is 0 or 1)
                        {
                            ����.�ż�ȣ�� += cmd is 0 ? +5 : -5; ;
                            ����.FireProeprtChanged(nameof(��������.�ż�ȣ��));
                        }
                        // �ŵ�ȣ�� ����
                        else if (cmd is 2 or 3)
                        {
                            ����.�ŵ�ȣ�� += cmd is 2 ? +5 : -5;
                            ����.FireProeprtChanged(nameof(��������.�ŵ�ȣ��));
                        }
                        // �ż� ü��
                        else if (cmd is 4)
                        {
                            ����.���簡 = ����.�ŵ�ȣ��;
                            ����.ü��Ǽ�++;
                            ����.FireProeprtChanged(nameof(��������.���簡));
                            ����.FireProeprtChanged(nameof(��������.ü��Ǽ�));
                        }
                        // �ŵ� ü��
                        else if (cmd is 5)
                        {
                            ����.���簡 = ����.�ż�ȣ��;
                            ����.ü��Ǽ�++;
                            ����.FireProeprtChanged(nameof(��������.���簡));
                            ����.FireProeprtChanged(nameof(��������.ü��Ǽ�));
                        }
                    }

                    await Task.Delay(interval, _simulationCts.Token);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }, _simulationCts.Token);
        startSimulationButton.Text = "����";
    }
}

public class �������� : INotifyPropertyChanged
{
    public int ���� { get; }
    public string ���� { get; }
    public decimal ���簡 { get; set; }
    public int ü��Ǽ� { get; set; }
    public decimal �ż�ȣ�� { get; set; }
    public decimal �ŵ�ȣ�� { get; set; }

    public ��������(int ����, string ����, decimal ���簡, int ü��Ǽ�, decimal �ż�ȣ��, decimal �ŵ�ȣ��)
    {
        this.���� = ����;
        this.���� = ����;
        this.���簡 = ���簡;
        this.ü��Ǽ� = ü��Ǽ�;
        this.�ż�ȣ�� = �ż�ȣ��;
        this.�ŵ�ȣ�� = �ŵ�ȣ��;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void FireProeprtChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
