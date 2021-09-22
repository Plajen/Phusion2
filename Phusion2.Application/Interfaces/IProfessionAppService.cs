using Phusion2.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phusion2.Application.Interfaces
{
    public interface IProfessionAppService
    {
        Task<IEnumerable<ProfessionViewModel>> GetAllAsync();
        Task<ProfessionViewModel> GetByIdAsync(int id);
    }
}
