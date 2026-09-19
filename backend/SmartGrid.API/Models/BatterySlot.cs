/*
 * File Name    : BatterySlot.cs
 * Description  : Represents a time slot for charging/discharging batteries.
 * Author       : [Student Name]
 * IT Number    : [Student IT Number]
 * Date         : 2026-09-18
 */

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SmartGrid.API.Models
{
    public class BatterySlot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public DateTime Date { get; set; }
        
        public string StartTime { get; set; } = string.Empty; // e.g., "14:00"
        public string EndTime { get; set; } = string.Empty;   // e.g., "15:00"

        [BsonRepresentation(BsonType.String)]
        public BatterySlotStatus Status { get; set; } = BatterySlotStatus.Available;
    }
}
