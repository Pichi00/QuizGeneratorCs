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

namespace QuizGenerator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Quiz quiz = new Quiz();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            Answer a1 = new Answer(textBoxAnswer1.Text, (bool)checkBoxAnswer1.IsChecked);
            Answer a2 = new Answer(textBoxAnswer2.Text, (bool)checkBoxAnswer2.IsChecked);
            Answer a3 = new Answer(textBoxAnswer3.Text, (bool)checkBoxAnswer3.IsChecked);
            Answer a4 = new Answer(textBoxAnswer4.Text, (bool)checkBoxAnswer4.IsChecked);
            Answer[] answers = { a1, a2, a3, a4 };
            
            Question question = new Question(textBoxQuestion.Text, answers);
            listBoxQuestions.Items.Add(question);
            quiz.addQuestion(question);
            autosave(quiz);
            
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            Question question = quiz.findQuestion(textBoxQuestion.Text);
            quiz.remQuestion(question);
            listBoxQuestions.Items.Remove(listBoxQuestions.SelectedItem);
            Console.WriteLine(quiz);
        }

        private void listBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lbox = sender as ListBox;
            var item = lbox.SelectedItem as Question;
            if ((lbox.SelectedItems.Count > -1) && (item != null))
            {
                textBoxQuestion.Text = item.Text;
            }

        }

        private void autosave(Quiz quiz)
        {
            Cesar cesar = new Cesar();
            QuizMeneger qm = new QuizMeneger(quiz, cesar);
            qm.saveQuizToFile("quiz1.txt");
        }
    }
}
