using SeaBattle.Data.Context;
using System;
using System.Threading.Tasks;

namespace SeaBattle.Service.Base
{
    public abstract class ServiceBase
    {
        protected SeaBattleContext _dbContext;

        public ServiceBase(SeaBattleContext context)
        {
            _dbContext = context;
        }

        public virtual void Save()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task SaveAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
