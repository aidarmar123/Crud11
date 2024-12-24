using Crud11.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        Client contextClient;
        public AddPage(Models.Client client)
        {
            InitializeComponent();
            contextClient=client;
            DataContext = contextClient;
        }

        private void BPhoto_Click(object sender, RoutedEventArgs e)
        {
            var file = new OpenFileDialog() { Filter = ".png, .jpg| *.png; *.jpg" };
            if (file.ShowDialog().GetValueOrDefault())
            {
                FileInfo fileInfo = new FileInfo(file.FileName);
                if(fileInfo.Length<150 * 1024)
                {
                    contextClient.Photo=File.ReadAllBytes(file.FileName);
                    DataContext=null;
                    DataContext=contextClient;
                }
                else
                {
                    MessageBox.Show("Файл слишком большой");
                }
            }
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if (contextClient.Id == 0)
                App.DB.Client.Add(contextClient);
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            var print = new PrintDialog();
            if (print.ShowDialog().GetValueOrDefault())
            {
                print.PrintVisual(this, "");
            }
        }
    }
}
