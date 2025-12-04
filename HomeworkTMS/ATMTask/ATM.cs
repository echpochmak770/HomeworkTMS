namespace HomeworkTMS.ATMTask
{
    internal class ATM
    {
        //Стоило ли сделать отдельный класс для банконоты с валидацией и создать 3 поля этого класса для каждого номинала???
        public uint Banknotes20 { 
            get;
            private set
            {
                ValidateBanknoteAmount(value);
                field = value;
            }
        }
        public uint Banknotes50
        {
            get;
            private set
            {
                ValidateBanknoteAmount(value);
                field = value;
            }
        }
        public uint Banknotes100 { 
            get; 
            private set
            {
                ValidateBanknoteAmount(value);
                field = value;
            }
        }

        public ATM(uint banknotes20, uint banknotes50, uint banknotes100)
        {
            Banknotes20 = banknotes20;
            Banknotes50 = banknotes50;
            Banknotes100 = banknotes100;
        }

        private static void ValidateBanknoteAmount(uint amount)
        {
            if (amount > 2500)
            {
                throw new ArgumentException("Обычно банкоматы содержат 2500 банкнот одного номинала и меньше");
            }
        }

        private (uint, uint, uint) GetBillSplit(uint amount)
        {
            uint count100 = amount / 100;
            uint remainder = amount % 100;

            uint count50 = remainder / 50;
            remainder %= 50;

            while ((remainder % 20 != 0) || (remainder > 0 && count50 == 0 && count100 > 0))
            {
                if (count50 > 0)
                {
                    count50--;
                    remainder += 50;
                }
                else if (count100 > 0)
                {
                    count100--;
                    remainder += 100;
                    count50 += 2;
                }
                else
                {
                    break;
                }
            }

            if (remainder % 20 != 0)
            {
                throw new ArgumentException("Сумма должна быть кратна 20, 50 или 100. Или в банкомате не хватает купюр для выдачи желаемой суммы");
            }

            uint count20 = remainder / 20;

            return (count20, count50, count100);
        }

        public void GetInfo()
        {
            Console.WriteLine($"Банкомат" +
                $"\nКол-во купюр номиналом 20: {Banknotes20}" +
                $"\nКол-во купюр номиналом 50: {Banknotes50}" +
                $"\nКол-во купюр номиналом 100: {Banknotes100}" +
                $"\nОбщая сумма денег: {Banknotes100 * 100 + Banknotes20 * 20 + Banknotes50 * 50}");
        }

        public void AddMoney(uint banknotes20, uint banknotes50, uint banknotes100)
        {
            this.Banknotes20 += banknotes20;
            this.Banknotes50 += banknotes50;
            this.Banknotes100 += banknotes100;

            Console.WriteLine("Деньги были успешно добавлены в банкомат");
        }

        public bool WithdrawMoney(uint amount)
        {
            try
            {
                var (banknotes20, banknotes50, banknotes100) = GetBillSplit(amount);

                while (banknotes100 > this.Banknotes100)
                {
                    banknotes100--;
                    banknotes50 += 2;
                }

                while (banknotes50 > this.Banknotes50)
                {
                    if (banknotes50 >= 2)
                    {
                        banknotes50 -= 2;
                        banknotes20 += 5;
                    }

                    else
                    {
                        Console.WriteLine("Нельзя вывести заданное количество денег текущим количеством купюр заданного номинала" +
                            "(не хватает размера 50->20)");
                        return false;
                    }
                }

                if (banknotes20 > Banknotes20)
                {
                    Console.WriteLine("Нельзя вывести заданное количество денег текущим количеством купюр заданного номинала" +
                                            "(не хватает размера 20)");
                    return false;
                }

                this.Banknotes20 -= banknotes20;
                this.Banknotes50 -= banknotes50;
                this.Banknotes100 -= banknotes100;

                Console.WriteLine($"Было выведено {amount} рублей" +
                    $"\nНоминалы купюр" +
                    $"\n20x: {banknotes20}" +
                    $"\n50x: {banknotes50}" +
                    $"\n100x: {banknotes100}");

                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
