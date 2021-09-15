using System.Threading.Tasks;

namespace Phusion2.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
