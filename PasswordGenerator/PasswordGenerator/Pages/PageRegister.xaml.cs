using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PasswordGenerator.Pages
{
    /// <summary>
    /// Interaction logic for PageRegister.xaml
    /// </summary>
    public partial class PageRegister : Page
    {
        public PageRegister()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User()
            {
                Login = tbxLogin.Text,
                fullName = tbxFullname.Text,
                birthdayDate = dpBirthDate.Text,
                Password = pswPassword.Password
            };
            newUser.Password = MyCrypt.Encrypt(newUser.Password);

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string json;

            using (FileStream fs = new FileStream("usersInfo.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                string fileContent;
                using (StreamReader reader = new StreamReader(fs))
                {
                    fileContent = reader.ReadToEnd();
                }
                List<User> users = serializer.Deserialize<List<User>>(fileContent);

                if (users == null)
                    users = new List<User>();
                
                newUser.id = users.Count + 1;
                users.Add(newUser);

                json = serializer.Serialize(users);
            }
            using (FileStream fs = new FileStream("usersInfo.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(json);
                }
            }

            MainWindow.AuthFrame_.Navigate(new PageAuth());
        }

        [Serializable]
        public class User
        {
            public int id { get; set; } = 1;
            public string Login { get; set; }
            public string fullName { get; set; }
            public string birthdayDate { get; set; }
            public string Password { get; set; }
        }

        public class MyCrypt
        {
            public static string Encrypt(string str)
            {
                if (str.Length == 0)
                {
                    return null;
                }
                char[] encryptedChars = new char[str.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    if (i % 2 == 0)
                        encryptedChars[i] = (char)((int)str[i] - 9);
                    else
                        encryptedChars[i] = (char)((int)str[i] + 16);
                }
                string encryptedString = new string(encryptedChars);
                return encryptedString;
            }
            public static string Decrypt(string str)
            {
                if (str.Length == 0)
                {
                    return null;
                }
                char[] decryptedChars = new char[str.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    if (i % 2 == 0)
                        decryptedChars[i] = (char)((int)str[i] + 9);
                    else
                        decryptedChars[i] = (char)((int)str[i] - 16);
                }
                string decryptedString = new string(decryptedChars);
                return decryptedString;
            }
        }
    }
}
