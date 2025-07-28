using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Domain.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace DDDTest.Tests;

[TestClass]
public class WeatherLatestViewModelTest
{
    [TestMethod]
    public void ÉVÉiÉäÉI()
    {
        var viewModel = new WeatherLatestViewModel(new WeatherMock());
        Assert.AreEqual("", viewModel.AreaIdText);
        Assert.AreEqual("", viewModel.DataDateText);
        Assert.AreEqual("", viewModel.ConditionText);
        Assert.AreEqual("", viewModel.TemperatureText);


        viewModel.AreaIdText = "1";
        viewModel.Search();
        Assert.AreEqual("1", viewModel.AreaIdText);
        Assert.AreEqual("2018/01/01 12:34:56", viewModel.DataDateText);
        Assert.AreEqual("2", viewModel.ConditionText);
        Assert.AreEqual("12.30 Åé", viewModel.TemperatureText);
    }
}

internal class WeatherMock : IWeatherRepository
{
    public WeatherEntity GetLatest(int areaId)
    {
        int AreaId = 1;
        DateTime DataDate = Convert.ToDateTime("2018/01/01 12:34:56");
        int Condition = 2;
        float Temperature = 12.3f;

        return new WeatherEntity(AreaId, DataDate, Condition, Temperature);
    }
}
