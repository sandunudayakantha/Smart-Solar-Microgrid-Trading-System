/*
 * File Name    : NodesController.cs
 * Description  : Thin API endpoints for managing Microgrid Nodes.
 * Author       : [Student Name]
 * IT Number    : [Student IT Number]
 * Date         : 2026-09-19
 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGrid.API.DTOs.Microgrid;
using SmartGrid.API.Services;
using System;
using System.Threading.Tasks;

namespace SmartGrid.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NodesController : ControllerBase
    {
        private readonly MicrogridService _microgridService;

        public NodesController(MicrogridService microgridService)
        {
            _microgridService = microgridService;
        }

        // POST /api/nodes
        [HttpPost]
        [Authorize(Roles = "BackOfficeUser")]
        public async Task<IActionResult> CreateNode([FromBody] CreateNodeDto dto)
        {
            try
            {
                var result = await _microgridService.CreateNodeAsync(dto);
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        // PATCH /api/nodes/{id}/schedule
        [HttpPatch("{id}/schedule")]
        [Authorize(Roles = "BackOfficeUser,GridOperator")]
        public async Task<IActionResult> UpdateSchedule(string id, [FromBody] UpdateScheduleDto dto)
        {
            var success = await _microgridService.UpdateScheduleAsync(id, dto);
            if (!success) return NotFound(new { success = false, message = "Node not found." });
            return Ok(new { success = true, message = "Schedule updated successfully." });
        }

        // PUT /api/nodes/{id}/battery-slots
        [HttpPut("{id}/battery-slots")]
        [Authorize(Roles = "GridOperator")]
        public async Task<IActionResult> UpdateBatterySlots(string id, [FromBody] UpdateBatterySlotDto dto)
        {
            var success = await _microgridService.UpdateBatterySlotsAsync(id, dto);
            if (!success) return NotFound(new { success = false, message = "Node not found." });
            return Ok(new { success = true, message = "Battery slots updated successfully." });
        }

        // DELETE /api/nodes/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "BackOfficeUser")]
        public async Task<IActionResult> DeactivateNode(string id)
        {
            try
            {
                var success = await _microgridService.DeactivateNodeAsync(id);
                if (!success) return NotFound(new { success = false, message = "Node not found." });
                return Ok(new { success = true, message = "Node successfully deactivated." });
            }
            catch (Exception ex)
            {
                // This catches our fatal "Active Reservations" business rule error!
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        // GET /api/nodes
        [HttpGet]
        public async Task<IActionResult> GetAllNodes()
        {
            var nodes = await _microgridService.GetAllNodesAsync();
            return Ok(new { success = true, data = nodes });
        }

        // GET /api/nodes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNodeById(string id)
        {
            var node = await _microgridService.GetNodeByIdAsync(id);
            if (node == null) return NotFound(new { success = false, message = "Node not found." });
            return Ok(new { success = true, data = node });
        }

        // GET /api/nodes/nearby
        [HttpGet("nearby")]
        public async Task<IActionResult> GetNearbyNodes([FromQuery] double lat, [FromQuery] double lng, [FromQuery] double radius = 5000)
        {
            var nodes = await _microgridService.GetNearbyNodesAsync(lat, lng, radius);
            return Ok(new { success = true, data = nodes });
        }
    }
}
