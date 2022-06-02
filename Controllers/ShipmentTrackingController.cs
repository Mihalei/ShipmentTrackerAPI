using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShipmentTrackerAPI.Data;
using ShipmentTrackerAPI.Dtos;
using ShipmentTrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipmentTrackerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipmentTrackingController : ControllerBase
    {
        private readonly ShipmentTrackingDbContext context;
        private readonly IMapper mapper;

        public ShipmentTrackingController(ShipmentTrackingDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetShipmentTracking([FromQuery] ShipmentTrackingQuery query)
        {
            if (CheckQueryOk(query) == false) return BadRequest();

            IQueryable<ShipmentTracking> shipmentTrackings = context.ShipmentTrackings;
            if (query.Status != null)
            {
                shipmentTrackings = shipmentTrackings.Where(st => ((int)st.Status) == query.Status.Value);
            }
            if (query.StartDate != null)
            {
                DateTime dateFrom = DateTime.Parse(query.StartDate);
                DateTime dateTo = DateTime.Parse(query.EndDate);
                shipmentTrackings = shipmentTrackings.Where(st => st.CreateDate.Date >= dateFrom.Date && st.CreateDate.Date <= dateTo.Date);
            }

            shipmentTrackings = shipmentTrackings
                .Include(st => st.Order)
                .Include(st => st.RelatedCustomer)
                .Include(st => st.Checkpoint)
                .Include(st => st.Characteristics)
                .AsNoTracking();

            List<ShipmentTracking> items = await shipmentTrackings.ToListAsync();

            if (items == null) return NotFound();

            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> PostShipmentTracking([FromBody] ShipmentTrackingDto dto)
        {
            try
            {
                ShipmentTracking newTracking = mapper.Map<ShipmentTracking>(dto);
                await context.ShipmentTrackings.AddAsync(newTracking);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipmentTrackingById([FromRoute] long id)
        {
            ShipmentTracking tracking = await context.ShipmentTrackings
                .Include(st => st.Order)
                .Include(st => st.RelatedCustomer)
                .Include(st => st.Checkpoint)
                .Include(st => st.Characteristics)
                .SingleOrDefaultAsync(st => st.Id == id);

            if (tracking == null) return NotFound();
            return Ok(mapper.Map<ShipmentTrackingDto>(tracking));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateShipmentTracking([FromRoute] long id, [FromBody] ShipmentTrackingDto dto)
        {
            ShipmentTracking tracking = await context.ShipmentTrackings
                .Include(st => st.Order)
                .Include(st => st.RelatedCustomer)
                .Include(st => st.Checkpoint)
                .Include(st => st.Characteristics)
                .SingleOrDefaultAsync(st => st.Id == id);

            if (tracking == null) return NotFound();

            ShipmentTracking update = mapper.Map<ShipmentTracking>(dto);
            if (update.Characteristics != null) tracking.Characteristics = update.Characteristics;
            if (update.AddressFrom != null) tracking.AddressFrom = update.AddressFrom;
            if (update.AddressTo != null) tracking.AddressTo = update.AddressTo;
            if (update.Carrier != null) tracking.Carrier = update.Carrier;
            if (update.CarrierTrackingUrl != null) tracking.CarrierTrackingUrl = update.CarrierTrackingUrl;
            if (update.Checkpoint != null) tracking.Checkpoint = update.Checkpoint;
            if (update.CreateDate != null) tracking.CreateDate = update.CreateDate;
            if (update.EstimatedDeliveryDate != null) tracking.EstimatedDeliveryDate = update.EstimatedDeliveryDate;
            if (update.Href != null) tracking.Href = update.Href;
            if (update.Order != null) tracking.Order = update.Order;
            if (update.RelatedCustomer != null) tracking.RelatedCustomer = update.RelatedCustomer;
            if (update.Status != null) tracking.Status = update.Status;
            if (update.StatusChangeDate != null) tracking.StatusChangeDate = update.StatusChangeDate;
            if (update.StatusChangeReason != null) tracking.StatusChangeReason = update.StatusChangeReason;
            if (update.TrackingCode != null) tracking.TrackingCode = update.TrackingCode;
            if (update.TrackingDate != null) tracking.TrackingDate = update.TrackingDate;
            if (update.Weight != null) tracking.Weight = update.Weight;

            try
            {
                context.ShipmentTrackings.Update(tracking);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
            return Ok();
        }

        private bool CheckQueryOk(ShipmentTrackingQuery query)
        {
            if (query == null) return false;
            if (query.StartDate == null && query.EndDate != null) return false;
            if (query.StartDate != null && query.EndDate == null) return false;
            if (query.Status == null && query.StartDate == null) return false;
            return true;
        }
    }
}
