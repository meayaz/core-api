using System.Threading.Tasks;

namespace CoreApi.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ShoppingContext context;

        public UnitOfWork(ShoppingContext context)
        {
            this.context = context;
        }

        public void Complete()
        {
            this.context.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}