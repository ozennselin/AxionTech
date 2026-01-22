namespace Data.Access.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAll();
    //IEnumerable<TEntity> GetAllEnum();
    //List<TEntity> GetAllList();
    //Task<IQueryable<TEntity>> GetAllAsync();

    void Add(TEntity entity);
    //Task AddAsync(TEntity entity);

}
