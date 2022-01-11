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
            Collection = database.GetCollection<Inquilinos>("Inquilinos");

        }
        public IMongoCollection<Inquilinos> Collection { get; set; }

        public List<Inquilinos> Get() =>

            Collection.Find(Inquilinos => true).ToList();

        public void InsertData(Inquilinos inquilinos)
        {
            Collection.InsertOne(inquilinos);
        }
     }
}
