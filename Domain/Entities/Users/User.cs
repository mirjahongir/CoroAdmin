using MongoDB.Bson.Serialization.Attributes;

using Repo;

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Users
{
    public class User:IDomain<string>
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public List<UserProject> UserProjects{ get; set; }
        public string RefreshToken { get; set; }
        public List<UserServer> UserServers { get; set; }
    }
    public class UserServer
    {
        public string ServerId { get; set; }
        public string ServerName { get; set; }
        public string AddUserId { get; set; }
        public DateTime DateTime { get; set; }
    }
    public class UserProject 
    {
        public string AddUserId { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime AddDate { get; set; }
        
    }
}
