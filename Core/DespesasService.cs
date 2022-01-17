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
        Despesas FindData(int despesas_id);
        int Update(Despesas despesas,int despesas_id);
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
        public Despesas FindData(int despesas_id)
        {
            return _database.FindDespesas(despesas_id);
        }
        public int Update(Despesas despesas,int despesas_id)
        {
            return _database.Update(despesas, despesas_id);
        }
    }
}

