using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace JSONViewer.NET
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// no Frame?.jpg
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            using (JsonDocument document = JsonDocument.Parse(input.Text))
            {
                var root = document.RootElement;
                render(output, root);
            }
        }

        private void render(Panel destination, JsonElement node)
        {
            switch (node.ValueKind)
            {
                case JsonValueKind.Undefined:
                    break;
                case JsonValueKind.Object:
                    var objectGrid = new Grid();
                    //{
                    //    Style = (Style)Application.Current.Resources["ObjectGrid"]
                    //};
                    objectGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    objectGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    var i = 0;
                    foreach(var pair in node.EnumerateObject())
                    {
                        objectGrid.RowDefinitions.Add(new RowDefinition());
                        objectGrid.RowDefinitions.Add(new RowDefinition());

                        var nameBorder = objectGrid.CreateBorder(0, i);
                        var valueBorder = objectGrid.CreateBorder(1, i);

                        var nameText = new TextBlock
                        {
                            Text = pair.Name
                        };
                        nameBorder.Child = nameText;

                        var value = new StackPanel();
                        value.Orientation = Orientation.Vertical;
                        value.HorizontalAlignment = HorizontalAlignment.Stretch;
                        value.VerticalAlignment = VerticalAlignment.Top;

                        valueBorder.Child = value;

                        render(value, pair.Value);

                        i++;
                    }

                    destination.Children.Add(objectGrid);
                    break;
                case JsonValueKind.Array:
                    break;
                case JsonValueKind.String:
                    var stringOutput = new TextBlock
                    {
                        Text = node.GetString()
                    };
                    destination.Children.Add(stringOutput);

                    break;
                case JsonValueKind.Number:
                    var numberOutput = new TextBlock
                    {
                        Text = node.ToString()
                    };
                    destination.Children.Add(numberOutput);
                    break;
                case JsonValueKind.True:
                    break;
                case JsonValueKind.False:
                    break;
                case JsonValueKind.Null:
                    break;
                default:
                    break;
            }
        }
    }
}
