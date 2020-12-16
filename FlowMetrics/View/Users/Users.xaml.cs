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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowMetrics.View.Users
{
    /// <summary>
    /// Interação lógica para Users.xam
    /// </summary>
    public partial class Users : Page
    {
        private readonly IAssigneeApplicationService _assigneeApplicationService;

        public Users(
            IAssigneeApplicationService assigneeApplicationService)
        {
            _assigneeApplicationService = assigneeApplicationService;

            InitializeComponent();

            LoadUsers();
        }

        private void LoadUsers()
        {
            var search = UserSearch.Text.Length >= 3 ? UserSearch.Text : string.Empty;

            var users = string.IsNullOrWhiteSpace(search) 
                ? _assigneeApplicationService.GetAll() 
                : _assigneeApplicationService.GetByFilter(search);

            DataGridUser.ItemsSource = null;
            DataGridUser.ItemsSource = users;
        }

        private void CreateNewUser()
        {
            var viewUser =
                new CreateUser(
                    _assigneeApplicationService,
                    new AssigneeViewModel());

            viewUser.ShowDialog();
        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F12)
            {
                CreateNewUser();
                LoadUsers();
            }
        }

        private void UserSearch_KeyUp(object sender, KeyEventArgs e)
        {
            LoadUsers();
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUser();
        }

        private void DataGridUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var user = (AssigneeViewModel)DataGridUser.SelectedItem;

            var viewUser =
                new CreateUser(
                    _assigneeApplicationService,
                    user);

            viewUser.ShowDialog();

            LoadUsers();
        }
    }
}
