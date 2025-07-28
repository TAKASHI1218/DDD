
using DDD.Domain;
using DDD.Domain.Common;
using DDD.Domain.Date;

namespace DDD.WinForm
{
    public partial class WeathreLatestViews : Form
    {
        public WeathreLatestViews()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void WeathreLatestViews_Load(object sender, EventArgs e)
        {

        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            var dt = WeatherSQLite.GetLatest(Convert.ToInt32(AreaIdTextBox.Text));

            if (dt.Rows.Count > 0)
            {
                DataDateLabel.Text = dt.Rows[0]["DataDate"].ToString();
                ConditionLabel.Text = dt.Rows[0]["Condition"].ToString();


                //TemperatureLabel.Text =
                //   DDD.Domain.Common.CommonFunc.RoundString(
                //       Convert.ToSingle(dt.Rows[0]["Temperature"]),
                //       DDD.Domain.ValueObjects.Temperature.DecimalPoint) + " " +
                //       DDD.Domain.ValueObjects.Temperature.UnitName;
            }
        }
    }
}
