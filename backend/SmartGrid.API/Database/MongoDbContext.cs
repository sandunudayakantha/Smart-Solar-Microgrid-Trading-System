/*
 * File Name    : MongoDbContext.cs
 * Description  : Handles the connection to the MongoDB database and exposes collections.
 * Author       : [Student Name]
 * IT Number    : [Student IT Number]
 * Date         : 2026-09-18
 */

using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SmartGrid.API.Models;

namespace SmartGrid.API.Database
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        // Initializes the MongoDB connection using the configuration settings.
        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("MONGO_URI");
            var databaseName = Environment.GetEnvironmentVariable("MONGO_DB_NAME");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        // Expose the Users collection (this will store Prosumers, Grid Operators, etc.)
        public IMongoCollection<User> Users => _database.GetCollection<User>("users");
        
        // Member 2: Microgrid Node & Location Services
        public IMongoCollection<SolarMicrogrid> SolarMicrogrids => _database.GetCollection<SolarMicrogrid>("SolarMicrogrids");
        
        // Member 3: Reservation & Booking Management (Stub for Member 2)
        public IMongoCollection<EnergyReservation> EnergyReservations => _database.GetCollection<EnergyReservation>("EnergyReservations");
    }
}
