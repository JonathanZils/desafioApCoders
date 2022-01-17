using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IServiceInquilino
    {
        List<Inquilinos> Get();
        void Insert(Inquilinos inquilinos);   
        
    }
    public class ServiceInquilino : IServiceInquilino
    {
        IDataBase _database;
        public ServiceInquilino(IDataBase database)
        {
            this._database = database;
        }
        public List<Inquilinos> Get()
        {
            return _database.GetInquilino();
        }
        public void Insert(Inquilinos inquilinos)
        {
            _database.InsertInquilino(inquilinos);
        }
    }
}
