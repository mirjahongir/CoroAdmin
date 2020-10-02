using MongoDB.Bson.Serialization.Attributes;

using Repo;

using System;
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
        public string CreateUserId { get; set; }
        public List<ServerLogins> ServerLogins { get; set; }
        public List<ServerProjects> ServerProjects { get; set; }
    }
    public class ServerProjects
    {
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
    public class ServerLogins
    {
        public Guid Id { get; set; }
             
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
