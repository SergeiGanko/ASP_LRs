using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace _60321_Ganko.Tests.Routes
{
    [TestClass]
    public class RoutesTest
    {
        [TestMethod]
        public void DefaultRouteTest()
        {
            //Arrange
            // макет Http - контекста
            var mockContext = new Mock<HttpContextBase>();
            mockContext
                .Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                .Returns("~/");

            // Создание коллекции маршрутов и регистрация маршрутов
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            // Получение данных маршрута
            var result = routes.GetRouteData(mockContext.Object);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home", result.Values["controller"]);
            Assert.AreEqual("Index", result.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, result.Values["id"]);
        }
    }
}
