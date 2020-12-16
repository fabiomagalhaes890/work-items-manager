using AutoMapper;
using FlowMetrics.Domain.Configuration.AutoMapper;
using FlowMetrics.Domain.Interfaces;
using FlowMetrics.Domain.ViewModel.Week;
using FlowMetrics.Infra.Base;
using FlowMetrics.Work.Repositories;
using FlowMetrics.Work.Weeks;
using System.Collections.Generic;
using System.Linq;

namespace FlowMetrics.Domain.Services
{
    public class WeekApplicationService : IWeekApplicationService
    {
        private readonly ITransaction _transaction;
        private readonly IWeekRepository _weekRepository;
        private readonly IMapper _mapper;

        public WeekApplicationService(
            ITransaction transaction,
            IWeekRepository weekRepository)
        {
            _transaction = transaction;
            _weekRepository = weekRepository;

            var mappingConfig = AutoMapperConfiguration.RegisterMappings();
            _mapper = mappingConfig.CreateMapper();
        }

        public void Create(WeekViewModel model)
        {
            var workItem = _mapper.Map<Week>(model);
            workItem.SetDescription();

            _weekRepository.Add(workItem);

            _transaction.Commit();
        }

        public IEnumerable<WeekViewModel> GetAllOrderByDescending()
        {
            var result = _weekRepository.GetAll().ToList();
            var epics = _mapper.Map<IEnumerable<WeekViewModel>>(result);

            return epics.OrderByDescending(x => x.Start).ToList();
        }

        public IEnumerable<WeekViewModel> GetByFilter(string search)
        {
            var result = _weekRepository.GetAll().ToList();
            var epics = _mapper.Map<IEnumerable<WeekViewModel>>(result);

            return epics.Where(x => x.Description.Contains(search)).ToList();
        }
    }
}
