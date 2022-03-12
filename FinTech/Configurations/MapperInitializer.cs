using AutoMapper;
using FinTech.Data;
using FinTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Contribution, ContributionDTO>().ReverseMap();
            CreateMap<Contribution, CreateContributionDTO>().ReverseMap();
            CreateMap<ContributionType, ContributionTypeDTO>().ReverseMap();
            CreateMap<ContributionType, CreateContributionTypeDTO>().ReverseMap();
            CreateMap<Customer, UserDTO>().ReverseMap();
        }
    }
}
