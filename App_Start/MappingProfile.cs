using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradersPortal.Dtos;
using TradersPortal.Models;

namespace TradersPortal.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Trader, TraderDto>();
            Mapper.CreateMap<TraderDto, Trader>();






            Mapper.CreateMap<State, StateDto>();


        }
    }
}