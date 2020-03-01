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
using System.Xml.Serialization;
using Module_03__tests_app_;

namespace Module_03__tests_app_.Pages
{
    /// <summary>
    /// Interaction logic for CreateTestForm.xaml
    /// </summary>

    [Serializable]
    public class Test
    {
        public Test() { }
        [XmlAttribute]
        public int id { get; set; }
        [XmlAttribute]
        public string author { get; set; }
        public string language { get; set; }
        public string nameOfSection { get; set; }
        public string desription { get; set; }
        public List<question> questions { get; set; }
    }

    [Serializable]
    public class question
    {
        public question() { }
        public question(int id, string questionText, List<string> answers, string correctAnswer)
        {
            this.id = id;
            this.questionText = questionText;
            this.answers = answers;
            this.correctAnswer = correctAnswer;
        }
        public int id { get; set; }
        public string questionText { get; set; }
        public List<string> answers { get; set; }
        public string correctAnswer { get; set; }
    }

    public partial class CreateTestForm : Page
    {
        public CreateTestForm()
        {
            InitializeComponent();
        }
        
        private void AddQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            int numberOfQuestions = spQuestionsWrapper.Children.Count + 1;

            StackPanel oneQuestionWrapper = new StackPanel() { Margin = new Thickness(0, 0, 0, 10) };

            oneQuestionWrapper.Children.Add(new Label() { Content = $"Вопрос №{numberOfQuestions}", FontSize = 15 });

            StackPanel spQuestionText = new StackPanel();
            spQuestionText.Orientation = Orientation.Horizontal;
            spQuestionText.Margin = new Thickness(0, 5, 0, 10);
            spQuestionText.Children.Add(new Label() { Content = "Введите вопрос: ", FontSize = 16 });
            spQuestionText.Children.Add(new TextBox() { Width = 260, FontSize = 16, Name = $"questionText_{numberOfQuestions}" });

            StackPanel answersWrapper = new StackPanel() { Orientation = Orientation.Horizontal };

            StackPanel radioBtnsWrapper = new StackPanel() { Width = 25, HorizontalAlignment = HorizontalAlignment.Left };
            radioBtnsWrapper.Children.Add(new RadioButton()
            {
                IsChecked = true,
                Name = $"answer_{numberOfQuestions}_1",
                Margin = new Thickness(4, 4, 4, 9)
            });
            for (int i = 1; i < 5; i++)
            {
                radioBtnsWrapper.Children.Add(new RadioButton() {
                    Name = $"answer_{numberOfQuestions}_{i + 1}",
                    Margin = new Thickness(4, 4, 4, 9)
                });
            }
            StackPanel answersTextWrapper = new StackPanel() { Width = 100 };
            for (int i = 0; i < 5; i++)
            {
                answersTextWrapper.Children.Add(new TextBox() { Text = $"ответ {i + 1}", FontSize = 16, Margin = new Thickness(0, 2, 0, 2) });
            }

            answersWrapper.Children.Add(radioBtnsWrapper);
            answersWrapper.Children.Add(answersTextWrapper);

            oneQuestionWrapper.Children.Add(spQuestionText);
            oneQuestionWrapper.Children.Add(answersWrapper);

            spQuestionsWrapper.Children.Add(oneQuestionWrapper);
        }

        private void BtnSaveTest_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Test>));

            List<Test> oldTests = new List<Test>();

            if (new FileInfo("questions.xml").Length != 0)
            {
                using (FileStream fs = new FileStream("questions.xml", FileMode.Open))
                {
                    oldTests = (List<Test>)formatter.Deserialize(fs);
                }
            }

            Test newTest = new Test();
            newTest.id = oldTests.Count + 1;
            newTest.author = DBcontext.currentUser.Login;
            newTest.language = cmbxLang.Text;
            newTest.nameOfSection = tbxNameOfSection.Text;
            newTest.desription = tbxDescription.Text;
            newTest.questions = new List<question>();

            int count = 1;
            foreach (StackPanel oneQuestion in spQuestionsWrapper.Children)
            {
                question qst = new question();
                qst.id = count++;
                qst.questionText = ((TextBox)(((StackPanel)oneQuestion.Children[1]).Children[1])).Text;

                StackPanel radioBtnsWrapper = (StackPanel)((StackPanel)oneQuestion.Children[2]).Children[0];
                int indexOfCorrectAnswer = 0;
                for(int i = 0; i < radioBtnsWrapper.Children.Count; i++)
                {
                    RadioButton rb = (RadioButton)radioBtnsWrapper.Children[i];
                    if ((bool)rb.IsChecked)
                    {
                        indexOfCorrectAnswer = i;
                        break;
                    }
                }

                StackPanel answersWrapper = (StackPanel)((StackPanel)oneQuestion.Children[2]).Children[1];
                qst.answers = new List<string>();
                foreach(TextBox tbx in answersWrapper.Children)
                {
                    qst.answers.Add(tbx.Text);
                }

                qst.correctAnswer = qst.answers[indexOfCorrectAnswer];

                newTest.questions.Add(qst);
            }

            oldTests.Add(newTest);

            using (FileStream fs = new FileStream("questions.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, oldTests);
            }
            svMainWrapper.IsEnabled = false;
            MessageBox.Show("Тест успешно сохранен");
            MainWindow.MainFrame_.Navigate(new startPage());
        }
    }
}
