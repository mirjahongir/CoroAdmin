using MongoDB.Bson.Serialization.Attributes;

using Repo;

using System.Collections.Generic;

namespace Domain.Entities.Servers
{
    public class Server : IDomain<string>
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public List<ServerLogins> ServerLogins { get; set; }
    }
    public class ServerLogins
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
