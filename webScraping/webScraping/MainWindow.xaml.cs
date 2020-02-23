using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Serialization;

namespace webScraping
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string url = "https://habr.com/ru/top/yearly/";

        public MainWindow()
        {
            InitializeComponent();

            webBrowser.Navigate(url);
        }

        private async void BtnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            // loading
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

            HttpClient httpClient = new HttpClient();
            var htmlString = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlString);

            var postsHTML = htmlDocument.DocumentNode.Descendants("ul")
                            .Where(node => node.GetAttributeValue("class", "")
                            .Equals("content-list content-list_posts shortcuts_items")).ToList();

            var postsList = postsHTML[0].Descendants("li")
                            .Where(node => node.GetAttributeValue("id", "")
                            .Contains("post")).ToList();

            Mouse.OverrideCursor = null;

            stackPanelPosts.Children.Add(new Label() { Content = "Количество постов: " + postsList.Count });

            int count = 1;

            foreach (var post in postsList)
            {
                string title = post.Descendants("a")
                               .Where(node => node.GetAttributeValue("class", "")
                               .Equals("post__title_link")).FirstOrDefault().InnerText.Trim();

                string description = Regex.Replace(post.Descendants("div")
                                     .Where(node => node.GetAttributeValue("class", "")
                                     .Equals("post__text post__text-html"))
                                     .FirstOrDefault().InnerText.Trim(), @"[\n\r\t]", "");

                string author = post.Descendants("span")
                                .Where(node => node.GetAttributeValue("class", "")
                                .Equals("user-info__nickname user-info__nickname_small")).FirstOrDefault().InnerText.Trim();

                string createdAt = post.Descendants("span")
                                   .Where(node => node.GetAttributeValue("class", "")
                                   .Equals("post__time")).FirstOrDefault().InnerText.Trim();

                TextBlock textBlock = new TextBlock();
                textBlock.Text = "Заголовок: " + title + "\n";
                textBlock.Text += "Автор: " + author + "\n";
                textBlock.Text += "Дата публикации: " + createdAt + "\n";
                textBlock.Text += "Описание: " + description + "\n";
                textBlock.Text += "------------------------------------------------------------------";

                stackPanelPosts.Children.Add(textBlock);

                this._posts.Add(new Post() { id = count++, Title = title, Author = author, CreatedAt = createdAt, Description = description });
            }

        }

        [Serializable]
        public class Post
        {
            [XmlAttribute]
            public int id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string CreatedAt { get; set; }
            public string Description { get; set; }
        }

        private List<Post> _posts = new List<Post>();

        private void BtnCreateXML_Click(object sender, RoutedEventArgs e)
        {
            string path = @tbxPathForSave.Text.Trim();
            if (string.IsNullOrEmpty(path) || path == "Путь для сохранения...")
            {
                lblInfo.Content = "Укажите путь для сохранения";
                lblInfo.Foreground = new SolidColorBrush(Colors.Red);
                lblInfo.HorizontalAlignment = HorizontalAlignment.Center;
                lblInfo.FontSize = 15;
            }
            else
            {
                path += "\\postsFromHabr.xml";
                XmlSerializer formatter = new XmlSerializer(typeof(List<Post>));
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    formatter.Serialize(fs, this._posts);
                }
                lblInfo.Content = "Файл успешно сохранен";
                lblInfo.Foreground = new SolidColorBrush(Colors.Green);
                lblInfo.HorizontalAlignment = HorizontalAlignment.Center;
                lblInfo.FontSize = 15;
            }
        }

        private void TbxPathForSave_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxPathForSave.Text == "Путь для сохранения...")
            {
                tbxPathForSave.Text = "";
            }
        }

        private void TbxPathForSave_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxPathForSave.Text == "")
            {
                tbxPathForSave.Text = "Путь для сохранения...";
            }
        }
    }
}
