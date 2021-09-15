using Phusion2.Domain.Interfaces;
using Phusion2.Infra.Context;
using System.Threading.Tasks;

namespace Phusion2.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Phusion2Context _context;

        public UnitOfWork(Phusion2Context context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
