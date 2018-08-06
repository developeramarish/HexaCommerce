using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hexa.Business.Models.Logs;
using Hexa.Core.Data;
using Hexa.Core.Domain.Logs;
using Hexa.Service.Contracts.Logs;
using Microsoft.EntityFrameworkCore;

namespace Hexa.Service.Services.Logs
{
    public class LogService : ILogService
    {
        #region Fields

        private readonly IHexaRepository<Log> _logRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public LogService(IHexaRepository<Log> logRepository,
            IMapper mapper)
        {
            _logRepository = logRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<Log> GetLogById(int logId)
        {
            if (logId == 0)
                return null;

            return await _logRepository.GetById(logId);
        }

        public async Task InsertLog(LogModel log)
        {
            if (log == null)
                throw new ArgumentNullException("Log");

            await _logRepository.Insert(_mapper.Map<Log>(log));
        }

        public async Task<List<LogModel>> GetAllLogs()
        {
            return _mapper.Map<List<LogModel>>(await _logRepository.Table.ToListAsync());

        }

        #endregion
    }
}
