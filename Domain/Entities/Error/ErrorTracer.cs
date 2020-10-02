using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.Error
{

    public class ErrorTracer
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonRequired]
        public string Id { get; set; }
        public string PorojectId { get; set; }
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }

    }
}
