using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UzExTaskAPI.Models
{
    public class BeatVM
    {
        public string BeaterId { get; set; }
        public decimal Price { get; set; }     
    }
}