using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator
{
    internal interface IEncryption
    {
        string Encrypt(Quiz quiz);
        string Decrypt(string text);
    }
}
