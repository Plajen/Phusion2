using AutoMapper;
using Phusion2.Application.Extensions;
using Phusion2.Application.Interfaces;
using Phusion2.Application.Parameters;
using Phusion2.Application.ViewModels;
using Phusion2.Domain.Interfaces;
using Phusion2.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phusion2.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProfessionAppService _professionAppService;

        public CustomerAppService(
            IMapper mapper, 
            ICustomerRepository customerRepository, 
            IUnitOfWork unitOfWork,
            IProfessionAppService professionAppService)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _professionAppService = professionAppService;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAsync(CustomerParams cParams)
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository
                .GetAsync(cParams.Filter(), cParams.Skip, cParams.Take, cParams.OrderBy, cParams.Include));
        }

        public async Task<int> GetCountAsync(CustomerParams cParams)
        {
            return await _customerRepository.GetCountAsync(cParams.Filter());
        }

        public async Task<CustomerViewModel> GetByIdAsync(int id)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetByIdAsync(id));
        }

        public async Task<CustomerViewModel> RegisterAsync(CustomerViewModel request)
        {
            if (request.RegistryIsValid())
            {
                var customer = _mapper.Map<Customer>(request);
                customer.Profession = _mapper
                    .Map<Profession>(_professionAppService.GetByIdAsync((int)request.ProfessionId));

                customer = _customerRepository.Create(customer);
                await _unitOfWork.Commit();

                return _mapper.Map<CustomerViewModel>(customer);
            }
            else
                return null;
        }

        public async Task<CustomerViewModel> UpdateAsync(CustomerViewModel request)
        {
            if (request.UpdateIsValid())
            {
                var customer = _customerRepository.GetByIdAsync(request.Id).Result;

                if (customer == null)
                    return null;

                customer = new Customer(
                    request.Id,
                    request.FirstName,
                    request.LastName,
                    request.CPF.ToCleanCPF(),
                    request.DateOfBirth,
                    request.ProfessionId,
                    _mapper.Map<Profession>(request.Profession));

                customer = _customerRepository.Update(customer);
                await _unitOfWork.Commit();

                return _mapper.Map<CustomerViewModel>(customer);
            }
            else
                return null;
        }

        public async Task<int> RemoveAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return 0;

            if (_mapper.Map<CustomerViewModel>(customer).RemovalIsValid())
                _customerRepository.DeleteById(id);

            return customer.Id;
        }
    }
}
