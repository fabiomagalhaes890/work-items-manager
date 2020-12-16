using FlowMetrics.Domain.Interfaces;
using FlowMetrics.Domain.ViewModel.Epic;
using FlowMetrics.Work.Enums;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace FlowMetrics.View.Epics
{
    /// <summary>
    /// Lógica interna para CreateEpic.xaml
    /// </summary>
    public partial class CreateEpic : Window
    {
        private readonly IEpicApplicationService _epicApplicationService;

        private EpicViewModel _epic;

        public CreateEpic(
            IEpicApplicationService epicApplicationService,
            EpicViewModel epic)
        {
            _epicApplicationService = epicApplicationService;
            _epic = epic;

            InitializeComponent();

            UpdateView();
            LoadWorkStatusList();
        }

        private void UpdateView()
        {
            EpicName.Text = _epic.Description;
            EpicId.Text = _epic.EpicId;
            IsPrioritized.IsChecked = _epic.IsPrioritized;
            ConsiderTTM.IsChecked = _epic.ConsiderTTM;
            CbbStatus.SelectedItem = _epic.Status;
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                SaveNewEpic();
            }

            if(e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            SaveNewEpic();
        }

        private bool IsFormValid()
        {
            if (string.IsNullOrEmpty(EpicName.Text))
            {
                MessageBox.Show("The name not could be null.", "Warning!");
                return false;
            }

            if (string.IsNullOrEmpty(EpicId.Text))
            {
                MessageBox.Show("The Epic Id not could be null.", "Warning!");
                return false;
            }

            if (CbbStatus.SelectedItem == null)
            {
                MessageBox.Show("The status not could be null.", "Warning!");
                return false;
            }

            return true;
        }

        private void SaveNewEpic()
        {
            if(!IsFormValid())
                return;

            _epic.CreatedBy = "master";
            _epic.UpdatedBy = "master";
            _epic.Description = EpicName.Text;
            _epic.EpicId = EpicId.Text;
            _epic.IsPrioritized = IsPrioritized.IsChecked;
            _epic.ConsiderTTM = ConsiderTTM.IsChecked;
            _epic.Status = (WorkStatus?)CbbStatus.SelectedItem ?? _epic.Status;

            _epicApplicationService.Create(_epic);
            MessageBox.Show("Epic has saved", "Information.");

            Close();
        }
    }
}
