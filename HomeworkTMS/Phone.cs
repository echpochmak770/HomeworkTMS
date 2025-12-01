using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    /*1. Класс Phone.
    Создайте класс Phone, который содержит переменные number, model и
    weight.
    Создайте три экземпляра этого класса.
    Выведите на консоль значения их переменных.
    Добавить в класс Phone методы: receiveCall, имеет один параметр – имя
    звонящего. Выводит на консоль сообщение “Звонит {name}”. getNumber –
    возвращает номер телефона. Вызвать эти методы для каждого из объектов.
    Добавить конструктор в класс Phone, который принимает на вход три
    параметра для инициализации переменных класса - number, model и weight.
    Добавить конструктор, который принимает на вход два параметра для
    инициализации переменных класса - number, model.
    teachmeskills.by
    Добавить конструктор без параметров.
    Вызвать из конструктора с тремя параметрами конструктор с
    двумя.
    Добавьте перегруженный метод receiveCall, который принимает два
    параметра - имя звонящего и номер телефона звонящего. Вызвать этот
    метод.
    Создать метод sendMessage с аргументами переменной длины. Данный
    метод принимает на вход номера телефонов, которым будет отправлено
    сообщение. Метод выводит на консоль номера этих телефонов.*/
    internal class Phone
    {
        private string _number;
        private string _model;
        private int _weight;

        public void ReceiveCall(string callerName) => Console.WriteLine($"Звонит {callerName}");

        public void ReceiveCall(string callerName, string callerNumber) => Console.WriteLine($"Звонит {callerName}, номер телефона {callerNumber}");

        public string GetNumber() => _number;

        public void SendMessage(params string[] numbers)
        {
            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        public Phone(string number, string model, int weight) : this(number, model)
        {
            _number = number;
            _model = model;
            _weight = weight;
        }

        public Phone(string number, string model)
        {
            _number = number;
            _model = model;
            _weight = 0;
        }

        public Phone()
        {
            _number = "Неизвестный номер";
            _model = "Неизвестная модель";
            _weight = 0;
        }
    }
}
