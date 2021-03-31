using FlowMetrics.Domain.Interfaces;
using FlowMetrics.Domain.ViewModel.Week;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace FlowMetrics.View.Weeks
{
    /// <summary>
    /// Lógica interna para CreateWeek.xaml
    /// </summary>
    public partial class CreateWeek : Window
    {
        private readonly IWeekApplicationService _weekApplicationService;
        private WeekViewModel _week;
        public CreateWeek(
            IWeekApplicationService weekApplicationService,
            WeekViewModel week)
        {
            _weekApplicationService = weekApplicationService;
            _week = week;

            InitializeComponent();

            LoadWeek();
        }

        private void LoadWeek()
        {
            IncludeDate.SelectedDate = _week.Start;
            EndDate.SelectedDate = _week.End;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            WeekPersist();
        }

        private void WeekPersist()
        {
            if (IncludeDate.SelectedDate == null || EndDate.SelectedDate == null)
            {
                MessageBox.Show("The date fields never could be null.", "Warning!");
                return;
            }

            _week.Start = IncludeDate.SelectedDate.GetValueOrDefault();
            _week.End = EndDate.SelectedDate.GetValueOrDefault();

            _weekApplicationService.CreateOrUpdate(_week);
            MessageBox.Show("Week has created", "Information.");

            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                WeekPersist();
            }

            if(e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
