using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuizGenerator
{
    internal class QuizMeneger
    {
        Quiz Quiz { get; set; }
        IEncryption Encryption { get; set; }

        public QuizMeneger(Quiz quiz, IEncryption encryption)
        {
            Quiz = quiz;
            Encryption = encryption;
        }

        public void saveQuizToFile(string path)
        {
            string text = Encryption.Encrypt(Quiz);
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            File.WriteAllText(Path.Combine(docPath, path), text);
            Console.WriteLine(Path.Combine(docPath, path));
            Console.WriteLine(Encryption.Encrypt(Quiz));
        }
    }
}
