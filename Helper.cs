using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;


namespace EPSS
{
    public class DbContextHelper
    {
		DbContext _db;
		public DbContextHelper(DbContext db) {
			_db = db;
		}

        public void entryRollback(object entity)
        {
			EntityEntry entry = _db.Entry(entity);
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Modified:
                    entry.CurrentValues.SetValues(entry.OriginalValues);
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Unchanged;
                    break;
            }
        }

        public void tableRollback<TEntity>(ICollection<TEntity> table ) {
			foreach (object entity in table)
			entryRollback(entity);
		}


    }
}


