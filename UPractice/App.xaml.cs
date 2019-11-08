using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UPractice.View;
using UPractice.ViewModel;

namespace UPractice
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mw = new UPractice.View.MainWindow
            {
               DataContext = new MainWindowVM()

            };
            mw.Show();
        }
    }
}
