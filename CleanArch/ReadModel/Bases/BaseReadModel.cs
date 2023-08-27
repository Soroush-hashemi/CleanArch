using MongoDB.Bson.Serialization.Attributes;

namespace ReadModel.Bases
{
    public class BaseReadModel
    {
        [BsonId]
        public long Id { get; set; }
    }
}
