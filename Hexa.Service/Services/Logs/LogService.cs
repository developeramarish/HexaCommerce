using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hexa.Business.Models.Logs;
using Hexa.Core.Data;
using Hexa.Core.Domain.Logs;
using Hexa.Service.Contracts.Logs;

namespace Hexa.Service.Services.Logs
{
    public class LogService : ILogService
    {
        #region Fields

        private readonly IHexaRepository<Log> _logRepository;

        #endregion

        #region Ctor

        public LogService(IHexaRepository<Log> logRepository)
        {
            _logRepository = logRepository;
        }

        #endregion

        #region Methods

        public Log GetLogById(int logId)
        {
            if (logId == 0)
                return null;

            return _logRepository.GetById(logId);
        }

        public void InsertLog(LogModel log)
        {
            if (log == null)
                throw new ArgumentNullException("Log");

            _logRepository.Insert(Mapper.Map<Log>(log));
        }

        public List<LogModel> GetAllLogs()
        {
            return Mapper.Map<List<LogModel>>(_logRepository.Table.ToList());

        }

        #endregion
    }
}
