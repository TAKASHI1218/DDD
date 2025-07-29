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
        
        // AreaEntityのMoq作成
        var areasMock = new Mock<IAreasRepository>();
        var areas = new List<AreaEntity>();
        areas.Add(new AreaEntity(1, "東京"));
        areas.Add(new AreaEntity(2, "大阪"));
        areasMock.Setup(x => x.GetData()).Returns(areas);

        var viewModel = new WeatherLatestViewModel(weathreMock.Object,areasMock.Object);
        //Assert.IsNull("", viewModel.SelectedAreaId);
        Assert.AreEqual("", viewModel.DataDateText);
        Assert.AreEqual("", viewModel.ConditionText);
        Assert.AreEqual("", viewModel.TemperatureText);
        Assert.AreEqual(2, viewModel.Areas.Count);

        viewModel.SelectedAreaId = 1;
        viewModel.Search();
        Assert.AreEqual("1", viewModel.SelectedAreaId);
        Assert.AreEqual("2018/01/01 12:34:56", viewModel.DataDateText);
        Assert.AreEqual("曇り", viewModel.ConditionText);
        Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);
        Assert.AreEqual(1, viewModel.Areas[0].AreaId);
        Assert.AreEqual("東京", viewModel.Areas[0].AreaName);
        Assert.AreEqual(2, viewModel.Areas[1].AreaId);
        Assert.AreEqual("大阪", viewModel.Areas[1].AreaName);
    }
}

