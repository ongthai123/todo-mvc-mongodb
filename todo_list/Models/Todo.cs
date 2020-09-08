using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace todo_list.Models
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required, MinLength(3)]
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("IsCompleted")]
        public bool IsCompleted { get; set; }
    }
}