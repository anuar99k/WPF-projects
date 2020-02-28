using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Web.Script.Serialization;

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
            User user = new User()
            {
                fullName = tbxFullname.Text,
                birthdayDate = dpBirthDate.Text
            };
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //serializer.Serialize()
            //serializer.Deserialize<User>()
            using (FileStream fs = new FileStream("usersInfo.txt", FileMode.OpenOrCreate))
            {
                //if (FileInfo())
            }
        }

        [Serializable]
        class User
        {
            public int id { get; set; } = 1;
            public string fullName { get; set; }
            public string birthdayDate { get; set; }
        }
    }
}
