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

            
            quiz.QuizName = lines[0];
            int questionsAmount = (lines.Count() - 2) / 5;
            Console.Write(questionsAmount);
            for (int i=0; i< questionsAmount; i++)
            {
                
                string questionText = "";
                Answer[] answers = new Answer[4];
                for (int j=1; j <= 5; j++)
                {
                    if (j == 1)
                    {
                        questionText = lines[5*i+j];
                    }
                    else
                    {
                        string aText = lines[5 * i + j].Substring(0, lines[5 * i + j].Length - 2);
                        bool aCorr = (lines[5 * i + j][lines[5 * i + j].Length - 1] == '1');
                        answers[j - 2] = new Answer(aText, aCorr);
                    }
                }
                Question question = new Question(questionText,answers);
                quiz.questions.Add(question);

            }
            return quiz;
        }
    }
}
