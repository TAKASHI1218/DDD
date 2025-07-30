
using DDD.Domain.Entities;
using DDD.Domain.ViewModels;
using DDD.WinForm.Views;

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

        /// <summary>
        /// ボタン桜花で指定エリアのデータを表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LatestButton_Click(object sender, EventArgs e)
        {
            _viewModel.Search();
        }

        /// <summary>
        /// ボダン押下で一覧画面を表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            using (var f = new WeatherListView())
            {
                f.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var f = new WeatherSaveView())
            {
                f.ShowDialog();
            }
        }
    }
}
