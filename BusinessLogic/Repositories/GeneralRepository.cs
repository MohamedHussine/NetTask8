using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : BaseModel
    {
        Context _context;
        DbSet<T> _dbSet;
        public GeneralRepository(Context context) {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }
        //soft delated
        public async Task Delete(T entity)
        {
            var res =await GetByIdAsync(entity.ID);
            res.IsDeleted = true;
            _context.SaveChangesAsync();
            
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            var res = _dbSet.Where(x => !x.IsDeleted);
            return res;
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            // إضافة الـ Includes للطلب
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            // البحث بالـ ID مع التأكد أنه غير محذوف
            return await query.FirstOrDefaultAsync(x => x.ID == id && !x.IsDeleted);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChangesAsync();
        }
    }
}
