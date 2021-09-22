using AutoMapper;
using Phusion2.Application.Interfaces;
using Phusion2.Application.ViewModels;
using Phusion2.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phusion2.Application.Services
{
    public class ProfessionAppService : IProfessionAppService
    {
        private readonly IMapper _mapper;
        private readonly IProfessionRepository _professionRepository;

        public ProfessionAppService(IMapper mapper, IProfessionRepository professionRepository)
        {
            _mapper = mapper;
            _professionRepository = professionRepository;
        }

        public async Task<IEnumerable<ProfessionViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ProfessionViewModel>>(await _professionRepository.GetAsync());
        }

        public async Task<ProfessionViewModel> GetByIdAsync(int id)
        {
            return _mapper.Map<ProfessionViewModel>(await _professionRepository.GetOneAsync(x => x.Id == id));
        }
    }
}
