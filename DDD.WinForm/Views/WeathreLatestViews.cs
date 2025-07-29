
using DDD.Domain.Entities;
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
            // --不正の値の入力を防ぐためドロップダウンリストに設定
            this.AreasComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AreasComboBox.DataBindings.Add("SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId));
            this.AreasComboBox.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.Areas));
            // --コンボボックスの表示はエリア名、valueはエリアId
            this.AreasComboBox.ValueMember = nameof(AreaEntity.AreaId);
            this.AreasComboBox.DisplayMember = nameof(AreaEntity.AreaName);

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
