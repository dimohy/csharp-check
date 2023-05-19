using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WpfTreeView;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private static readonly string xml = """
            <?xml version="1.0" encoding="UTF-8"?>
            <root>
                <group name="Group1">
                    <process name="Process1">
                        <item name="item1"/>
                        <item name="item2"/>
                        <item name="item3"/>
                    </process>

                    <process name="Process2">
                        <item name="item1"/>
                        <item name="item2"/>
                        <item name="item3"/>
                    </process>        
                </group>

                <group name="Group2">
                    <process name="Process2">
                        <item name="item1"/>
                        <item name="item2"/>
                    </process>

                    <!--group 안에 group 중첩-->
                    <group name="Group2_1">
                        <process name="Process2">
                            <item name="item1"/>
                            <item name="item2"/>
                        </process>

                        <!--group 안에 또 group안에 group 중첩-->
                        <group name="Group2_1_1">
                            <process name="Process2">
                                <item name="item1"/>
                                <item name="item2"/>
                            </process>
                        </group>
                    </group>
                </group>

                <group name="Group3">
                    <process name="Process2">
                        <item name="item1"/>
                        <item name="item2"/>
                    </process>

                    <!--group 안에 group 중첩-->
                    <group name="Group3_1">
                        <process name="Process2">
                            <item name="item1"/>
                            <item name="item2"/>
                        </process>
                    </group>
                </group>
            </root>
            """;

    public Root Root { get; }

    public MainWindow()
    {
        InitializeComponent();

        var xmlSerializer = new XmlSerializer(typeof(Root));
        var data = Encoding.UTF8.GetBytes(xml);
        using var stream = new MemoryStream(data);
        Root = (Root)xmlSerializer.Deserialize(stream)!;

        DataContext = this;
    }
}

[Serializable, XmlType("root")]
public class Root
{
    [XmlElement("group")]
    public List<Group>? Groups { get; set; }
}

[Serializable, XmlType("group")]
public class Group
{
    [XmlAttribute("name")]
    public string? Name { get; set; }

    [XmlElement("process")]
    public List<Process>? Processes { get; set; }

    /// <summary>
    /// 중첩 그룹
    /// </summary>
    [XmlElement("group")]
    public List<Group>? NestedGroup { get; set; }

    public CompositeCollection Children
    {
        get
        {
            return new CompositeCollection()
            {
                new CollectionContainer() { Collection = Processes },
                new CollectionContainer() { Collection = NestedGroup }
            };
        }
    }
}

[Serializable, XmlType("process")]
public class Process
{
    [XmlAttribute("name")]
    public string? Name { get; set; }

    [XmlElement("item")]
    public List<Item>? Items { get; set; }
}

[Serializable, XmlType("item")]
public class Item
{
    [XmlAttribute("name")]
    public string? Name { get; set; }
}