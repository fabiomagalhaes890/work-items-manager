using FlowMetrics.Domain.Interfaces;
using FlowMetrics.Domain.ViewModel.Week;
using FlowMetrics.Domain.ViewModel.WorkItem;
using FlowMetrics.View;
using FlowMetrics.View.Epics;
using FlowMetrics.View.Stocks;
using FlowMetrics.View.Users;
using FlowMetrics.View.Weeks;
using FlowMetrics.View.WorkItems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace FlowMetrics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IWorkApplicationService _workApplicationService;
        private readonly IWeekApplicationService _weekApplicationService;
        private readonly IEpicApplicationService _epicApplicationService;
        private readonly IAssigneeApplicationService _assigneeApplicationService;
        
        public MainWindow(
            IWorkApplicationService workApplicationService,
            IWeekApplicationService weekApplicationService,
            IEpicApplicationService epicApplicationService,
            IAssigneeApplicationService assigneeApplicationService)
        {
            _workApplicationService = workApplicationService;
            _weekApplicationService = weekApplicationService;
            _epicApplicationService = epicApplicationService;
            _assigneeApplicationService = assigneeApplicationService;

            InitializeComponent();
        }

        private void tv_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selected = (e.Source as TreeView).SelectedItem as TreeViewItem;
            var header = selected.Header.ToString();

            if (header == "Work items")
            {
                ContentArea.Content =
                    new WorkItems(
                        _workApplicationService, 
                        _weekApplicationService, 
                        _epicApplicationService, 
                        _assigneeApplicationService);
            }

            if (header == "Epics")
            {
                ContentArea.Content =
                    new Epics(_epicApplicationService);
            }

            if (header == "Weeks")
            {
                ContentArea.Content =
                    new Weeks(_weekApplicationService);
            }

            if (header == "Users")
            {
                ContentArea.Content =
                    new Users(_assigneeApplicationService);
            }

            if (header == "Stocks")
            {
                ContentArea.Content =
                    new Stocks(_workApplicationService);
            }            
        }
    }
}
