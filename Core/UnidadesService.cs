using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IServiceUnidades
    {
        List<Unidades> Get();
        void Insert(Unidades unidades);
    }
    public class ServiceUnidades : IServiceUnidades
    {
        IDataBase _database;
        public ServiceUnidades(IDataBase database)
        {
            this._database = database;
        }
        public List<Unidades> Get()
        {
            return _database.GetUnidades();
        }
        public void Insert(Unidades unidades)
        {
            _database.InsertUnidades(unidades);
        }
    }
}

