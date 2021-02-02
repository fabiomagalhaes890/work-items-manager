using FlowMetrics.Domain.Filters.WorkItem;
using FlowMetrics.Domain.Interfaces;
using FlowMetrics.Work.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace FlowMetrics.View.Stocks
{
    /// <summary>
    /// Interação lógica para Stocks.xam
    /// </summary>
    public partial class Stocks : Page
    {
        private readonly IWorkApplicationService _workApplicationService;

        public Stocks(
            IWorkApplicationService workApplicationService)
        {
            _workApplicationService = workApplicationService;

            InitializeComponent();

            LoadFilters();
            ClearFilters();
        }

        private void LoadFilters()
        {            
            var types = new List<string> { "Bugs", "Technical debts" };
            CbbType.ItemsSource = new CollectionView(types);
        }

        private void ClearFilters()
        {
            StockItemSearch.Clear();
            CbbType.SelectedIndex = 0;

            var filters = GetFilters();
            LoadWorkItems(filters);
        }

        private FilterToWorkItem GetFilters()
        {
            var search = StockItemSearch.Text.Length >= 3 ? StockItemSearch.Text : string.Empty;
            var type = CbbType?.SelectedItem.ToString();

            var filter = new FilterToWorkItem
            {
                Search = search,
                TechDebt = type != "Bugs"
            };

            if(filter.TechDebt != true)
                filter.Type = WorkType.Bug;

            return filter;
        }

        private void LoadWorkItems(FilterToWorkItem filter)
        {
            var stockItems = _workApplicationService.GetStockItemsByFilter(filter);

            DataGridStockItem.ItemsSource = null;
            DataGridStockItem.ItemsSource = stockItems;

            ScreenTitle.Content = string.Format("Stock Items - amount activities: {0}", stockItems.Count());
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                ClearFilters();
            }
        }

        private void ClearFiltersbtn_Click(object sender, RoutedEventArgs e)
        {
            ClearFilters();
        }

        private void StockItemSearch_KeyUp(object sender, KeyEventArgs e)
        {
            var filters = GetFilters();
            LoadWorkItems(filters);
        }

        private void CbbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filters = GetFilters();
            LoadWorkItems(filters);
        }
    }
}
