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

namespace Crud11.Pages
{
    /// <summary>
    /// Логика взаимодействия для VisitPage.xaml
    /// </summary>
    public partial class VisitPage : Page
    {
        
        public VisitPage()
        {
            InitializeComponent();
            Refresh();
 
        }

        private void Refresh()
        {
            DgMain.ItemsSource = App.DB.Visit.ToList();

        }

        private void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = App.DB.Visit.ToList();
            if (CbFilter.SelectedIndex == 0)
            {

                DgMain.ItemsSource = list.Where(x=> x.Date.DayOfWeek==DayOfWeek.Monday).ToList();
            }
            else if (CbFilter.SelectedIndex == 1)
            {
                DgMain.ItemsSource = list.Where(x => x.Date.DayOfWeek == DayOfWeek.Tuesday).ToList();
            }
            else if (CbFilter.SelectedIndex == 2)
            {
                DgMain.ItemsSource = list.Where(x => x.Date.DayOfWeek == DayOfWeek.Wednesday).ToList();
            }
            else if (CbFilter.SelectedIndex == 3)
            {
                DgMain.ItemsSource = list.Where(x => x.Date.DayOfWeek == DayOfWeek.Thursday).ToList();
            }
            else if (CbFilter.SelectedIndex == 4)
            {
                DgMain.ItemsSource = list.Where(x => x.Date.DayOfWeek == DayOfWeek.Friday).ToList();
            }
            else if (CbFilter.SelectedIndex == 5)
            {
                DgMain.ItemsSource = list.Where(x => x.Date.DayOfWeek == DayOfWeek.Saturday).ToList();
            }
            else if (CbFilter.SelectedIndex == 6)
            {
                DgMain.ItemsSource = list.Where(x => x.Date.DayOfWeek == DayOfWeek.Sunday).ToList();
            }
            
        }

        private void BClearFilter_Click(object sender, RoutedEventArgs e)
        {
            CbFilter.SelectedItem = null;
            Refresh();
        }
    }
}
