using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator
{
    internal class Question
    {
       // private int Id { get; set; }
        public string Text { get; set; }
        public Answer[] answers = new Answer[4];

       public Question(string text, Answer[] answers)
        {
            Text = text;
            this.answers = answers;
        }

        public override string ToString()
        {
            //return Text;
            return  $"{Text}\n" +
                    $"{answers[0]} {answers[0].isCorrect()}\n" +
                    $"{answers[1]} {answers[1].isCorrect()}\n" +
                    $"{answers[2]} {answers[2].isCorrect()}\n" +
                    $"{answers[3]} {answers[3].isCorrect()}";

        }
    }
}
