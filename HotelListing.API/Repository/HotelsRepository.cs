﻿using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Data;

namespace HotelListing.API.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        public HotelsRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
