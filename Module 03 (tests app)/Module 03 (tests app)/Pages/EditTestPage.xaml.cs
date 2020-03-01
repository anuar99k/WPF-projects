using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Module_03__tests_app_.Pages
{
    /// <summary>
    /// Interaction logic for EditTestPage.xaml
    /// </summary>
    public partial class EditTestPage : Page
    {
        public EditTestPage()
        {
            InitializeComponent();

            loadTests();
        }

        private List<Test> _tests = new List<Test>();

        private void loadTests()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Test>));

            if (new FileInfo("questions.xml").Length != 0)
            {
                using (FileStream fs = new FileStream("questions.xml", FileMode.Open))
                {
                    _tests = (List<Test>)formatter.Deserialize(fs);
                }
            }

            if (_tests.Count == 0)
            {
                spTestsWrapper.HorizontalAlignment = HorizontalAlignment.Center;
                spTestsWrapper.VerticalAlignment = VerticalAlignment.Center;
                Label lbl = new Label() { Content = "Тестов нет", FontSize = 16 };
                spTestsWrapper.Children.Add(lbl);
                return;
            }

            foreach (Test test in _tests)
            {
                Expander testExpander = new Expander();
                testExpander.Header = test.nameOfSection + ", Автор: " + test.author;
                testExpander.FontSize = 16;

                StackPanel oneTestWrapper = new StackPanel();

                StackPanel spLang = new StackPanel() { Orientation = Orientation.Horizontal };
                StackPanel spNameOfSubject = new StackPanel() { Orientation = Orientation.Horizontal };
                StackPanel spDescription = new StackPanel() { Orientation = Orientation.Horizontal };

                oneTestWrapper.Children.Add(spLang);
                oneTestWrapper.Children.Add(spNameOfSubject);
                oneTestWrapper.Children.Add(spDescription);

                // lang 
                Label lblLang = new Label() { Content = "Язык тестирования: ", FontSize = 16 };
                ComboBox cbxLangs = new ComboBox() { FontSize = 16 };

                cbxLangs.Items.Add("Русский");
                cbxLangs.Items.Add("Казахский");
                cbxLangs.Items.Add("Английский");
                cbxLangs.SelectedItem = test.language;
                spLang.Children.Add(lblLang);
                spLang.Children.Add(cbxLangs);

                // name of section
                Label lblNameOfSection = new Label() { Content = "Название раздела: ", FontSize = 16 };
                TextBox tbxNameOfSection = new TextBox() { FontSize = 16, Width = 180, VerticalAlignment = VerticalAlignment.Center };
                tbxNameOfSection.Text = test.nameOfSection;
                spNameOfSubject.Children.Add(lblNameOfSection);
                spNameOfSubject.Children.Add(tbxNameOfSection);

                // description
                Label lblDescription = new Label() { Content = "Описание: ", FontSize = 16 };
                TextBox tbxDescription = new TextBox() { FontSize = 16, Width = 180, VerticalAlignment = VerticalAlignment.Center };
                tbxDescription.Text = test.desription;
                spDescription.Children.Add(lblDescription);
                spDescription.Children.Add(tbxDescription);

                // questions
                Expander questionsExpander = new Expander();
                questionsExpander.Header = "Вопросы";
                StackPanel spQuestionsWrapper = new StackPanel();

                foreach (question question in test.questions)
                {
                    StackPanel spQuestionWrapper = new StackPanel() { Margin = new Thickness(0, 0, 0, 10) };
                    StackPanel spQuestionTextWrapper = new StackPanel() { Orientation = Orientation.Horizontal, Margin = new Thickness(0,5,0,10) };
                    StackPanel spQuestionAnswersWrapper = new StackPanel() { Orientation = Orientation.Horizontal };

                    Label lblQuestion = new Label() { Content = $"Вопрос №{question.id}: ", FontSize = 16 };
                    TextBox tbxQuestion = new TextBox() { FontSize = 16, Width = 180, VerticalAlignment = VerticalAlignment.Center };
                    tbxQuestion.Text = question.questionText;
                    spQuestionTextWrapper.Children.Add(lblQuestion);
                    spQuestionTextWrapper.Children.Add(tbxQuestion);

                    StackPanel spRadioBtns = new StackPanel() { Width = 25, HorizontalAlignment = HorizontalAlignment.Left };
                    for (int i = 0; i < 5; i++)
                    {
                        RadioButton rb = new RadioButton() { Margin = new Thickness(4, 4, 4, 9) };
                        spRadioBtns.Children.Add(rb);
                    }
                    int indexOfRightQuestion = question.answers.IndexOf(question.correctAnswer);
                    ((RadioButton)spRadioBtns.Children[indexOfRightQuestion]).IsChecked = true;

                    StackPanel spTextboxes = new StackPanel() { Width = 100 };
                    foreach (string answer in question.answers)
                    {
                        TextBox tbx = new TextBox() { Margin = new Thickness(0, 2, 0, 2), FontSize = 16  };
                        tbx.Text = answer;
                        spTextboxes.Children.Add(tbx);
                    }
                    spQuestionAnswersWrapper.Children.Add(spRadioBtns);
                    spQuestionAnswersWrapper.Children.Add(spTextboxes);

                    spQuestionWrapper.Children.Add(spQuestionTextWrapper);
                    spQuestionWrapper.Children.Add(spQuestionAnswersWrapper);

                    spQuestionsWrapper.Children.Add(spQuestionWrapper);
                }
                questionsExpander.Content = spQuestionsWrapper;

                oneTestWrapper.Children.Add(questionsExpander);

                Button btnSaveChanges = new Button();
                btnSaveChanges.Content = "Сохранить";
                btnSaveChanges.FontSize = 16;
                btnSaveChanges.Width = 150;
                btnSaveChanges.Padding = new Thickness(0,5,0,5);
                btnSaveChanges.Click += BtnSaveChanges_Click;

                oneTestWrapper.Children.Add(btnSaveChanges);

                testExpander.Content = oneTestWrapper;
                spTestsWrapper.Children.Add(testExpander);
            }

        }

        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
