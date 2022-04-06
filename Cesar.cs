using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator
{
    internal class Cesar: IEncryption
    {
        public string Encrypt(Quiz quiz)
        {
            return quiz.ToString();
        }
        public string Decrypt(Quiz quiz)
        {
            return "Cesar decryption";
        }
    }
}
