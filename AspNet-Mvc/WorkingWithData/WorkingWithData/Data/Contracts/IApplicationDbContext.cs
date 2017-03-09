using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WorkingWithData.Models;

namespace WorkingWithData.Data.Contracts
{
    public interface IApplicationDbContext
    {
        IDbSet<Tweet> Tweets { get; set; }

        IDbSet<User> Users { get; set; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void SaveChanges();
    }
}