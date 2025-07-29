
using DDD.Domain.ViewModels;

namespace DDD.WinForm
{
    public partial class WeatherLatestViews : Form
    {
        private WeatherLatestViewModel _viewModel 
            = new WeatherLatestViewModel();


        public WeatherLatestViews()
        {
            InitializeComponent();

            // データバインディング
            this.AreaIdTextBox.DataBindings.Add("Text", _viewModel, nameof(_viewModel.AreaIdText));
            this.DataDateLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.DataDateText));
            this.ConditionLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.ConditionText));
            this.TemperatureLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.TemperatureText));
        }

        private void WeathreLatestViews_Load(object sender, EventArgs e)
        {

        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            _viewModel.Search();
        }
    }
}
