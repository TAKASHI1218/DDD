using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.WinForm.ViewModels;
using Moq;

namespace DDDTest.Tests;

[TestClass]
public class WeatherListViewModelTest
{
    [TestMethod]
    public void 天気一覧画面シナリオ()
    {
        var weatherMock = new Mock<IWeatherRepository>();

        var entities = new List<WeatherEntity>();
        entities.Add(
          new WeatherEntity(
              1,
              Convert.ToDateTime("2018/01/01 12:34:56"),
              2,
              12.3f));

        entities.Add(
         new WeatherEntity(
             2,
             Convert.ToDateTime("2018/01/02 12:34:56"),
             1,
             22.1234f));

        // entitiesの2つのデータを設定する
        weatherMock.Setup(x => x.GetData()).Returns(entities);

        // weathreMockのオブジェクトをviewModelに渡す
        var viewModel =
            new WeatherListViewModel(weatherMock.Object);
        viewModel.Weathers.Count.Is(2);
    }
}
