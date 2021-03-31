using FlowMetrics.Domain.Filters.WorkItem;
using FlowMetrics.Domain.Interfaces;
using FlowMetrics.Domain.ViewModel.Assignee;
using FlowMetrics.Domain.ViewModel.Epic;
using FlowMetrics.Domain.ViewModel.Week;
using FlowMetrics.Domain.ViewModel.WorkItem;
using FlowMetrics.Work.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace FlowMetrics.View.WorkItems
{
    /// <summary>
    /// Interação lógica para WorkItems.xam
    /// </summary>
    public partial class WorkItems : Page
    {
        private readonly IWorkApplicationService _workApplicationService;
        private readonly IWeekApplicationService _weekApplicationService;
        private readonly IEpicApplicationService _epicApplicationService;
        private readonly IAssigneeApplicationService _assigneeApplicationService;

        private WorkItemViewModel _workItem;
        private IEnumerable<WorkItemViewModel> _workItems;

        public WorkItems(
            IWorkApplicationService workApplicationService,
            IWeekApplicationService weekApplicationService,
            IEpicApplicationService epicApplicationService,
            IAssigneeApplicationService assigneeApplicationService)
        {
            _workApplicationService = workApplicationService;
            _weekApplicationService = weekApplicationService;
            _epicApplicationService = epicApplicationService;
            _assigneeApplicationService = assigneeApplicationService;

            _workItems = new List<WorkItemViewModel>();

            InitializeComponent();

            LoadFilters();
            ClearFilters();
        }

        private void LoadWorkItems(FilterToWorkItem filter)
        {
            _workItems = _workApplicationService.GetWorkItemsByFilter(filter);

            DataGridWorkItem.ItemsSource = null;
            DataGridWorkItem.ItemsSource = _workItems;

            ScreenTitle.Content = string.Format("Work Items - amount activities: {0}", _workItems.Count());
        }

        private void LoadFilters()
        {
            var weeks = _weekApplicationService.GetAllOrderByDescending();
            CbbWeek.ItemsSource = new CollectionView(weeks);

            var epics = _epicApplicationService.GetAllOrderByDescending();
            CbbEpic.ItemsSource = new CollectionView(epics);

            var types = new List<WorkType> { WorkType.Bug, WorkType.Story, WorkType.Subtask, WorkType.Task };
            CbbType.ItemsSource = new CollectionView(types);


            var status = new List<WorkStatus> { 
                WorkStatus.Backlog,
                WorkStatus.ToDo,
                WorkStatus.InProgress,
                WorkStatus.AwaitingCodeReview,
                WorkStatus.Reviewing,
                WorkStatus.AwaitingTests,
                WorkStatus.Testing,
                WorkStatus.AwaitingAcceptanceTests,
                WorkStatus.TestingInAcceptance,
                WorkStatus.AwaitingProduction,
                WorkStatus.Done
            };
            CbbStatus.ItemsSource = new CollectionView(status);

            var assignees = _assigneeApplicationService.GetAll();
            CbbAssignee.ItemsSource = new CollectionView(assignees);

            var teams = _assigneeApplicationService.GetAllTeams();
            CbbTeam.ItemsSource = new CollectionView(teams);
        }

        private void ClearFilters()
        {
            WorkItemSearch.Clear();
            CbbWeek.SelectedItem = null;
            CbbEpic.SelectedItem = null;
            CbbType.SelectedItem = null;
            CbbStatus.SelectedItem = null;
            CbbAssignee.SelectedItem = null;
            CbbTeam.SelectedItem = null;
            TechDebt.IsChecked = null;

            var filters = GetFilters();
            LoadWorkItems(filters);
        }

        private void NewWorkItem_Click(object sender, RoutedEventArgs e)
        {
            NewItem();
        }

        private void NewItem()
        {
            var editWorkItem =
                    new EditWorkItem(
                        _workApplicationService,
                        _weekApplicationService,
                        _assigneeApplicationService,
                        _epicApplicationService,
                        new WorkItemViewModel());

            editWorkItem.ShowDialog();

            var filters = GetFilters();
            LoadWorkItems(filters);

            WorkItemSearch.Focus();
        }

        private void DataGridWorkItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _workItem = (WorkItemViewModel)DataGridWorkItem.SelectedItem;

            if (_workItem != null)
            {
                var editWorkItem =
                    new EditWorkItem(
                        _workApplicationService,
                        _weekApplicationService,
                        _assigneeApplicationService,
                        _epicApplicationService,
                        _workItem);

                editWorkItem.ShowDialog();

                var filters = GetFilters();
                LoadWorkItems(filters);

                WorkItemSearch.Focus();
            }
        }

        private FilterToWorkItem GetFilters()
        {
            var search = WorkItemSearch.Text.Length >= 3 ? WorkItemSearch.Text : string.Empty;
            var week = (WeekViewModel)CbbWeek.SelectedItem;
            var epic = (EpicViewModel)CbbEpic.SelectedItem;
            var type = (WorkType?)CbbType.SelectedItem;
            var status = (WorkStatus?)CbbStatus.SelectedItem;
            var assignee = (AssigneeViewModel)CbbAssignee.SelectedItem;
            var team = CbbTeam.SelectedItem?.ToString();
            var techDebt = TechDebt.IsChecked;

            var filter = new FilterToWorkItem
            {
                Search = search,
                Week = week,
                Epic = epic,
                Type = type,
                Status = status,
                Assignee = assignee,
                Team = team,
                TechDebt = techDebt
            };

            return filter;
        }

        private void WorkItemSearch_KeyUp(object sender, KeyEventArgs e)
        {
            var filters = GetFilters();
            LoadWorkItems(filters);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F12)
            {
                NewItem();
            }
            if (e.Key == Key.F5)
            {
                ClearFilters();
            }
        }

        private void CbbWeek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filters = GetFilters();
            LoadWorkItems(filters);
        }

        private void CbbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filters = GetFilters();
            LoadWorkItems(filters);
        }

        private void CbbEpic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filters = GetFilters();
            LoadWorkItems(filters);
        }

        private void CbbTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filters = GetFilters();
            LoadWorkItems(filters);
        }

        private void CbbAssignee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filters = GetFilters();
            LoadWorkItems(filters);
        }

        private void CbbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filters = GetFilters();
            LoadWorkItems(filters);
        }

        private void ClearFilters_Click(object sender, RoutedEventArgs e)
        {
            ClearFilters();
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            var filters = GetFilters();
            LoadWorkItems(filters);
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            var filters = GetFilters();
            LoadWorkItems(filters);
        }

        private void HandleThirdState(object sender, RoutedEventArgs e)
        {
            var filters = GetFilters();
            filters.TechDebt = null;

            LoadWorkItems(filters);
        }

        private void DataGridWorkItem_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            _workItem = (WorkItemViewModel)DataGridWorkItem.SelectedItem;

            if (_workItem != null)
            {
                if (MessageBox.Show(string.Format("Would you like delete work item {0}?", _workItem.IssueId), "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {                
                    _workApplicationService.DeleteWorkItem(_workItem.Id);

                    var filters = GetFilters();
                    filters.TechDebt = null;

                    LoadWorkItems(filters);
                }
            }
        }
    }
}
