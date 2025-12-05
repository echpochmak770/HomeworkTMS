using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.DocumentAccounting
{
    internal class EmployeeContract : IDocument
    {
        public int DocumentId { get; init; } = DocumentIdGenerator.GetNextId();
        public DateOnly DocumentDate { get; init; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly ContractEndDate { get; init; }
        public string EmployeeName { get; init; }

        public EmployeeContract(int contractDurationMonths, string employeeName)
        {
            EmployeeName = employeeName;
            ContractEndDate = DateOnly.FromDateTime(DateTime.Now).AddMonths(contractDurationMonths);
        }

        public EmployeeContract() : this(12, "Unknown") { }

        public void GetInfo()
        {
            Console.WriteLine($"Контракт с сотрудником" +
                $"\nИдентификатор документа: {DocumentId}" +
                $"\nДата заключения контракта: {DocumentDate}" +
                $"\nДата окончания контракта: {ContractEndDate}" +
                $"\nИмя сотрудника: {EmployeeName}\n");
        }
    }
}
