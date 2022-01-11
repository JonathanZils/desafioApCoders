using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IService
    {
        List<Inquilinos> Get();
        void Insert(Inquilinos inquilinos);                
    }
    public class Service : IService
    {
        IDataBase _database;
        public Service(IDataBase database)
        {
            this._database = database;
        }
        public List<Inquilinos> Get()
        {
            return _database.Get();
        }
        public void Insert(Inquilinos inquilinos)
        {
            _database.InsertData(inquilinos);
        }
    }
}
