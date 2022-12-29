using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Entities;

namespace QuizApp.Respositories
{
    public class OptionRepository : IOptionRepository
    {
        private readonly QuizAppContext _dbContext;

        public OptionRepository(QuizAppContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Option> Get(int id)
        {
            return await _dbContext.Options.FindAsync(id);
        }

        public async Task<IEnumerable<Option>> GetAll()
        {
            return await _dbContext.Options.ToListAsync();
        }

        public async Task<Option> Insert(Option entity)
        {
            var valueTask = _dbContext.Options.Add(entity);
            await _dbContext.SaveChangesAsync();
            return valueTask.Entity;
        }

        public async Task Update(Option entityToUpdate)
        {
            _dbContext.Options.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Option> Delete(int id)
        {
            Option entityToDelete = await Get(id);
            if (entityToDelete == null)
            {
                return entityToDelete;
            }

            Option deletedEntity = Delete(entityToDelete);
            await _dbContext.SaveChangesAsync();
            return deletedEntity;
        }

        private Option Delete(Option entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbContext.Options.Attach(entityToDelete);
            }

            return _dbContext.Options.Remove(entityToDelete).Entity;
        }
    }
}
