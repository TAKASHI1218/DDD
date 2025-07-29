using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Domain.ViewModels;
using Moq;
namespace DDDTest.Tests;

[TestClass]
public class WeatherLatestViewModelTest
{
    [TestMethod]
    public void シナリオ()
    {
        // Moqを作りたいインターフェースを型指定
        var weathreMock = new Mock<IWeatherRepository>();  

        // MoqのSetup用変数
        int AreaId = 1;
        DateTime DataDate = Convert.ToDateTime("2018/01/01 12:34:56");
        int Condition = 2;
        float Temperature = 12.3f;

        // Setupで値を設定
        weathreMock.Setup(x => x.GetLatest(1)).Returns(new WeatherEntity(AreaId, DataDate, Condition, Temperature));

        var viewModel = new WeatherLatestViewModel(weathreMock.Object);
        Assert.AreEqual("", viewModel.AreaIdText);
        Assert.AreEqual("", viewModel.DataDateText);
        Assert.AreEqual("", viewModel.ConditionText);
        Assert.AreEqual("", viewModel.TemperatureText);

        viewModel.AreaIdText = "1";
        viewModel.Search();
        Assert.AreEqual("1", viewModel.AreaIdText);
        Assert.AreEqual("2018/01/01 12:34:56", viewModel.DataDateText);
        Assert.AreEqual("曇り", viewModel.ConditionText);
        Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);
    }
}

