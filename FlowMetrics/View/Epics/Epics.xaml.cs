using FlowMetrics.Domain.Interfaces;
using FlowMetrics.Domain.ViewModel.Epic;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlowMetrics.View.Epics
{
    /// <summary>
    /// Interação lógica para Epics.xam
    /// </summary>
    public partial class Epics : Page
    {
        private readonly IEpicApplicationService _epicApplicationService;

        private IEnumerable<EpicViewModel> _epics;

        public Epics(IEpicApplicationService epicApplicationService)
        {
            _epicApplicationService = epicApplicationService;

            InitializeComponent();

            LoadEpics();
        }

        private void LoadEpics()
        {
            var search = EpicSearch.Text.Length >= 3 ? EpicSearch.Text : string.Empty;

            _epics = string.IsNullOrWhiteSpace(search) 
                ? _epicApplicationService.GetAllOrderByDescending() 
                : _epicApplicationService.GetByFilter(search);

            DataGridEpic.ItemsSource = null;
            DataGridEpic.ItemsSource = _epics;
        }

        private void EpicSearch_KeyUp(object sender, KeyEventArgs e)
        {
            var search = EpicSearch.Text.Length >= 3 ? EpicSearch.Text : string.Empty;
            LoadEpics();
        }

        private void DataGridEpic_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var epic = (EpicViewModel)DataGridEpic.SelectedItem;

            var createEpic = 
                new CreateEpic(
                    _epicApplicationService,
                    epic);

            createEpic.ShowDialog();

            LoadEpics();
        }

        private void CreateEpic_Click(object sender, RoutedEventArgs e)
        {
            CreateNewEpic();
        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F12)
            {
                CreateNewEpic();
            }
        }

        private void CreateNewEpic()
        {
            var epic =
               new CreateEpic(
                   _epicApplicationService,
                   new EpicViewModel());
            epic.ShowDialog();

            LoadEpics();
        }
    }
}
