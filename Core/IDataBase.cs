using System;
using System.Collections.Generic;

namespace Core
{
    public interface IDataBase
    {
        List<Inquilinos> GetInquilino();
        void InsertInquilino(Inquilinos inquilinos);

        List<Unidades> GetUnidades();
        void InsertUnidades(Unidades unidades);
    }
}
