using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.WinForm;
using DDD.WinForm.ViewModels;
using Moq;

namespace DDDTest.Tests;

[TestClass]
public class WeatherSaveViewModelTest
{
    [TestMethod]
    public void 天気登録シナリオ()
    {
        // AreaEntityのMoq作成
        var areasMock = new Mock<IAreasRepository>();
        var areas = new List<AreaEntity>();
        areas.Add(new AreaEntity(1, "東京"));
        areas.Add(new AreaEntity(2, "神戸"));
        areasMock.Setup(x => x.GetData()).Returns(areas);

        // viewmodel自体をモック化
        // viewmodelの中のvirtualな関数を上書きできる
        var viewModelMock = new Mock<WeatherSaveViewModel>(areasMock.Object);
        // GetDateTimeはvirtualなので上書き
        viewModelMock.Setup(x => x.GetDateTime()).Returns(
            Convert.ToDateTime("2025/01/01 12:34:56"));

        var viewModel = viewModelMock.Object;
        // 初期値はnull
        viewModel.SelectedAreaId.IsNull();
        viewModel.DataDateVlaue.Is(
            Convert.ToDateTime("2025/01/01 12:34:56"));
        viewModel.SelectedCondition.Is(1);
        viewModel.TemperatureText.Is("");
        viewModel.Areas.Count.Is(2);
        viewModel.Conditions.Count.Is(4);
    }
}
