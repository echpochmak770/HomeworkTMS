using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeworkTMS.CreditCardTask;
using HomeworkTMS.ComputerTask;
using HomeworkTMS.ATMTask;

namespace HomeworkTMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Demo_CreditCardTask();
            Demo_ComputerTask();
            Demo_ATMTask();
        }

        static void Demo_CreditCardTask()
        {
            //На всякий случай, номера карт ненастоящие. Я использовал онлайн-генератор, чтобы пройти проверку алгоритма Луна
            var creditCard1 = new CreditCard("4960-1448-6363-7670", 10000);
            var creditCard2 = new CreditCard("4960 1418 8602 3193");
            var creditCard3 = new CreditCard("4960142454966961", 5000);

            creditCard1.Deposit(15000);
            creditCard2.Deposit(10);
            creditCard3.Withdraw(4900);

            creditCard1.GetInfo();
            creditCard2.GetInfo();
            creditCard3.GetInfo();

            WaitForContinue();
        }

        static void Demo_ComputerTask()
        {
            var computer1 = new Computer(50000, "First Computer");

            var hDD = new HardDiskDrive("VeryBigHDD", 4096, HardDiskDriveType.Internal);
            var rAM = new RandomAccessMemory("VeryExpensiveThingy", 16);
            var computer2 = new Computer(100000, "Second Computer", hDD, rAM);

            computer1.GetInfo();
            computer2.GetInfo();

            WaitForContinue();
        }

        static void Demo_ATMTask()
        {
            var aTM = new ATM(20, 20, 20);
            aTM.GetInfo();
            aTM.AddMoney(5, 5, 0);
            aTM.GetInfo();
            aTM.WithdrawMoney(3600);
            aTM.GetInfo();
            aTM.WithdrawMoney(130);

            WaitForContinue();
        }

        static void WaitForContinue()
        {
            Console.WriteLine("Нажмите любую кнопку для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}