using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLWatch
{
    static class OptionsFormManagement
    {

        internal static void ToFormAllData(MainWindow mainWindow, Options o)
        {
            ToFormUserChangableData(mainWindow, o);
            ToFormInternalUpdatedData(mainWindow, o);
        }
        internal static void ToFormInternalUpdatedData(MainWindow mainWindow, Options o)
        {
            mainWindow.txtAverageResponse.Text = o.msAvgResponseTime.ToString();
            mainWindow.txtContactAttempts.Text = o.cntAccess.ToString();
            mainWindow.txtFailures.Text = o.cntFailures.ToString();
            mainWindow.txtStarted.Text = o.Started.ToString();
        }
        internal static void ToFormUserChangableData(MainWindow mainWindow, Options o)
        {
            mainWindow.txtSeconds.Text = (o.msReAccess / 1000).ToString();
            mainWindow.txtURI.Text = o.Uri;
        }


        internal static void FromForm(MainWindow mainWindow, Options o)
        {
            o.msReAccess = (mainWindow.txtSeconds.Text.TryParse(60000)) * 1000;
            o.Uri = mainWindow.txtURI.Text;
        }
    }
}
