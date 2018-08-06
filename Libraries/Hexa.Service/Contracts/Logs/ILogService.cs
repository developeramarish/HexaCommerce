using Hexa.Business.Models.Logs;
using Hexa.Core.Domain.Logs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hexa.Service.Contracts.Logs
{
    public interface ILogService
    {
        Task<Log> GetLogById(int logId);

        Task InsertLog(LogModel log);

        Task<List<LogModel>> GetAllLogs();
    }
}
