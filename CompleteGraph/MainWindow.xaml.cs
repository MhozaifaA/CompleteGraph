using System;
using System.Collections.Generic;
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

namespace CompleteGraph
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            new Action(async () => await InitGrapgh((int)SliderNodes.Value))();
        }

        private async Task InitGrapgh(int n)
        {
            for (int i = 0; i <= n - 1; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    Dispatcher.Invoke(()=> {
                        LineGraph.Points.Add(lOt(i, n));
                        LineGraph.Points.Add(lOt(j, n));

                    });

                    await Task.Delay(10);
                }
            }

            ButtonExecute.IsEnabled = true;
        }

        private Point lOt(int i, int n)
        {
            double t = (float)i % n / n * 2.0 * System.Math.PI;
            return new Point((1.0 + Math.Sin(t)), (1.0 + Math.Cos(t)));
        }

        private async void ButtonExecute_Click(object sender, RoutedEventArgs e)
        {
            ButtonExecute.IsEnabled = false;
            LineGraph.Points.Clear();

           // LineGraph.Stroke=(ComboColor.SelectedItem as Rectangle).Fill;

            await InitGrapgh((int)SliderNodes.Value);
        }

        private void ComboColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                switch (ComboColor.SelectedIndex)
                {
                    case 0:
                        LineGraph.Stroke = Brushes.Orange;
                        break;
                    case 1:
                        LineGraph.Stroke = Brushes.DarkKhaki;
                        break;
                    case 2:
                        LineGraph.Stroke = Brushes.CadetBlue;
                        break;
                    case 3:
                        LineGraph.Stroke = Brushes.GreenYellow;
                        break;
                    case 4:
                        LineGraph.Stroke = Brushes.Black;
                        break;
                    case 5:
                        LineGraph.Stroke = Brushes.Red;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
