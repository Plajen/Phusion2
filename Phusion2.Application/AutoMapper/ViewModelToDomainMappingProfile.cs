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
            CreateMap<CustomerViewModel, Customer>()
                .ConstructUsing(c => new Customer(c.Id, c.FirstName, c.LastName, c.CPF.ToCleanCPF(),
                c.DateOfBirth, c.ProfessionId, null));
            CreateMap<ProfessionViewModel, Profession>();
        }
    }
}
