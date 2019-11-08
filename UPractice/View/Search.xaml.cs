using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UPractice.Dbcontext;

namespace UPractice.View
{
    /// <summary>
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        private string[] tchFields = { "FirstName", "SecondName", "LastName", "Phone", "Email" };
        private string[] fclFields = { "NameFaculty", "ShortNameFaculty"};
        private string[] chrFields = { "NameChair", "ShortNameChair"};
        public Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new MyDbcontext())
            {
                try
                {
                    if (cbFromTable.SelectedIndex == 0)
                    {
                        Teacher tch = new Teacher();
                        switch (cbFromColumn.SelectedIndex)
                        {
                            
                            case 0: tch = (from i in db.Teachers where i.FirstName == tbSearchQuery.Text select i).First(); break;
                            case 1: tch = (from i in db.Teachers where i.SecondName == tbSearchQuery.Text select i).First(); break;
                            case 2: tch = (from i in db.Teachers where i.LastName == tbSearchQuery.Text select i).First(); break;
                            case 3: tch = (from i in db.Teachers where i.Phone == Convert.ToInt32(tbSearchQuery.Text) select i).First(); break;
                            case 4: tch = (from i in db.Teachers where i.Email == tbSearchQuery.Text select i).First(); break;
                        }
                        tblResult.Text += tch + "\n";
                    }
                    else if (cbFromTable.SelectedIndex == 1)
                    {
                        Faculty fcl = new Faculty();
                        switch (cbFromColumn.SelectedIndex)
                        {
                            case 0:
                                fcl = (from i in db.Faculties where i.NameFaculty == tbSearchQuery.Text select i).First(); break;
                            case 1:
                                fcl = (from i in db.Faculties where i.ShortNameFaculty == tbSearchQuery.Text select i).First(); break;
                        }
                        tblResult.Text += fcl + "\n";
                    }
                    else if (cbFromTable.SelectedIndex == 2)
                    {
                        Chair chr = new Chair();
                        switch (cbFromColumn.SelectedIndex)
                        {
                            case 0:
                                chr = (from i in db.Chairs where i.NameChair == tbSearchQuery.Text select i).First(); break;
                            case 1:              
                               chr = (from i in db.Chairs where i.ShortNameChair == tbSearchQuery.Text select i).First(); break;                     
                        }
                        tblResult.Text +=chr + "\n";
                    }
                }
                catch (InvalidOperationException)
                {
                    tblResult.Text += "Ничего не найдено";
                }
            }
        }

        private void cbFromTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new MyDbcontext())
            {
                switch (cbFromTable.SelectedIndex)
                {
                    case 0:
                        cbFromColumn.ItemsSource = tchFields; break;
                    case 1:
                        cbFromColumn.ItemsSource = fclFields; break;
                    case 2:
                        cbFromColumn.ItemsSource =chrFields; break;
                }
                cbFromColumn.SelectedIndex = 0;
            }
        }
       
        private void CbFromColumn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
