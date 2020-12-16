using AutoMapper;
using FlowMetrics.Domain.Configuration.AutoMapper;
using FlowMetrics.Domain.Interfaces;
using FlowMetrics.Domain.ViewModel.Assignee;
using FlowMetrics.Infra.Base;
using FlowMetrics.Work.Assignees;
using FlowMetrics.Work.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FlowMetrics.Domain.Services
{
    public class AssigneeApplicationService : IAssigneeApplicationService
    {
        private readonly ITransaction _transaction;
        private readonly IAssigneeRepository _assigneeRepository;
        private readonly IMapper _mapper;

        public AssigneeApplicationService(
            ITransaction transaction,
            IAssigneeRepository assigneeRepository)
        {
            _transaction = transaction;
            _assigneeRepository = assigneeRepository;

            var mappingConfig = AutoMapperConfiguration.RegisterMappings();
            _mapper = mappingConfig.CreateMapper();
        }

        public IEnumerable<AssigneeViewModel> GetAll()
        {
            var result = _assigneeRepository.GetAll().ToList();
            var assignees = _mapper.Map<IEnumerable<AssigneeViewModel>>(result);

            return assignees.OrderBy(x => x.Name);
        }

        public IEnumerable<string> GetAllTeams()
        {
            var result = _assigneeRepository.GetAll().ToList();

            var teams = result.Select(x => x.Team).Distinct().ToList();

            return teams.OrderBy(x => x).ToList();
        }

        public IEnumerable<AssigneeViewModel> GetByFilter(string search)
        {
            var result = _assigneeRepository.GetAll().ToList();
            var assignees = _mapper.Map<IEnumerable<AssigneeViewModel>>(result);

            return assignees.Where(x => x.Name.Contains(search));
        }

        public void Create(AssigneeViewModel model)
        {
            var assignee = _mapper.Map<Assignee>(model);
            _assigneeRepository.Add(assignee);

            _transaction.Commit();
        }
    }
}
