using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Module_03__tests_app_.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private DBcontext dB = new DBcontext();
        private User _user = new User();

        public LoginPage()
        {
            InitializeComponent();
            spWrapper.DataContext = _user;
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            _user.Password = psbPassword.Password;

            if (_user.Login == "" || _user.Password == "" || _user.Login == null || _user.Password == null)
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                List<User> allUsers = dB.GetAllUsers();

                foreach (User user in allUsers)
                {
                    if (user.Login == _user.Login && user.Password == _user.Password)
                    {
                        DBcontext.currentUser = _user;

                        MenuItem miCreateTest = new MenuItem();
                        miCreateTest.Header = "Создать тест";
                        miCreateTest.Click += CreateTest_Click;

                        MenuItem miEditTests = new MenuItem();
                        miEditTests.Header = "Редактировать тест";
                        miEditTests.Click += EditTest_Click;

                        MainWindow.miMainMenu_.Items.Add(miCreateTest);
                        MainWindow.miMainMenu_.Items.Add(miEditTests);

                        MainWindow.miMainMenu_.Items.RemoveAt(0);
                        MainWindow.miMainMenu_.Items.RemoveAt(0);

                        MessageBox.Show("Вход выполнен");
                        MainWindow.MainFrame_.Navigate(new startPage());
                        return;
                    }
                }
                MessageBox.Show("Пользователь не найден");
            }
        }

        private void EditTest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame_.Navigate(new EditTestPage());
        }

        private void CreateTest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame_.Navigate(new CreateTestForm());
        }
    }
}
