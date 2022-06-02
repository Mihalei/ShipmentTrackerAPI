using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShipmentTrackerAPI.Data;
using ShipmentTrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ShipmentTrackerAPI
{
    public static class SeedData
    {
        public static async Task InitializeAsync(ShipmentTrackingDbContext dbContext)
        {
            try
            {
                await dbContext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (!await dbContext.Characteristics.AnyAsync()) await SeedCharacteristicsAsync(dbContext);
            if (!await dbContext.Customers.AnyAsync()) await SeedCustomersAsync(dbContext);
            if (!await dbContext.Checkpoints.AnyAsync()) await SeedCheckpointsAsync(dbContext);
            if (!await dbContext.Orders.AnyAsync()) await SeedOrdersAsync(dbContext);
            if (!await dbContext.ShipmentTrackings.AnyAsync()) await SeedShipmentTrackingsAsync(dbContext);
        }

        private static async Task SeedCharacteristicsAsync(ShipmentTrackingDbContext dbContext)
        {
            for (int i = 0; i < 5; i++)
            {
                Characteristic c = new Characteristic();
                c.Name = $"Characteristic {i+1}";
                c.Value = $"Value {i+1}";
                dbContext.Characteristics.Add(c);
            }
            await dbContext.SaveChangesAsync();
        }

        private static async Task SeedCustomersAsync(ShipmentTrackingDbContext dbContext)
        {
            for (int i = 0; i < 5; i++)
            {
                Customer c = new Customer();
                c.Name = $"Customer {i + 1}";
                c.Href = $"Href {i + 1}";
                c.Description = $"Description {i + 1}";
                dbContext.Customers.Add(c);
            }
            await dbContext.SaveChangesAsync();
        }

        private static async Task SeedCheckpointsAsync(ShipmentTrackingDbContext dbContext)
        {
            for (int i = 0; i < 5; i++)
            {
                Checkpoint c = new Checkpoint();
                c.CheckPost = $"CheckPost {i + 1}";
                c.City = $"City {i + 1}";
                c.Country = $"Country {i + 1}";
                c.Date = DateTime.Now;
                c.Message = $"Message {i + 1}";
                c.StateOrProvince = $"State {i + 1}";
                c.Status = $"Status {i + 1}";
                c.Characteristics.AddRange(dbContext.Characteristics.Take(2).ToList());
                dbContext.Checkpoints.Add(c);
            }
            await dbContext.SaveChangesAsync();
        }

        private static async Task SeedOrdersAsync(ShipmentTrackingDbContext dbContext)
        {
            for (int i = 0; i < 5; i++)
            {
                Order o = new Order();
                o.Name = $"Order {i + 1}";
                o.Href = $"Href {i + 1}";
                o.ReferredType = $"ReferredType {i + 1}";
                dbContext.Orders.Add(o);
            }
            await dbContext.SaveChangesAsync();
        }

        private static async Task SeedShipmentTrackingsAsync(ShipmentTrackingDbContext dbContext)
        {
            for (int i = 0; i < 5; i++)
            {
                ShipmentTracking st = new ShipmentTracking();
                st.Status = ShipmentStatus.InProcess;
                st.Order = dbContext.Orders.Skip(i).Take(1).SingleOrDefault();
                st.RelatedCustomer = dbContext.Customers.Skip(i).Take(1).SingleOrDefault();
                st.StatusChangeDate = DateTime.Now;
                st.StatusChangeReason = $"Reason {i + 1}";
                st.TrackingCode = $"TrackingCode{i + 1}";
                st.TrackingDate = DateTime.Today;
                st.Weight = 100f*(i+1);
                st.EstimatedDeliveryDate = DateTime.Today.AddDays(i+1);
                st.CreateDate = DateTime.Today;
                st.Checkpoint = dbContext.Checkpoints.Skip(i).Take(1).SingleOrDefault();
                st.AddressFrom = $"AddressFrom {i + 1}";
                st.AddressTo = $"AddressTo {i + 1}";
                st.Carrier = $"Carrier {i + 1}";
                st.CarrierTrackingUrl = $"Url {i + 1}";
                st.Characteristics.AddRange(dbContext.Characteristics.Take(2).ToList());
                st.Href = $"Href {i + 1}";
                dbContext.ShipmentTrackings.Add(st);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
