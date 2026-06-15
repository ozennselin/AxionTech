using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Access.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
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
        _axionTechDB.SaveChanges();
        //_axionTechDB.Products.Add(product);
    }
    public void AddRange(List<TEntity> entities)
    {
        _dbSet.AddRange(entities);

        _axionTechDB.SaveChanges();
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();

        //return _axionTechDB.Products.AsNoTracking().AsQueryable();
        //AsNoTracking() => db de kilitlenmeyi önler
        //AsQueryable() => IQueryable türüne dönüştürür
    }
    public TEntity GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public  IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity,bool>> query)
    {
        //IQueryable
        //IEnumerable
        return _dbSet.Where(query).AsNoTracking().AsQueryable();
    }

    public TEntity GetEntityQuery(Expression<Func<TEntity, bool>> query)
    {
        return _dbSet.Where(query).FirstOrDefault();
    }

    public bool Any(Expression<Func<TEntity, bool>> query)
    {
        return _dbSet.Any(query);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
        _axionTechDB.SaveChanges();
    }

    public void Update(TEntity entity)
    {
       // _dbSet.Update(entity);
        _axionTechDB.SaveChanges();
    }

    public void UpdateRange(List<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);

        _axionTechDB.SaveChanges();
    }
}
