/*
 * File Name    : UpdateBatterySlotDto.cs
 * Description  : DTO for completely replacing the battery slot availability.
 * Author       : [Student Name]
 * IT Number    : [Student IT Number]
 * Date         : 2026-09-18
 */

using SmartGrid.API.Models;
using System.Collections.Generic;

namespace SmartGrid.API.DTOs.Microgrid
{
    public class UpdateBatterySlotDto
    {
        public List<BatterySlot> BatterySlots { get; set; } = new List<BatterySlot>();
    }
}
