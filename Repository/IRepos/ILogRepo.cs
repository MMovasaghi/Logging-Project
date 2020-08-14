using System;
using System.Threading.Tasks;

namespace logMiddlewareProject.Repository.IRepo
{
    public interface ILogRepo
    {
        Task<bool> Create(Models.log log);
        Task<bool> Get();
    }
}