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
using System.Windows.Shapes;

using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace URLWatch
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    partial class Chart : Window
    {
        public Chart()
        {
            InitializeComponent();

        }

        public Func<double, string> Formatter { get; set; }
        public SeriesCollection Series { get; set; }
        public void Go(Options o)
        {

            var responseConfig = Mappers.Xy<AccessResponse>()
                            .X(ar => (double)ar.Accessed.Ticks / TimeSpan.FromHours(1).Ticks)
                            .Y(ar => ar.msResponseTime);


            // todo: Find a better way to connect my data with the Series
            // see https://lvcharts.net/App/examples/v1/wpf/Date%20Time 
            ChartValues<AccessResponse> ls3CV = new ChartValues<AccessResponse>();
            foreach (var v in o.AccessResponses)
            {
                ls3CV.Add(v);
            }
            LineSeries ls3 = new LineSeries
            {
                Values = ls3CV,
                Fill = Brushes.Transparent
            };

            Series = new SeriesCollection(responseConfig)
            {
                ls3
            };

            Formatter = value => new System.DateTime((long)(value * TimeSpan.FromHours(1).Ticks)).ToString("t");

            DataContext = this;
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
