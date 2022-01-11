using System;
using System.Collections.Generic;

namespace Core
{
    public interface IDataBase
    {
        List<Inquilinos> Get();
        void InsertData(Inquilinos inquilinos);       
    }
}
