using AutoMapper;
using ShipmentTrackerAPI.Dtos;
using ShipmentTrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipmentTrackerAPI.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ShipmentTracking, ShipmentTrackingDto>();
            CreateMap<ShipmentTrackingDto, ShipmentTracking>();

            CreateMap<Characteristic, CharacteristicDto>();
            CreateMap<CharacteristicDto, Characteristic>();

            CreateMap<Checkpoint, CheckpointDto>();
            CreateMap<CheckpointDto, Checkpoint>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }
    }
}
