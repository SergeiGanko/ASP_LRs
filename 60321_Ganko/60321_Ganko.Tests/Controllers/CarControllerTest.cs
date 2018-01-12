using System;
using Moq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _60321_Ganko.DAL.Interfaces;
using _60321_Ganko.DAL.Entities;
using System.Collections.Generic;
using _60321_Ganko.Controllers;
using _60321_Ganko.Models;
using System.Collections.Specialized;

namespace _60321_Ganko.Tests.Controllers
{
    [TestClass]
    public class CarControllerTest
    {
        [TestMethod]
        public void PagingTest()
        {
            //Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<Car>>();
            mock.Setup(r => r.GetAll())
                .Returns(new List<Car>
                {
                    new Car{CarId=1},
                    new Car{CarId=2},
                    new Car{CarId=3},
                    new Car{CarId=4},
                    new Car{CarId=5}
                });

            // Создание объекта контроллера
            var controller = new CarController(mock.Object);

            // Макеты для получения HttpContext и HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            NameValueCollection valueCollection = new NameValueCollection();
            valueCollection.Add("X-Requsted-With", "XMLHttpRequest");
            valueCollection.Add("Accept", "application/json");
            // другой вариант: valueCollection.Add("Accept", "HTML");
            request.Setup(r => r.Headers).Returns(valueCollection);

            // Act
            // Вызов метода List
            var view = controller.List(null, 2) as ViewResult;

            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Car> model = view.Model as PageListViewModel<Car>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(4, model[0].CarId);
            Assert.AreEqual(5, model[1].CarId);
        }

        [TestMethod]
        public void CategoryTest()
        {
            //Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<Car>>();
            mock.Setup(r => r.GetAll())
                .Returns(new List<Car>
                {
                    new Car{CarId=1, ClassType="Sedan"},
                    new Car{CarId=2, ClassType="SUV"},
                    new Car{CarId=3, ClassType="Sedan"},
                    new Car{CarId=4, ClassType="Hatchback"},
                    new Car{CarId=5, ClassType="Coupe"}
                });

            // Создание объекта контроллера
            var controller = new CarController(mock.Object);

            // Макеты для получения HttpContext и HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            //NameValueCollection valueCollection = new NameValueCollection();
            //valueCollection.Add("X-Requsted-With", "XMLHttpRequest");
            //valueCollection.Add("Accept", "application/json");
            //// другой вариант: valueCollection.Add("Accept", "HTML");
            //request.Setup(r => r.Headers).Returns(valueCollection);

            // Act
            // Вызов метода List
            var view = controller.List("Sedan", 1) as ViewResult;

            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Car> model = view.Model as PageListViewModel<Car>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(1, model[0].CarId);
            Assert.AreEqual(3, model[1].CarId);
        }


    }
}
