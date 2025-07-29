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
        int AreaId_1 = 1;
        DateTime DataDate_1 = Convert.ToDateTime("2018/01/01 12:34:56");
        int Condition_1 = 2;
        float Temperature_1 = 12.3f;

        int AreaId_2 = 1;
        DateTime DataDate_2 = Convert.ToDateTime("2018/01/01 12:34:56");
        int Condition_2 = 1;
        float Temperature_2 = 22.12f;


        // Setupで値を設定
        weathreMock.Setup(x => x.GetLatest(1)).Returns(new WeatherEntity(AreaId_1, DataDate_1, Condition_1, Temperature_1));
        weathreMock.Setup(x => x.GetLatest(2)).Returns(new WeatherEntity(AreaId_2, DataDate_2, Condition_2, Temperature_2));

        // AreaEntityのMoq作成
        var areasMock = new Mock<IAreasRepository>();
        var areas = new List<AreaEntity>();
        areas.Add(new AreaEntity(1, "東京"));
        areas.Add(new AreaEntity(2, "神戸"));
        areas.Add(new AreaEntity(3, "沖縄"));
        areasMock.Setup(x => x.GetData()).Returns(areas);

        // 初期画面
        var viewModel = new WeatherLatestViewModel(weathreMock.Object,areasMock.Object);
        Assert.IsNull(viewModel.SelectedAreaId);
        Assert.AreEqual("", viewModel.DataDateText);
        Assert.AreEqual("", viewModel.ConditionText);
        Assert.AreEqual("", viewModel.TemperatureText);
        // エリア
        Assert.AreEqual(3, viewModel.Areas.Count);
        Assert.AreEqual(1, viewModel.Areas[0].AreaId);
        Assert.AreEqual("東京", viewModel.Areas[0].AreaName);
        Assert.AreEqual(2, viewModel.Areas[1].AreaId);
        Assert.AreEqual("神戸", viewModel.Areas[1].AreaName);

        // 東京(1)が選択された場合
        viewModel.SelectedAreaId = 1;
        viewModel.Search();
        Assert.AreEqual(1, viewModel.SelectedAreaId);
        Assert.AreEqual("2018/01/01 12:34:56", viewModel.DataDateText);
        Assert.AreEqual("曇り", viewModel.ConditionText);
        Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);

        // 神戸(2)が選択された場合
        viewModel.SelectedAreaId = 2;
        viewModel.Search();
        Assert.AreEqual(2, viewModel.SelectedAreaId);
        Assert.AreEqual("2018/01/01 12:34:56", viewModel.DataDateText);
        Assert.AreEqual("晴れ", viewModel.ConditionText);
        Assert.AreEqual("22.12 ℃", viewModel.TemperatureText);

        // 沖縄(3)が選択された場合
        viewModel.SelectedAreaId = 3;
        viewModel.Search();
        Assert.AreEqual(3, viewModel.SelectedAreaId);
        Assert.AreEqual("", viewModel.DataDateText);
        Assert.AreEqual("", viewModel.ConditionText);
        Assert.AreEqual("", viewModel.TemperatureText);
    }
}

