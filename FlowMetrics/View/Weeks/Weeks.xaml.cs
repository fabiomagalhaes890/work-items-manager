using FlowMetrics.Domain.Interfaces;
using FlowMetrics.Domain.ViewModel.Week;
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

namespace FlowMetrics.View.Weeks
{
    /// <summary>
    /// Interação lógica para Weeks.xam
    /// </summary>
    public partial class Weeks : Page
    {
        private readonly IWeekApplicationService _weekApplicationService;

        public Weeks(
            IWeekApplicationService weekApplicationService)
        {
            _weekApplicationService = weekApplicationService;

            InitializeComponent();

            LoadWeeks();
        }

        private void LoadWeeks()
        {
            var search = WeekSearch.Text.Length >= 3 ? WeekSearch.Text : string.Empty;

            var weeks = string.IsNullOrWhiteSpace(search) 
                ? _weekApplicationService.GetAllOrderByDescending() 
                : _weekApplicationService.GetByFilter(search);
            
            DataGridWeek.ItemsSource = null;
            DataGridWeek.ItemsSource = weeks;
        }

        private void NewWeek()
        {
            var week =
                new CreateWeek(
                    _weekApplicationService,
                    null);

            week.ShowDialog();

            LoadWeeks();
        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F12)
            {
                NewWeek();
            }
        }

        private void CreateWeek_Click(object sender, RoutedEventArgs e)
        {
            NewWeek();
        }

        private void WeekSearch_KeyUp(object sender, KeyEventArgs e)
        {
            LoadWeeks();
        }

        private void DataGridWeek_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var week = (WeekViewModel)DataGridWeek.SelectedItem;

            var createWeek = 
                new CreateWeek(
                    _weekApplicationService,
                    week);

            createWeek.ShowDialog();
            
            LoadWeeks();
        }
    }
}
