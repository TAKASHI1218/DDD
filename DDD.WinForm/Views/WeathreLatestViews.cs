
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
        }

        private void WeathreLatestViews_Load(object sender, EventArgs e)
        {

        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            //var dt = WeatherSQLite.GetLatest(Convert.ToInt32(AreaIdTextBox.Text));

            //if (dt.Rows.Count > 0)
            //{
            //    DataDateLabel.Text = dt.Rows[0]["DataDate"].ToString();
            //    ConditionLabel.Text = dt.Rows[0]["Condition"].ToString();


            //    TemperatureLabel.Text =
            //       DDD.Domain.Common.CommonFunc.RoundString(
            //           Convert.ToSingle(dt.Rows[0]["Temperature"]),
            //           DDD.Domain.ValueObjects.Temperature.DecimalPoint) + " " +
            //           DDD.Domain.ValueObjects.Temperature.UnitName;
            //}
        }
    }
}
