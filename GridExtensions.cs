using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace JSONViewer.NET
{
    public static class GridExtensions
    {
        public static Border CreateBorder(this Grid grid, int columnIndex, int rowIndex)
        {
            var border = new Border();
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.BorderThickness = new Microsoft.UI.Xaml.Thickness(1);
            border.SetValue(Grid.ColumnProperty, columnIndex);
            border.SetValue(Grid.RowProperty, rowIndex);
            border.Padding = new Microsoft.UI.Xaml.Thickness(5);

            grid.Children.Add(border);
            return border;
        }
    }
}
