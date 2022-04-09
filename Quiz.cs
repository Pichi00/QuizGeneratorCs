using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator
{
    internal class Quiz
    {
        public List<Question> questions = new List<Question>();
        public string QuizName { get; set; }
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

        public bool hasQuestions()
        {
            if (questions.Any()) return true;
            return false;
        }

        public override string ToString()
        {
            string result = QuizName+'\n';
            foreach (Question question in questions)
            {
                result+=question.ToString();
            }
            return result;
        }

    }
}
