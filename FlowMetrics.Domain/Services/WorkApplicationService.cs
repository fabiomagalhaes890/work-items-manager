using AutoMapper;
using FlowMetrics.Domain.Configuration.AutoMapper;
using FlowMetrics.Domain.Filters.WorkItem;
using FlowMetrics.Domain.Interfaces;
using FlowMetrics.Domain.ViewModel.Week;
using FlowMetrics.Domain.ViewModel.WorkItem;
using FlowMetrics.Infra.Base;
using FlowMetrics.Work.Assignees;
using FlowMetrics.Work.Enums;
using FlowMetrics.Work.Epics;
using FlowMetrics.Work.Repositories;
using FlowMetrics.Work.Weeks;
using FlowMetrics.Work.WorkItems;
using FlowMetrics.Work.WorkToSheet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowMetrics.Domain.Services
{
    public class WorkApplicationService : IWorkApplicationService
    {
        private readonly ITransaction _transaction;
        private readonly IWorkRepository _workRepository;
        private readonly IAssigneeRepository _assigneeRepository;
        private readonly IEpicRepository _epicRepository;
        private readonly IWorkSheetRepository _workSheetRepository;
        private readonly IMapper _mapper;

        public WorkApplicationService(
            ITransaction transaction,
            IWorkRepository workRepository,
            IAssigneeRepository assigneeRepository,
            IEpicRepository epicRepository,
            IWorkSheetRepository workSheetRepository)
        {
            _transaction = transaction;
            _workRepository = workRepository;
            _assigneeRepository = assigneeRepository;
            _epicRepository = epicRepository;
            _workSheetRepository = workSheetRepository;

            var mappingConfig = AutoMapperConfiguration.RegisterMappings();
            _mapper = mappingConfig.CreateMapper();
        }

        public WorkItemViewModel CreateOrUpdate(WorkItemViewModel model, DateTime? dateChanged)
        {
            var workItem = _mapper.Map<WorkItem>(model);
            var result = _workRepository.Find(workItem.Id);

            if (result == null)
            {
                workItem.CreatedBy = model.CreatedBy;
                workItem.UpdatedAt = DateTime.Now;
                _workRepository.Add(workItem);

                if (dateChanged != null)
                    workItem = PutDateByStatus(workItem, dateChanged.GetValueOrDefault());

                var worksheet = CreateOrUpdateSerializable(workItem);
                _workSheetRepository.Add(worksheet);

                _transaction.Commit();

                var viewModel = _mapper.Map<WorkItemViewModel>(workItem);
                return viewModel;
            }
            else
            {
                result.UpdatedBy = model.CreatedBy;

                var week = _mapper.Map<Week>(model.Week);
                var assignee = _mapper.Map<Assignee>(model.Assignee);

                var team = assignee != null ? assignee.Team : model.Team;

                result.WeekId = week.Id;
                result.SetStatus(model.Status);
                result.SetType(model.Type);
                result.SetAcceptanceReleaseDate(model.AcceptanceReleaseDate);
                result.SetProductionReleaseDate(model.ProductionReleaseDate);
                result.SetStartImpedimentDate(model.StartImpedimentDate);
                result.SetEndImpedimentDate(model.EndImpedimentDate);
                result.SetObservations(model.Observations);
                result.SetTeam(team);
                result.AssigneeId = assignee?.Id;                

                if (dateChanged != null)
                    result = PutDateByStatus(result, dateChanged.GetValueOrDefault());

                _workRepository.Update(result);

                var worksheet = CreateOrUpdateSerializable(result);
                _workSheetRepository.Update(worksheet);

                _transaction.Commit();

                var viewModel = _mapper.Map<WorkItemViewModel>(result);
                return viewModel;
            }
        }

        private WorkSheet CreateOrUpdateSerializable(WorkItem workItem)
        {
            var result = _workSheetRepository.GetAll().FirstOrDefault(x => x.WorkItemId == workItem.Id) ?? new WorkSheet();

            result.IssueId = workItem.IssueId;
            result.Week = workItem.Week.Description;
            result.TechDebt = workItem.TechDebt ? "Yes" : "No";
            result.Assignee = workItem.Assignee?.Name;
            result.AssigneeTeam = workItem.Assignee?.Team;
            result.AcceptanceReleaseDate = workItem.AcceptanceReleaseDate?.ToString("dd/MM/yyyy");
            result.ProductionReleaseDate = workItem.ProductionReleaseDate?.ToString("dd/MM/yyyy");
            result.Epic = workItem.Epic.Description;
            result.BacklogDate = workItem.BacklogDate.ToString("dd/MM/yyyy");
            result.ToDoDate = workItem.ToDoDate?.ToString("dd/MM/yyyy");
            result.InProgressDate = workItem.InProgressDate?.ToString("dd/MM/yyyy");
            result.AwaitingCodeReviewDate = workItem.AwaitingCodeReviewDate?.ToString("dd/MM/yyyy");
            result.ReviewingDate = workItem.ReviewingDate?.ToString("dd/MM/yyyy");
            result.AwaitingTestsDate = workItem.AwaitingTestsDate?.ToString("dd/MM/yyyy");
            result.TestingDate = workItem.TestingDate?.ToString("dd/MM/yyyy");
            result.AwaitingAcceptanceTestsDate = workItem.AwaitingAcceptanceTestsDate?.ToString("dd/MM/yyyy");
            result.TestingInAcceptanceDate = workItem.TestingInAcceptanceDate?.ToString("dd/MM/yyyy");
            result.AwaitingProductionDate = workItem.AwaitingProductionDate?.ToString("dd/MM/yyyy");
            result.DoneDate = workItem.DoneDate?.ToString("dd/MM/yyyy");
            result.Type = workItem.Type.ToString();
            result.Status = workItem.Status.ToString();
            result.StartImpedimentDate = workItem.StartImpedimentDate?.ToString("dd/MM/yyyy");
            result.EndImpedimentDate = workItem.EndImpedimentDate?.ToString("dd/MM/yyyy");
            result.Observations = workItem.Observations;
            result.WorkItemId = workItem.Id;
            result.CreatedBy = "master";
            result.AssigneeTeam = workItem.Team;

            return result;
        }

        private WorkItem PutDateByStatus(WorkItem workItem, DateTime dateChanged)
        {
            if (workItem.Status == WorkStatus.Done)
                workItem.SetDoneDate(dateChanged);
            else if (workItem.Status == WorkStatus.AwaitingProduction)
                workItem.SetAwaitingProductionDate(dateChanged);
            else if (workItem.Status == WorkStatus.TestingInAcceptance)
                workItem.SetTestingInAcceptanceDate(dateChanged);
            else if (workItem.Status == WorkStatus.AwaitingAcceptanceTests)
                workItem.SetAwaitingAcceptanceTestDate(dateChanged);
            else if (workItem.Status == WorkStatus.Testing)
                workItem.SetTestingDate(dateChanged);
            else if (workItem.Status == WorkStatus.AwaitingTests)
                workItem.SetAwaitingTestsDate(dateChanged);
            else if (workItem.Status == WorkStatus.Reviewing)
                workItem.SetReviewingDate(dateChanged);
            else if (workItem.Status == WorkStatus.AwaitingCodeReview)
                workItem.SetAwaitingCodeReviewDate(dateChanged);
            else if (workItem.Status == WorkStatus.InProgress)
                workItem.SetInProgressDate(dateChanged);
            else if (workItem.Status == WorkStatus.ToDo)
                workItem.SetToDoDate(dateChanged);
            else if (workItem.Status == WorkStatus.Backlog)
                workItem.SetBacklogDate(dateChanged);

            return workItem;
        }

        public IEnumerable<WorkItemViewModel> GetWorkItemsByFilter(FilterToWorkItem filter)
        {
            var result = _workRepository.GetAll().ToList();

            if (!string.IsNullOrEmpty(filter.Search))
                result = result.Where(x => x.IssueId.Contains(filter.Search)).ToList();

            if (filter.Week != null)
            {
                var week = _mapper.Map<Week>(filter.Week);
                result = result.Where(x => x.WeekId == week.Id).ToList();
            }

            if (filter.Epic != null)
            {
                var epic = _mapper.Map<Epic>(filter.Epic);
                result = result.Where(x => x.EpicId == epic.Id).ToList();
            }

            if (filter.Type != null)
                result = result.Where(x => x.Type == filter.Type).ToList();

            if (filter.Status != null)
                result = result.Where(x => x.Status == filter.Status).ToList();

            if (filter.TechDebt != null)
                result = result.Where(x => x.TechDebt == filter.TechDebt).ToList();

            if (filter.Assignee != null)
            {
                var assignee = _mapper.Map<Assignee>(filter.Assignee);
                result = result.Where(x => x.AssigneeId == assignee.Id).ToList();
            }

            if (!string.IsNullOrWhiteSpace(filter.Team))
                result = result.Where(x => x.Team == filter.Team).ToList();

            result = result.Select(x =>
            {
                if (x.AssigneeId.HasValue)
                {
                    var assignee = _assigneeRepository.Find(x.AssigneeId.GetValueOrDefault());
                    x.SetAssignee(assignee);
                }

                var epic = _epicRepository.Find(x.EpicId);
                x.SetEpic(epic);

                return x;
            }).ToList();

            var workItems = _mapper.Map<IEnumerable<WorkItemViewModel>>(result);

            workItems = workItems.Select(x =>
            {
                x.StatusDate = GetStatusDate(x);
                return x;
            }).ToList();

            return workItems.OrderByDescending(x => x.UpdatedAt).ToList();
        }

        private DateTime? GetStatusDate(WorkItemViewModel workItem)
        {
            if (workItem.Status == WorkStatus.Done)
                return workItem.DoneDate;
            else if (workItem.Status == WorkStatus.AwaitingProduction)
                return workItem.AwaitingProductionDate;
            else if (workItem.Status == WorkStatus.TestingInAcceptance)
                return workItem.TestingInAcceptanceDate;
            else if (workItem.Status == WorkStatus.AwaitingAcceptanceTests)
                return workItem.AwaitingAcceptanceTestsDate;
            else if (workItem.Status == WorkStatus.Testing)
                return workItem.TestingDate;
            else if (workItem.Status == WorkStatus.AwaitingTests)
                return workItem.AwaitingTestsDate;
            else if (workItem.Status == WorkStatus.Reviewing)
                return workItem.ReviewingDate;
            else if (workItem.Status == WorkStatus.AwaitingCodeReview)
                return workItem.AwaitingCodeReviewDate;
            else if (workItem.Status == WorkStatus.InProgress)
                return workItem.InProgressDate;
            else if (workItem.Status == WorkStatus.ToDo)
                return workItem.ToDoDate;
            else if (workItem.Status == WorkStatus.Backlog)
                return workItem.BacklogDate;

            return null;
        }
    }
}
