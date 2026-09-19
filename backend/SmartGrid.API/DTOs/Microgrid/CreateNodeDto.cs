/*
 * File Name    : CreateNodeDto.cs
 * Description  : DTO for creating a new Solar Microgrid node.
 * Author       : [Student Name]
 * IT Number    : [Student IT Number]
 * Date         : 2026-09-18
 */

using SmartGrid.API.Models;
using System.Collections.Generic;

namespace SmartGrid.API.DTOs.Microgrid
{
    public class CreateNodeDto
    {
        public string NodeName { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double CapacityKWh { get; set; }
        public string Schedule { get; set; } = string.Empty;
        
        // Optional: Grid operators can seed initial slots when creating
        public List<BatterySlot> BatterySlots { get; set; } = new List<BatterySlot>();
    }
}
