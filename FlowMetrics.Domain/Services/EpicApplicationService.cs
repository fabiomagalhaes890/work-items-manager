using AutoMapper;
using FlowMetrics.Domain.Configuration.AutoMapper;
using FlowMetrics.Domain.Interfaces;
using FlowMetrics.Domain.ViewModel.Epic;
using FlowMetrics.Infra.Base;
using FlowMetrics.Work.Epics;
using FlowMetrics.Work.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowMetrics.Domain.Services
{
    public class EpicApplicationService : IEpicApplicationService
    {
        private readonly ITransaction _transaction;
        private readonly IEpicRepository _epicRepository;
        private readonly IMapper _mapper;

        public EpicApplicationService(
            ITransaction transaction,
            IEpicRepository epicRepository)
        {
            _transaction = transaction;
            _epicRepository = epicRepository;

            var mappingConfig = AutoMapperConfiguration.RegisterMappings();
            _mapper = mappingConfig.CreateMapper();
        }

        public void Create(EpicViewModel model)
        {
            var epic = _mapper.Map<Epic>(model);
            var result = _epicRepository.Find(epic.Id);

            if (result == null)
            {
                epic.CreatedBy = model.CreatedBy;
                epic.UpdatedAt = DateTime.Now;
                _epicRepository.Add(epic);
            }
            else
            {
                result.UpdatedBy = model.CreatedBy;

                if (string.IsNullOrWhiteSpace(result.EpicId))
                    result.SetEpicId(model.EpicId);

                result.SetStatus(model.Status);
                result.SetConsiderTTM(model.ConsiderTTM);
                result.SetIsPrioritized(model.IsPrioritized);                
                result.SetDescription(model.Description);

                _epicRepository.Update(result);
            }

            _transaction.Commit();
        }

        public IEnumerable<EpicViewModel> GetAllOrderByDescending()
        {
            var result = _epicRepository.GetAll().ToList();
            var epics = _mapper.Map<IEnumerable<EpicViewModel>>(result);

            return epics.OrderByDescending(x => x.CreatedAt).ToList();
        }

        public IEnumerable<EpicViewModel> GetByFilter(string search)
        {
            var result = _epicRepository.GetAll().ToList();
            var epics = _mapper.Map<IEnumerable<EpicViewModel>>(result);

            return epics.Where(x => x.Description.Contains(search)).ToList();
        }
    }
}
