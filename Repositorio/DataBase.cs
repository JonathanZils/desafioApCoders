using System.Collections.Generic;
using System.Linq;
using Core;
using MongoDB.Driver;

namespace Repositorio
{
    public class DataBase : IDataBase
    {
        public DataBase(DataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            InquilinosCollection = database.GetCollection<Inquilinos>("Inquilinos");
            UnidadesCollection = database.GetCollection<Unidades>("Unidades");

        }
        public IMongoCollection<Inquilinos> InquilinosCollection { get; set; }
        public IMongoCollection<Unidades> UnidadesCollection { get; set; }

        public List<Inquilinos> GetInquilino() =>

            InquilinosCollection.Find(Inquilinos => true).ToList();

        public void InsertInquilino(Inquilinos inquilinos)
        {
            InquilinosCollection.InsertOne(inquilinos);
        }

        public List<Unidades> GetUnidades() =>

           UnidadesCollection.Find(Unidades => true).ToList();

        public void InsertUnidades(Unidades unidades)
        {
            UnidadesCollection.InsertOne(unidades);
        }
    }
}
