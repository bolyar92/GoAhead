using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoAhead.Data
{
    public class MongoDataProvider : IDataProvider
    {
        public string GetDocument(string collection, string documentId)
        {
            if (string.IsNullOrWhiteSpace(collection) || string.IsNullOrWhiteSpace(documentId))
            {
                return string.Empty;
            }

            try
            {

                MongoClient mongoClient = new MongoClient();
                IMongoDatabase db = mongoClient.GetDatabase("SN");

                IMongoCollection<BsonDocument> dbCollection = db.GetCollection<BsonDocument>(collection);

                // WE SHOULD USE THE _id NOT THE ALIAS
                var bsonDocument = new BsonDocument();
                bsonDocument.Add("alias", new BsonString(documentId));
                //bsonDocument.Add("_id", new BsonObjectId(new ObjectId(documentId)));

                var queryDocument = new QueryDocument(bsonDocument);
                IFindFluent<BsonDocument, BsonDocument> result = dbCollection.Find(queryDocument);
                var jsonDocument = result.FirstOrDefaultAsync();

                if (jsonDocument != null && jsonDocument.Result != null)
                {
                    jsonDocument.Result.Remove("_id");

                    return jsonDocument.Result.ToJson<BsonDocument>();
                }
            }
            catch
            {
            }

            return string.Empty;
        }

    }
}
