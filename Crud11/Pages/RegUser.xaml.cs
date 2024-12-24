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
    /// Логика взаимодействия для RegUser.xaml
    /// </summary>
    public partial class RegUser : Page
    {
        User contextUser;
        public RegUser(User user)
        {
            InitializeComponent();
            contextUser = user;
            DataContext = contextUser;

        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            var user = App.DB.User.FirstOrDefault(x => x.Login == contextUser.Login);

            if (user == null)
            {
                if (ValidationOnject(contextUser).Length==0)
                {

                    if (contextUser.Id == 0)
                        App.DB.User.Add(contextUser);
                    App.DB.SaveChanges();
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show(ValidationOnject(contextUser).ToString());
                }

            }
            else
            {
                MessageBox.Show("Пользователь найден");
            }
        }

        private StringBuilder ValidationOnject(User contextUser)
        {
            var error = new StringBuilder();
            if(contextUser.Login=="")
                error.AppendLine("Login is null");
            if(contextUser.Password=="")
                error.AppendLine("Password is null");

            return error;
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        } //
    }
}
