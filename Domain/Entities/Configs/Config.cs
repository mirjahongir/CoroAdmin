using MongoDB.Bson.Serialization.Attributes;

using Repo;

using System.Collections.Generic;


namespace Domain.Entities.Configs
{
    public class Config : IDomain<string>
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public List<IpConfigs> IpConfigs { get; set; }
    }
    public class IpConfigs
    {
        public string Ip { get; set; }

    }
}
