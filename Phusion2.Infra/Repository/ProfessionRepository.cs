using Phusion2.Domain.Interfaces;
using Phusion2.Domain.Models;
using Phusion2.Infra.Context;

namespace Phusion2.Infra.Repository
{
    public class ProfessionRepository : BaseRepository<Profession>, IProfessionRepository
    {
        public ProfessionRepository(Phusion2Context context) : base(context)
        {

        }
    }
}
