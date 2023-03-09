namespace DDDValidationsDemo.Db
{
    public abstract class BaseRepository
    {
        protected DbStore Store;

        public BaseRepository(DbStore dbStore)
        {
            Store = dbStore;
        }
    }
}