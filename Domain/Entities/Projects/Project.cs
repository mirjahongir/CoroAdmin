using MongoDB.Bson.Serialization.Attributes;

using Repo;

using System;
using System.Collections.Generic;

namespace Domain.Entities.Projects
{
    public class Project : IDomain<string>
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public List<ProjectServers> ProjectServers { get; set; }

    }
    public class ProjectServers
    {
        public string Id { get; set; }
        public string Ip { get; set; }

    }


}
