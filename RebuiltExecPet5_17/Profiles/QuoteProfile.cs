using AutoMapper;
using RebuiltExecPetAPI.MapModels;
using RebuiltExecPetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebuiltExecPet5_17.Models
{
    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            CreateMap<Quote, QuoteMap>();
            CreateMap<QuoteMap, Quote>();

            CreateMap<PetOwner, PetOwnerMap>()
                .ForMember(dest => dest.ConfirmEmail,
                opt => opt.MapFrom(src => src.Email));
            CreateMap<PetOwnerMap, PetOwner>();
        }
    }
}
