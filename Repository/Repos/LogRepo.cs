using System;
using System.Threading.Tasks;
using logMiddlewareProject.Models;
using logMiddlewareProject.Repository.IRepo;

namespace logMiddlewareProject.Repository.Repo
{
    public class LogRepo : ILogRepo
    {
        private readonly DataBaseContext _context;
        public LogRepo(DataBaseContext db)
        {
            _context = db;
        }
        public async Task<bool> Create(log log)
        {
            log.created_at = DateTime.Now;
            await _context.logs.AddAsync(log);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> Get()
        {
            throw new NotImplementedException();
        }
    }
}