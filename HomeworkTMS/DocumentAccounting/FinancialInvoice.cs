using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.DocumentAccounting
{
    internal class FinancialInvoice : IDocument
    {
        public int DocumentId { get; init; } = DocumentIdGenerator.GetNextId();
        public DateOnly DocumentDate { get; init; } = DateOnly.FromDateTime(DateTime.Now);
        public double AmountForMonthDollars { get; init; }
        public Departments DepartmentCode { get; init; }

        public FinancialInvoice(double amountForMonthDollars, Departments departmentCode)
        {
            AmountForMonthDollars = amountForMonthDollars;
            DepartmentCode = departmentCode;
        }

        public FinancialInvoice() : this(0, Departments.Unspecified) { }

        public void GetInfo()
        {
            Console.WriteLine($"Финансовая накладная" +
                $"\nИдентификатор документа: {DocumentId}" +
                $"\nДата заключения контракта: {DocumentDate}" +
                $"\nИтоговая сумма за месяц: {AmountForMonthDollars}" +
                $"\nКод департамента: {DepartmentCode}\n");
        }
    }

    enum Departments
    {
        Accounting,
        Finance,
        HR,
        IT,
        Unspecified
    }
}
