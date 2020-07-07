using System.Threading.Tasks;

namespace CoreApi.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();

        void Complete();
    }
}