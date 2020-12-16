using FlowMetrics.Domain.Interfaces;
using FlowMetrics.Domain.ViewModel.Assignee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlowMetrics.View.Users
{
    /// <summary>
    /// Lógica interna para CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        private readonly IAssigneeApplicationService _assigneeApplicationService;

        private AssigneeViewModel _assigneeViewModel;

        public CreateUser(
            IAssigneeApplicationService assigneeApplicationService,
            AssigneeViewModel assigneeViewModel)
        {
            _assigneeApplicationService = assigneeApplicationService;
            _assigneeViewModel = assigneeViewModel;

            InitializeComponent();

            UpdateView();
            LoadTeam();
        }

        private void UpdateView()
        {
            UserName.Text = _assigneeViewModel.Name;
        }

        private void LoadTeam()
        {
            var teams = new List<string> { "Beckstreet Beers", "Ursinhos Colorados" };

            CbbTeam.ItemsSource = null;
            CbbTeam.ItemsSource = new CollectionView(teams);
        }

        private void CreateNewUser()
        {
            if(CbbTeam.SelectedItem == null)
            {
                MessageBox.Show("Please, select a team", "Warning!");
                return;
            }

            _assigneeViewModel.Name = UserName.Text;
            _assigneeViewModel.Team = CbbTeam.SelectedItem.ToString();
            _assigneeViewModel.CreatedBy = "master";

            _assigneeApplicationService.Create(_assigneeViewModel);

            Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUser();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                CreateNewUser();
            }
            
            if(e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
