using AutoMapper;
using Phusion2.Application.Extensions;
using Phusion2.Application.ViewModels;
using Phusion2.Domain.Models;

namespace Phusion2.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Profession, ProfessionViewModel>();
        }
    }
}
