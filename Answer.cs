using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator
{
    internal class Answer
    {
        public string Text {get;set;}
        public bool Correct { get;set;}

        public Answer(string text, bool correct)
        {
            Text = text;
            Correct = correct;
        }

        public bool isCorrect()
        {
            if (Correct) { return true; }
            return false;
        }

        public int isCorrectInt()
        {
            if (Correct) { return 1; }
            return 0;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
