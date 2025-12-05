using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.DocumentAccounting
{
    //Полагаю, что все документы не должны редактироваться (по крайней мере напрямую) и иметь уникальный идентификатор
    internal interface IDocument
    {
        int DocumentId { get; init; }
        DateOnly DocumentDate { get; init; }
        void GetInfo();
    }
}
