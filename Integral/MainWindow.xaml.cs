using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Integral
{
    public partial class MainWindow : Window
    {
        private List<double> x1 = new List<double>();
        private List<double> y1 = new List<double>();
        private List<double> x2 = new List<double>();
        private List<double> y2 = new List<double>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoCalculate();
        }

        private void DoCalculate()
        {
            Stopwatch sw = new Stopwatch();
            Integrlar_score _Score = new Integrlar_score(Convert.ToDouble(tblower.Text), Convert.ToDouble(tbupper.Text), Convert.ToDouble(tbCount.Text));
            sw.Start();
            tbanswer.Text = Convert.ToString(_Score.Score(cbmetod.SelectedIndex, false));
            sw.Stop();
            tbtime.Text = Convert.ToString(sw.ElapsedMilliseconds);
            if (cbmetod.Text == "Метод среднего прямоугольника")
            {
                x1.Add(Convert.ToDouble(tbtime.Text));
                y1.Add(Convert.ToDouble(tbCount.Text));
            }
            else
            {
                x2.Add(Convert.ToDouble(tbtime.Text));
                y2.Add(Convert.ToDouble(tbCount.Text));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Drow();
        }
        private void Drow()
        {
            Chart.Plot.Clear();
            Chart.Plot.YLabel("Количество разбиений");
            Chart.Plot.XLabel("Время");
            double[] dx1 = x1.ToArray();
            double[] dy1 = y1.ToArray();
            double[] dx2 = x2.ToArray();
            double[] dy2 = y2.ToArray();
            if (dx1.Length > 1 && dy1.Length > 1)
                Chart.Plot.AddScatter(dx1, dy1);
            if (dx2.Length > 1 && dy2.Length > 1)
                Chart.Plot.AddScatter(dx2, dy2);
            Chart.Refresh();
        }
    }
}
