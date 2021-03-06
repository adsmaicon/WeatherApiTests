using System;
using System.ComponentModel;
using Xunit;
using Weather.Model;
using Weather.Services;
using System.Collections.Generic;
using Moq;

namespace Weather.UnitTests
{
    public class WeatherUnitTest
    {
        private IWeatherServices _weather;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste do m�todo GetAll")]
        public void Testa_GetAll_Valida_Quantidade()
        {
            _weather = new WeatherService();

            List<WeatherForecast> result = new List<WeatherForecast>();
            result.AddRange(_weather.GetAll());

            Assert.True(result.Count == Summaries.Length);
        }

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste do m�todo GetAll")]
        public void Testa_GetAll_Valida_Tipo()
        {
            _weather = new WeatherService();

            List<WeatherForecast> result = new List<WeatherForecast>();
            result.AddRange(_weather.GetAll());

            Assert.IsType<WeatherForecast>(result[0]);
        }

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste do m�todo GetAll")]
        public void Testa_GetAll_Valida_Retorno()
        {
            _weather = new WeatherService();
            WeatherForecast model = new WeatherForecast();

            List<WeatherForecast> result = new List<WeatherForecast>();
            result.AddRange(_weather.GetAll());

            model = result[0];

            Assert.Contains(model, result);
        }

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste utilizando Moq devido ao metodo GetByName n�o estar pronto")]
        public void Testa_GetByName_Moq()
        {
            var weather = new Mock<IWeatherServices>(MockBehavior.Strict);

            WeatherForecast model = new WeatherForecast()
            {
                Date = DateTime.Now,
                Summary = "Cool",
                TemperatureC = 20
            };

            weather.Setup(w => w.GetByName(It.IsAny<string>())).Returns(() => model);

            Assert.Equal<WeatherForecast>(model, weather.Object.GetByName("Cool"));
        }

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste passando um nome")]
        public void Testa_GetByName()
        {
            var weather = new WeatherService();
            WeatherForecast model = weather.GetByName("Cool");

            Assert.True(model.Summary == "Cool");
        }

        //[Fact]
        //[Trait("Teste Unitario", "Juliano")]
        //[Description("Teste passando um nome vazio")]
        //public void Testa_GetByName_Name_Null()
        //{
        //    var weather = new WeatherService();

        //    Exception ex = Assert.Throws<Exception>(() => weather.GetByName(""));

        //    Assert.Equal("O par�metro nome n�o pode ser nulo", ex.Message);
        //}

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste propriedade Date")]
        public void GetDateTest()
        {
            WeatherForecast weather = new WeatherForecast();
            weather.Date = DateTime.Parse("2020-09-02 00:00:00");

            Assert.Contains("2020-09-02 00:00:00", weather.Date.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste propriedade TemperatureC")]
        public void GetTemperatureCTest()
        {
            WeatherForecast weather = new WeatherForecast();
            weather.TemperatureC = 15;

            Assert.Contains("15", weather.TemperatureC.ToString());
        }

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste propriedade TemperatureF")]
        public void GetTemperatureFTest()
        {
            WeatherForecast weather = new WeatherForecast();

            Assert.Contains("32", weather.TemperatureF.ToString());
        }

        [Fact]
        [Trait("Teste Unitario", "Juliano")]
        [Description("Teste propriedade Summary")]
        public void GetSummaryTest()
        {
            WeatherForecast weather = new WeatherForecast();
            weather.Summary = "Cool";

            Assert.Contains("Cool", weather.Summary);
        }
    }
}
