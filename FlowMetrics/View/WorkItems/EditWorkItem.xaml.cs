using FlowMetrics.Domain.Interfaces;
using FlowMetrics.Domain.ViewModel.Assignee;
using FlowMetrics.Domain.ViewModel.Epic;
using FlowMetrics.Domain.ViewModel.Week;
using FlowMetrics.Domain.ViewModel.WorkItem;
using FlowMetrics.Work.Enums;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace FlowMetrics.View.WorkItems
{
    /// <summary>
    /// Lógica interna para EditJira.xaml
    /// </summary>
    public partial class EditWorkItem : Window
    {
        private readonly IWorkApplicationService _workApplicationService;
        private readonly IWeekApplicationService _weekApplicationService;
        private readonly IAssigneeApplicationService _assigneeApplicationService;
        private readonly IEpicApplicationService _epicApplicationService;

        private WorkItemViewModel _workItemViewModel;
        private CollectionView _weeks;

        public EditWorkItem(
            IWorkApplicationService workApplicationService,
            IWeekApplicationService weekApplicationService,
            IAssigneeApplicationService assigneeApplicationService,
            IEpicApplicationService epicApplicationService,
            WorkItemViewModel workItem)
        {
            _workApplicationService = workApplicationService;
            _weekApplicationService = weekApplicationService;
            _assigneeApplicationService = assigneeApplicationService;
            _epicApplicationService = epicApplicationService;
            _workItemViewModel = workItem;
            
            InitializeComponent();
            LoadData();

            DataContext = this;
            if (_workItemViewModel.Id.HasValue)
                DateStatusChanged.Focus();
            else
                IssueID.Focus();
        }

        private void LoadData()
        {
            LoadAllData();
            LoadWorkStatusList();

            IssueID.Text = _workItemViewModel.IssueId;            
            CbbStatus.SelectedItem = _workItemViewModel.Status;
            AcceptanceReleaseDate.SelectedDate = _workItemViewModel.AcceptanceReleaseDate;
            ProductionReleaseDate.SelectedDate = _workItemViewModel.ProductionReleaseDate;
            StartImpedimentAt.SelectedDate = _workItemViewModel.StartImpedimentDate;
            EndImpedimentAt.SelectedDate = _workItemViewModel.EndImpedimentDate;
            ImpObservation.Text = _workItemViewModel.Observations;            
            TechDebt.IsChecked = _workItemViewModel.TechDebt;
            DateStatusChanged.SelectedDate = _workItemViewModel.StatusDate;

            CbbEpic.SelectedItem = _workItemViewModel.Epic;
            CbbWeek.SelectedItem = _workItemViewModel.Week;
            CbbType.SelectedItem = _workItemViewModel.Type;
            CbbAssignee.SelectedItem = _workItemViewModel.Assignee;
            CbbTeam.SelectedItem = _workItemViewModel.Team;
        }

        private void LoadAllData()
        {
            var weeks = _weekApplicationService.GetAllOrderByDescending();
            var assignees = _assigneeApplicationService.GetAll();
            var teams = _assigneeApplicationService.GetAllTeams();
            var types = new List<WorkType> { WorkType.Bug, WorkType.Story, WorkType.Subtask, WorkType.Task };
            var epics = _epicApplicationService.GetAllOrderByDescending();
            var priorities = new List<Priority> { Priority.Blocker, Priority.Critical, Priority.Major, Priority.Minor, Priority.Trivial, Priority.Evaluating };

            _weeks = new CollectionView(weeks);

            CbbWeek.ItemsSource = _weeks;
            CbbAssignee.ItemsSource = new CollectionView(assignees);
            CbbTeam.ItemsSource = new CollectionView(teams);
            CbbEpic.ItemsSource = new CollectionView(epics);
            CbbType.ItemsSource = types;
            CbbTeam.SelectedItem = null;
            CbbPriority.ItemsSource = priorities;
        }

        private void LoadWorkStatusList()
        {
            var workStatusList = 
                new List<WorkStatus> { 
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

            CbbStatus.ItemsSource = workStatusList;
        }

        private bool FormIsValid()
        {
            if (_workItemViewModel.Id.HasValue)
            {
                if (CbbStatus.SelectedItem == null)
                {
                    MessageBox.Show("Please, select a status.", "Warning!");
                    return false;
                }
            }
            else
            {               
                if (string.IsNullOrEmpty(IssueID.Text))
                {
                    MessageBox.Show("Please, verify the issueID field.", "Warning!");
                    return false;
                }

                if (CbbWeek.SelectedItem == null)
                {
                    MessageBox.Show("Please, select a week.", "Warning!");
                    return false;
                }

                if (CbbType.SelectedItem == null)
                {
                    MessageBox.Show("Please, select a work type.", "Warning!");
                    return false;
                }

                if (CbbEpic.SelectedItem == null)
                {
                    MessageBox.Show("Please, select a Epic.", "Warning!");
                    return false;
                }

                if (DateStatusChanged.SelectedDate == null)
                {
                    MessageBox.Show("Please, select a date changed status.", "Warning!");
                    return false;
                }                
            }

            return true;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Update()
        {
            if (!FormIsValid())
                return;

            var team = CbbTeam.SelectedItem?.ToString();

            _workItemViewModel.IssueId = IssueID.Text;
            _workItemViewModel.Epic = (EpicViewModel)CbbEpic.SelectedItem ?? _workItemViewModel.Epic;
            _workItemViewModel.Week = (WeekViewModel)CbbWeek.SelectedItem ?? _workItemViewModel.Week;
            _workItemViewModel.Type = CbbType.SelectedItem != null ? (WorkType)CbbType.SelectedItem : _workItemViewModel.Type;
            _workItemViewModel.Status = (WorkStatus)CbbStatus.SelectedItem;
            _workItemViewModel.AcceptanceReleaseDate = AcceptanceReleaseDate.SelectedDate;
            _workItemViewModel.ProductionReleaseDate = ProductionReleaseDate.SelectedDate;
            _workItemViewModel.Assignee = (AssigneeViewModel)CbbAssignee.SelectedItem ?? _workItemViewModel.Assignee;
            _workItemViewModel.Team = _workItemViewModel.Assignee != null ? _workItemViewModel.Assignee.Team : team;
            _workItemViewModel.StartImpedimentDate = StartImpedimentAt.SelectedDate;
            _workItemViewModel.EndImpedimentDate = EndImpedimentAt.SelectedDate;
            _workItemViewModel.Observations = ImpObservation.Text;
            _workItemViewModel.TechDebt = TechDebt.IsChecked ?? false;
            _workItemViewModel.Priority = CbbPriority.SelectedItem != null ? (Priority)CbbPriority.SelectedItem : _workItemViewModel.Priority;

            _workItemViewModel.UpdatedBy = "master";
            _workItemViewModel.CreatedBy = "master";

            _workItemViewModel = _workApplicationService.CreateOrUpdate(_workItemViewModel, DateStatusChanged.SelectedDate);

            if (MessageBox.Show("Work item has updated, Do you want continue editing?", "Information.", MessageBoxButton.YesNo) == MessageBoxResult.No)
                Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Update();
            }
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
