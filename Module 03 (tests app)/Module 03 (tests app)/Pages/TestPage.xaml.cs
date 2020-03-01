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

namespace Module_03__tests_app_.Pages
{
    /// <summary>
    /// Interaction logic for TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage(Test test)
        {
            InitializeComponent();

            spTestWrapper.DataContext = test;

            loadQuestions(test.questions);
        }

        private void loadQuestions(List<question> questions)
        {
            foreach(question quest in questions)
            {
                StackPanel spOneQuestionWrapper = new StackPanel();

                Label lblQuestionText = new Label() { FontSize = 16 };
                lblQuestionText.Content = quest.id + ") " + quest.questionText;
                spOneQuestionWrapper.Children.Add(lblQuestionText);

                StackPanel spAnswersWrapper = new StackPanel() { Orientation = Orientation.Horizontal };
                StackPanel spRadioButtonsWrapper = new StackPanel() { Width = 25, HorizontalAlignment = HorizontalAlignment.Left };
                StackPanel spAnswersTextWrapper = new StackPanel() { Width = 100 };
                foreach(string answer in quest.answers)
                {
                    RadioButton rb = new RadioButton() { Margin = new Thickness(4, 4, 4, 9) };
                    TextBlock lbl = new TextBlock() { Text = answer, FontSize = 16, Margin = new Thickness(0,0,0,6)};

                    spRadioButtonsWrapper.Children.Add(rb);
                    spAnswersTextWrapper.Children.Add(lbl);
                }
                spAnswersWrapper.Children.Add(spRadioButtonsWrapper);
                spAnswersWrapper.Children.Add(spAnswersTextWrapper);
                spOneQuestionWrapper.Children.Add(spAnswersWrapper);

                spQuestionsWrapper.Children.Add(spOneQuestionWrapper);
            }
        }

        private void BtnFinishTest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
