﻿using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebApplication1.MongoDb
{
    [BsonIgnoreExtraElements]
    public class Item
    {
        [BsonId]
        public string Id { get; set; }
        public int Property1 { get; set; }
        public int Property2 { get; set; }
        public int Property3 { get; set; }
        public string Property4 { get; set; }
        public string Property5 { get; set; }
        public string Property6 { get; set; }
        public DateTime Property7 { get; set; }
        public DateTime Property8 { get; set; }
        public DateTime Property9 { get; set; }
    }
}