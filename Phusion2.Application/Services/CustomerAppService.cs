using AutoMapper;
using Phusion2.Application.Extensions;
using Phusion2.Application.Interfaces;
using Phusion2.Application.Parameters;
using Phusion2.Application.ViewModels;
using Phusion2.Domain.Core.Bus;
using Phusion2.Domain.Core.Notifications;
using Phusion2.Domain.Interfaces;
using Phusion2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Phusion2.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediatorHandler _bus;

        public CustomerAppService(
            IMapper mapper, 
            ICustomerRepository customerRepository, 
            IUnitOfWork unitOfWork,
            IMediatorHandler mediatorHandler)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _bus = mediatorHandler;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAsync(CustomerParams cParams)
        {
            Expression<Func<Customer, bool>> filter = cParams.AllNull ? null : cParams.Filter();

            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository
                .GetAsync(filter, cParams.Skip, cParams.Take, cParams.OrderBy, cParams.Include));
        }

        public async Task<int> GetCountAsync(CustomerParams cParams)
        {
            return await _customerRepository.GetCountAsync(cParams.Filter());
        }

        public async Task<CustomerViewModel> GetByIdAsync(int id)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetOneAsync(x => x.Id == id, "Profession"));
        }

        public async Task<CustomerViewModel> RegisterAsync(CustomerViewModel request)
        {
            if (request.RegistryIsValid())
            {
                var customer = _mapper.Map<Customer>(request);

                customer = _customerRepository.Create(customer);

                if (!_unitOfWork.Commit())
                {
                    await _bus.RaiseEvent(new DomainNotification("Erro", "Não foi possível criar o cliente, tente novamente mais tarde"));
                }

                return _mapper.Map<CustomerViewModel>(customer);
            }
            else
                return null;
        }

        public async Task<CustomerViewModel> UpdateAsync(CustomerViewModel request)
        {
            if (request.UpdateIsValid())
            {
                var customer = await _customerRepository.GetOneAsync(x => x.Id == request.Id, "Profession");

                if (customer == null)
                    return null;

                customer = new Customer(
                    request.Id,
                    request.FirstName,
                    request.LastName,
                    request.CPF.ToCleanCPF(),
                    request.DateOfBirth,
                    request.ProfessionId);

                customer = _customerRepository.Update(customer);

                if (!_unitOfWork.Commit())
                {
                    await _bus.RaiseEvent(new DomainNotification("Erro", "Não foi possível atualizar o cliente, tente novamente mais tarde"));
                }

                return _mapper.Map<CustomerViewModel>(customer);
            }
            else
                return null;
        }

        public async Task<int> RemoveAsync(int id)
        {
            var customer = await _customerRepository.GetOneAsync(x => x.Id == id, "Profession");
            if (customer == null)
                return 0;

            if (_mapper.Map<CustomerViewModel>(customer).RemovalIsValid())
                _customerRepository.DeleteById(id);

            if (!_unitOfWork.Commit())
            {
                await _bus.RaiseEvent(new DomainNotification("Id", "Não foi possível remover o cliente, tente novamente mais tarde"));
            }

            return customer.Id;
        }
    }
}
