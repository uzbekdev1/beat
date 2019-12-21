using System;
using UzExTaskAPI.Models;
using UzExTaskAPI.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace UzExTaskAPI.Services
{
    public class BeatService
    {
        private readonly IMongoCollection<Beat> _beats;

        public BeatService(IMongoDBConnection options)
        {
            var client = new MongoClient(options.ConnectionString);
            var database = client.GetDatabase(options.DatabaseName);

            _beats = database.GetCollection<Beat>(options.CollectionName);
        }

        public List<Beat> Get() =>
            _beats.Find(beat => true).SortByDescending(c=>c.BeatTime).ToList();

        public Beat LastBeat() =>
            _beats.Find(beat => true).SortByDescending(c=>c.BeatTime).ToList().FirstOrDefault();

        public Beat Create(Beat beat)
        {            
            var lastBeat = _beats.Find(beat => true).SortByDescending(c=>c.BeatTime).ToList().FirstOrDefault();

            if(lastBeat == null || lastBeat.Price < beat.Price) 
            {
                _beats.InsertOne(beat);            
                return beat;
            }

            return null;
        }

    }
}