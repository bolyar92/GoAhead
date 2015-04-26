using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAhead.Data
{
    public class MongoDataProvider : IDataProvider
    {
        public MongoDataProvider()
        {

        }

        public string GetDocument(string collection, string documentId)
        {
            //MongoClient mongoDriver = new MongoClient("http://localhost:27017/");

            //IMongoDatabase db = mongoDriver.GetDatabase("SN");
            ////db.GetCollection<string>("dasda").Find(new FilterDefinition<string>())


            return "{\"_id\":\"user_0\",\"friends\":[\"user_71\",\"user_59\",\"user_5\",\"user_98\",\"user_38\",\"user_89\",\"user_94\",\"user_97\"],\"images\":[],\"name\":\"Username 0\",\"places\":[]}";
        }
    }
}
