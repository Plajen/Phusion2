using AutoMapper;
using Phusion2.Application.Extensions;
using Phusion2.Application.ViewModels;
using Phusion2.Domain.Models;

namespace Phusion2.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<ProfessionViewModel, Profession>();
        }
    }
}
