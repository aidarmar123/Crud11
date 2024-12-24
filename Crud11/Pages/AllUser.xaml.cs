using Crud11.Models;
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
    /// Логика взаимодействия для AllUser.xaml
    /// </summary>
    public partial class AllUser : Page
    {
        int skip = 0;
        public int Count { get; set; }
        public AllUser()
        {
            InitializeComponent();
            DataContext = this;
            Refresh();
        }

        private void Refresh()
        {
            DgClient.ItemsSource = App.DB.Client.ToList().Skip(skip).Take(Count);
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage(new Client()));
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DgClient.SelectedItem is Client user)
            {
                NavigationService.Navigate(new AddPage(user));

            }

        }

        private void BRemove_Click(object sender, RoutedEventArgs e)
        {
            if (DgClient.SelectedItem is Client user)
            {
                if (App.DB.Visit.Where(x => x.ClientId == user.Id).Count() == 0)
                {
                    App.DB.Client.Remove(user);
                    App.DB.SaveChanges();
                }
                else
                    MessageBox.Show("Есть записи");
            }
        }

        private void bNext_Click(object sender, RoutedEventArgs e)
        {
            skip += 1;
            if (skip > App.DB.Client.Count())
                skip = 0;
            Refresh();
        }

        private void bPrivous_Click(object sender, RoutedEventArgs e)
        {
            skip -= 1;
            if (skip < 0)
                skip = App.DB.Client.Count();
            Refresh();
        }

        private void TbSerach_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = TbSerach.Text.ToLower();
            var listClient = App.DB.Client.ToList();
            DgClient.ItemsSource = listClient.Where(x => x.SearchText.Contains(text)).ToList();
        }

        private void BAll_Click(object sender, RoutedEventArgs e)
        {
            TbSerach.Text = "";
            Refresh();
        }

        private void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbFilter.SelectedIndex==0)
            {
                DgClient.ItemsSource = App.DB.Client.OrderBy(x => x.Firstname).ToList();
            }
            else if (CbFilter.SelectedIndex == 1)
            {
                var list = App.DB.Client.ToList();
                DgClient.ItemsSource = list.OrderBy(x => x.LastVisit).ToList();
            }
        }

        private void ChbBirthday_Click(object sender, RoutedEventArgs e)
        {
            if (ChbBirthday.IsChecked == true)
            {
                DgClient.ItemsSource = App.DB.Client.Where(x=> x.BirthDate.Month == DateTime.Now.Month).ToList();
            }
            else 
                Refresh();
        }

        private void BVisit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VisitPage());
        }
    }
}
