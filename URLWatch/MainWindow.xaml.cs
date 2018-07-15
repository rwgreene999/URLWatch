using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls; 



namespace URLWatch
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private Options options = new Options();
        public MainWindow()
        {
            InitializeComponent();
            options = new Options()
            {
                Uri = Properties.Settings.Default.Uri.ToString(),
                msReAccess = ((Properties.Settings.Default.retrySeconds.ToString().TryParse(120)) * 1000),
                Started = DateTime.Now
            };

            OptionsFormManagement.ToFormAllData(this, options);

            AccessUri access = new AccessUri();
            Task.Run(() => access.Get(options));

            // todo: switch to backgroundworker or full MVVM 
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += (s, e) => { OptionsFormManagement.ToFormInternalUpdatedData(this, options); };
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
        }

        private void btnUpdateSettings_Click(object sender, RoutedEventArgs e)
        {
            OptionsFormManagement.FromForm(this, options);
            Properties.Settings.Default.Uri = options.Uri;
            Properties.Settings.Default.retrySeconds = (options.msReAccess / 1000);
            Properties.Settings.Default.Save();
            OptionsFormManagement.ToFormAllData(this, options);
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            options.Paused = true;
            btnPause.IsEnabled = false;
            btnResume.IsEnabled = true; 
        }

        private void btnResume_Click(object sender, RoutedEventArgs e)
        {
            options.Paused = false;
            btnPause.IsEnabled = true;
            btnResume.IsEnabled = false;

        }

        private void btnViewChart_Click(object sender, RoutedEventArgs e)
        {
            Chart c = new Chart();
            c.Go(options); 
            c.Show(); 
        }
    }
}
