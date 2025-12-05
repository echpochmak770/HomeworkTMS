using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.DocumentAccounting
{
    internal class Register
    {
        private static uint _registerLength = 10;
        private static int _currentIndex = 0;
        public static IDocument[] Documents { get; private set; } = new IDocument[_registerLength];


        public void AddDocument(IDocument document)
        {
            Documents[_currentIndex] = document;
            _currentIndex++;
        }

        public void GetInfoAt(int documentId)
        {
            for (int i = 0; i < Documents.Length; i++)
            {
                if (Documents[i] == null)
                {
                    break;
                }

                if (Documents[i].DocumentId == documentId)
                {
                    Documents[i].GetInfo();
                    return;
                }
            }

            Console.WriteLine("Не найдено документа с выбранным идентификатором");
        }
    }
}
