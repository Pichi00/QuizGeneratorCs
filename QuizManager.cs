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
    }
}
