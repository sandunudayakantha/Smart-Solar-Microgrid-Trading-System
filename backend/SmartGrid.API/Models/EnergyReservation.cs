/*
 * File Name    : EnergyReservation.cs
 * Description  : Dummy model needed to enforce the deactivation business rule for Microgrids.
 * Author       : [Student Name]
 * IT Number    : [Student IT Number]
 * Date         : 2026-09-18
 */

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartGrid.API.Models
{
    public class EnergyReservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string MicrogridId { get; set; } = string.Empty; // The grid being booked

        public string Status { get; set; } = "Active"; // We will build the full reservation logic in Member 3!
    }
}
