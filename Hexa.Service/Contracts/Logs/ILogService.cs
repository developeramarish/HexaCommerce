using Hexa.Business.Models.Logs;
using Hexa.Core.Domain.Logs;
using System.Collections.Generic;

namespace Hexa.Service.Contracts.Logs
{
    public interface ILogService
    {
        Log GetLogById(int logId);

        void InsertLog(LogModel log);

        List<LogModel> GetAllLogs();
    }
}
