using System;
using System.Windows.Forms;
using WeatherApplication.ViewModels;

namespace WeatherApplication
{
    public partial class MainView : Form
    {
        #region Private Fields
        private readonly ForecastViewModel _forecastViewModel;
        #endregion

        #region Public Constructor
        public MainView()
        {
            InitializeComponent();

            _forecastViewModel = new ForecastViewModel();

            InitializeDataBindings();
        }
        #endregion

        #region Private Methods
        private void InitializeDataBindings()
        {
            // Location. 
            this.cityTextBox.DataBindings.Add("Text", this._forecastViewModel, "City", true);
            this.currentlySelectedCityLabel.DataBindings.Add("Text", this._forecastViewModel, "City", true);

            // Temperature. 
            this.temperatureNowLabel.DataBindings.Add("Text", this._forecastViewModel, "TemperatureNow", true);

            // Binding the Forecast Datagrid. 
            this.forecastDataGridView.DataBindings.Add("DataSource", this._forecastViewModel, "ForecastDatatable", true);
        }
        #endregion

        #region Event Handling
        private void GetWeatherDataButton_Click(object sender, EventArgs e)
        {
            // Check connection. 
            if (!_forecastViewModel.GetConnectionStatus())
            {
                MessageBox.Show($"Something went wrong. Data was not received properly!" +
                    $"{System.Environment.NewLine}See if you have a working internet connection." +
                    $"{System.Environment.NewLine}Also, try spell-checking your city name." +
                    $"{System.Environment.NewLine}Have a sunny day! :)",
                    "Something went wrong!");
            }
        }
        #endregion
    }
}