using Phusion2.Application.Parameters;
using Phusion2.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phusion2.Application.Interfaces
{
    public interface IProfessionAppService
    {
        Task<IEnumerable<ProfessionViewModel>> GetAllAsync(ProfessionParams parameters);
        Task<ProfessionViewModel> GetByIdAsync(int id);
    }
}
