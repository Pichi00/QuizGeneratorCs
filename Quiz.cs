using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator
{
    internal class Quiz
    {
        private List<Question> questions = new List<Question>();

        public void addQuestion(Question q)
        {
            questions.Add(q);
        }

        public void remQuestion(Question q)
        {
            if (questions.Count > 0)
            {
                questions.Remove(q);
            }
        }

        public Question findQuestion(string text)
        {
            return questions.Find(x => x.Text == text);
        }

        public override string ToString()
        {
            string result = "";
            foreach (Question question in questions)
            {
                result+=question.ToString()+'\n';
            }
            return result;
        }

    }
}
