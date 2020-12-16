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
    /// Lógica interna para CreateDataJira.xaml
    /// </summary>
    public partial class CreateWorkItem : Window
    {
        private readonly IWorkApplicationService _workApplicationService;
        private readonly IAssigneeApplicationService _assigneeApplicationService;
        private readonly IWeekApplicationService _weekApplicationService;
        private readonly IEpicApplicationService _epicApplicationService;

        private WorkItemViewModel _workItemViewModel;

        public CreateWorkItem(
            IWorkApplicationService workApplicationService,
            IAssigneeApplicationService assigneeApplicationService,
            IWeekApplicationService weekApplicationService,
            IEpicApplicationService epicApplicationService)
        {
            _workApplicationService = workApplicationService;
            _assigneeApplicationService = assigneeApplicationService;
            _weekApplicationService = weekApplicationService;
            _epicApplicationService = epicApplicationService;

            InitializeComponent();

            GetDataScreen();

            DataContext = this;

            IssueID.Focus();
        }

        private void GetDataScreen()
        {
            var assignees = _assigneeApplicationService.GetAll();
            var epics = _epicApplicationService.GetAllOrderByDescending();
            var weeks = _weekApplicationService.GetAllOrderByDescending();

            var types = new List<WorkType> { WorkType.Bug, WorkType.Story, WorkType.Subtask, WorkType.Task };

            CbbWeek.ItemsSource = new CollectionView(weeks);
            CbbAssignee.ItemsSource = new CollectionView(assignees);
            CbbEpic.ItemsSource = new CollectionView(epics);
            CbbType.ItemsSource = types;
        }

        private bool FormIsValid()
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

            if (IncludeDate.SelectedDate == null)
            {
                MessageBox.Show("Please, select a date.", "Warning!");
                return false;
            }

            return true;
        }

        private void CreateNewWorkItem()
        {
            if (!FormIsValid())
                return;

            _workItemViewModel = new WorkItemViewModel
            {
                IssueId = IssueID.Text,
                Week = (WeekViewModel)CbbWeek.SelectedItem,
                Type = (WorkType)CbbType.SelectedItem,
                TechDebt = TechDebt.IsChecked ?? false,
                BacklogDate = IncludeDate.SelectedDate.Value,
                Assignee = (AssigneeViewModel)CbbAssignee.SelectedItem,
                AcceptanceReleaseDate = ReleaseDate.SelectedDate,
                Epic = (EpicViewModel)CbbEpic.SelectedItem,
                CreatedBy = "master"
            };

            _workApplicationService.CreateOrUpdate(_workItemViewModel, null);
            MessageBox.Show("Work item has created", "Information.");

            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateNewWorkItem();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                Close();
            }

            if(e.Key == Key.Enter)
            {
                CreateNewWorkItem();
            }
        }
    }
}
