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
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            SaveNewWeek();
        }

        private void SaveNewWeek()
        {
            if (IncludeDate.SelectedDate == null || EndDate.SelectedDate == null)
            {
                MessageBox.Show("The date fields never could be null.", "Warning!");
                return;
            }

            var weeks = _weekApplicationService.GetAllOrderByDescending();
            var sequence = weeks.Max(x => x.Sequence) + 1;

            var week = new WeekViewModel
            {
                CreatedBy = "master",
                Start = IncludeDate.SelectedDate.GetValueOrDefault(),
                End = EndDate.SelectedDate.GetValueOrDefault(),
                Sequence = sequence
            };

            _weekApplicationService.Create(week);
            MessageBox.Show("Week has created", "Information.");

            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                SaveNewWeek();
            }

            if(e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
