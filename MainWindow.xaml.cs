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
using System.IO;
using Microsoft.Win32;

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
            //autosave(quiz);
            clearBoxes();

        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            ListBox lbox = listBoxQuestions;
            var id = lbox.SelectedIndex;
            if (lbox.SelectedIndex > -1 && id > -1 && quiz.questions[id] != null)
            {
                Question question = quiz.questions[id];
                quiz.questions.Remove(question);
                listBoxQuestions.Items.Remove(listBoxQuestions.SelectedItem);
                Console.WriteLine(quiz);
                clearBoxes();
            }
            
        }

        private void listBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lbox = sender as ListBox;
            var id = lbox.SelectedIndex;
            Console.WriteLine(id);
            if (lbox.SelectedIndex > -1 && id > -1 && quiz.questions[id] != null)
            {                
          
                Question question = quiz.questions[id];
                var a1 = question.answers[0];
                var a2 = question.answers[1];
                var a3 = question.answers[2];
                var a4 = question.answers[3];
            
                textBoxQuestion.Text = question.Text;
                textBoxAnswer1.Text = a1.Text;
                textBoxAnswer2.Text = a2.Text;
                textBoxAnswer3.Text = a3.Text;
                textBoxAnswer4.Text = a4.Text;

                checkBoxAnswer1.IsChecked = a1.isCorrect();
                checkBoxAnswer2.IsChecked = a2.isCorrect();
                checkBoxAnswer3.IsChecked = a3.isCorrect();
                checkBoxAnswer4.IsChecked = a4.isCorrect();
            }
            
        }

       /* private void autosave(Quiz quiz)
        {
            quiz.QuizName = textBoxQuizName.Text;
            Cesar cesar = new Cesar();
            QuizMeneger qm = new QuizMeneger(quiz, cesar);
            qm.saveQuizToFile("quiz1.txt");

        }*/

        private void clearBoxes()
        {
            textBoxQuestion.Text = "";
            textBoxAnswer1.Text = "";
            textBoxAnswer2.Text = "";
            textBoxAnswer3.Text = "";
            textBoxAnswer4.Text = "";
            checkBoxAnswer1.IsChecked = false;
            checkBoxAnswer2.IsChecked = false;
            checkBoxAnswer3.IsChecked = false;
            checkBoxAnswer4.IsChecked = false;
        }


        private void buttonNewQuiz_Click(object sender, RoutedEventArgs e)
        {
            //Jeszcze nie dokończone
            quiz = new Quiz();
        }


        private void buttonSaveQuiz_Click(object sender, RoutedEventArgs e)
        {
            //Wybór lokalizacji zapisu pliku
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files(*.txt) | *.txt"; //Użytkownik może zapisać plik tylko jako plik tekstowy
            saveFileDialog.Title = "Wybierz plik, do którego zostanie zapisany quiz";
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            if (saveFileDialog.ShowDialog() == true)
            {
                var filepath = saveFileDialog.FileName;
                Console.WriteLine(filepath);
                quiz.QuizName = textBoxQuizName.Text;
                Cesar cesar = new Cesar();
                QuizMeneger qm = new QuizMeneger(quiz, cesar);
                qm.saveQuizToFile(filepath);
            }

        }

        private void buttonLoadQuiz_Click(object sender, RoutedEventArgs e)
        {
            //Wybór pliku do odczytania
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt"; //Użytkownik może wybrać tylko plik tekstowy
            openFileDialog.Title = "Wybierz plik, z którego zostanie wczytany quiz.";
            openFileDialog.Multiselect = false; //Użytkownik może wybrać tylko jeden plik
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();


            if (openFileDialog.ShowDialog() == true)
            {
                var filepath = openFileDialog.FileName;
                Console.WriteLine(filepath); //Wyświetli w konsoli ścieżkę wybranego pliku
                //Tu do dokończenia
            }

        }
       
    }
}
