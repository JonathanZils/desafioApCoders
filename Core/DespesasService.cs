using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
   
     public interface IServiceDespesas
    {
        List<Despesas> Get();
        void Insert(Despesas despesas);
    }
    public class ServiceDespesas : IServiceDespesas
    {
        IDataBase _database;
        public ServiceDespesas(IDataBase database)
        {
            this._database = database;
        }
        public List<Despesas> Get()
        {
            return _database.GetDespesas();
        }
        public void Insert(Despesas despesas)
        {
            _database.InsertDespesas(despesas);
        }
    }
}

