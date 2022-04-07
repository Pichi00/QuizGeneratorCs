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
            string text = quiz.ToString();
            char[] encryptedText = text.ToCharArray();
            int key = 11;   //Początkowa wartość klucza
            for (int i = 0; i < text.Length; i++)   //Pętla dla każdego znaku w tekście do zakodowania
            {
                if ((int)text[i] >= 40 && (int)text[i] <= 122)  //Koduje tylko znaki z zakresu (40 - 122) (Polskich znaków nie zmienia)
                {
                    encryptedText[i] = (char)(text[i] + key);
                    if (encryptedText[i] > 122) //Jeśli znak wychodzi poza zakres
                    {
                        encryptedText[i] = (char) (encryptedText[i] - 83);  //Pomniejsza kod znaku o 83 (Np. 123 -> 40)
                    }
                    key++;      // Zwiększenie klucza o 1
                    key %= 83;  // Żeby klucz nie był większy niż liczba znaków z zakresu (40 - 122)
                } 
            }
            return new string(encryptedText);
        }
        public string Decrypt(string text)
        {
            char[] decryptedText = text.ToCharArray();
            int key = 11;
            for (int i = 0; i < text.Length; i++) //Pętla dla każdego znaku w tekście do odkodowania
            {
                if ((int)text[i] >= 40 && (int)text[i] <= 122) //Odkodowuje tylko znaki z zakresu (40 - 122) (Polskich znaków nie zmienia)
                {
                    decryptedText[i] = (char)(text[i] - key);
                    if (decryptedText[i] < 40) //Jeśli znak wychodzi poza zakres
                    {
                        decryptedText[i] = (char)(decryptedText[i] + 83);  //Zwiększa kod znaku o 83 (Np. 39 -> 122)
                    }
                    key++;      // Zwiększenie klucza o 1
                    key %= 83;  // Żeby klucz nie był większy niż liczba znaków z zakresu (40 - 122)
                }
            }
            return new string(decryptedText); ;
        }
    }
}
