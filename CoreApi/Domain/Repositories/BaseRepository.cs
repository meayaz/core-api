namespace CoreApi.Domain.Repositories
{
    public class BaseRepository
    {
        protected readonly ShoppingContext context;

        public BaseRepository(ShoppingContext context)
        {
            this.context = context;
        }
    }
}