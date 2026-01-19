using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Data.Access.Repositories;

public class Repository<TEntity> : IReporsitory<TEntity> where TEntity : class
{
    protected readonly AxionTechDB _axionTechDB;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(AxionTechDB axionTechDB)
    {
        _axionTechDB = axionTechDB;
        _dbSet=_axionTechDB.Set<TEntity>();
        //_dbSet = _axionTechDB.Products;
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);

        //_axionTechDB.Products.Add(product);
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();

        //return _axionTechDB.Products.AsNoTracking().AsQueryable();
        //AsNoTracking() => db de kilitlenmeyi önler
        //AsQueryable() => IQueryable türüne dönüştürür
    }
}
