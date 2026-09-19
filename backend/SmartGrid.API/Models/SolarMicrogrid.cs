/*
 * File Name    : SolarMicrogrid.cs
 * Description  : Represents a physical solar grid node with a GPS location.
 * Author       : [Student Name]
 * IT Number    : [Student IT Number]
 * Date         : 2026-09-18
 */

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace SmartGrid.API.Models
{
    public class SolarMicrogrid
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string NodeName { get; set; } = string.Empty;
        
        // Storing basic Lat/Lng for Google Maps integration on Mobile
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public double CapacityKWh { get; set; }
        
        public string Schedule { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;

        // Embedded Array of Battery Slots for blazing fast NoSQL reads
        public List<BatterySlot> BatterySlots { get; set; } = new List<BatterySlot>();
    }
}
