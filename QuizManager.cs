using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuizGenerator
{
    internal class QuizManager
    {
        Quiz Quiz { get; set; }
        IEncryption Encryption { get; set; }

        public QuizManager(Quiz quiz, IEncryption encryption)
        {
            Quiz = quiz;
            Encryption = encryption;
        }

        public void saveQuizToFile(string filepath)
        {
            string text = Encryption.Encrypt(Quiz);
            string docPath = Directory.GetCurrentDirectory(); //Pobierze ścierzkę używaną przez program (.\bin\Debug) 
            File.WriteAllText(filepath, text);
            //Console.WriteLine(filepath); // Wyświetli ścieżkę zapisu pliku w konsoli
            //Console.WriteLine(text);
            //Console.WriteLine(Encryption.Decrypt(text));  // test deszyfrowania

        }

        public Quiz loadQuizFromFile(string filepath)
        {
            Quiz quiz = new Quiz();
            
            string text = "";
            foreach(string line in File.ReadLines(filepath))
            {
                text+=(line+'\n');
            }
            Console.WriteLine(text);
            text = Encryption.Decrypt(text);
            Console.WriteLine(text);

            string[] lines = text.Split(new char[] { '\n' });
            int line_num = 0;

            string questionText;
            Answer[] answers = new Answer[4];
            foreach (string line in lines)
            {
                
                if(line_num == 0)
                {
                    quiz.QuizName = line;
                }
                else if(line_num % 5 == 1){
                    questionText = line;
                }
                else
                {
                    answers[(line_num % 5) - 2].Text = line;
                }
                line_num++;
            }
            return quiz;
        }
    }
}
