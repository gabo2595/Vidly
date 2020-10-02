using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using WebApi.Controllers;

namespace WebApi.Tests
{
    [TestClass]
    public class MovieControllerTest
    {
        [TestMethod]
        public void TestGetAllOk()
        {
            // Category category = new Category()
            // {
            //     Id = 1,
            //     Name = "Action"
            // };

            List<Movie> moviesToReturn = new List<Movie>()
            {
                new Movie()
                {
                    Id = 1,
                    Name = "Iron man 3",
                    Description = "I'm Iron man",
                    AgeAllowed = 16,
                    // Category = category
                },
                new Movie()
                {
                    Id = 2,
                    Name = "Iron man 2",
                    Description = "I'm Iron man",
                    AgeAllowed = 16,
                    // Category = category
                }
            };
            
            var mock = new Mock<IMovieLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(moviesToReturn);
            var controller = new MovieController(mock.Object);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var movies = okResult.Value as IEnumerable<MovieDetailInfoModel>;

            mock.VerifyAll();
            Assert.IsTrue(moviesToReturn.Select(m => new MovieDetailInfoModel(m)).SequenceEqual(movies));
        }

        [TestMethod]
        public void TestGetByIdOk()
        {
            Category category = new Category()
            {
                Id = 1,
                Name = "Action"
            };

            Movie movieToReturn = new Movie()
            {
                
                Id = 1,
                Name = "Iron man 3",
                Description = "I'm Iron man",
                AgeAllowed = 16,
                // Category = category
                
            };
            
            var mock = new Mock<IMovieLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(1)).Returns(movieToReturn);
            var controller = new MovieController(mock.Object);

            var result = controller.Get(1);
            var okResult = result as OkObjectResult;
            var movie = okResult.Value as MovieDetailInfoModel;

            mock.VerifyAll();
            Assert.IsTrue(new MovieDetailInfoModel(movieToReturn).Equals(movie));
        }

        [TestMethod]
        public void TestGetByIdNotFound()
        {
            Movie movieNull = null;
            
            var mock = new Mock<IMovieLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(1)).Returns(movieNull);
            var controller = new MovieController(mock.Object);

            var result = controller.Get(1);

            mock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void TestPostMovieOk()
        {
            MovieModel movieModel = new MovieModel()
            {
                Name = "Enola Holmes",
                Description = "La herama de Sherlock y Mycroft Holmes",
                AgeAllowed = 12,
                CategoryId = 1
            };

            Movie movieToReturn = new Movie()
            {
                Id = 1,
                Name = "Enola Holmes",
                Description = "La herama de Sherlock y Mycroft Holmes",
                AgeAllowed = 12,
                // CategoryId = 1
            };

            var mock = new Mock<IMovieLogic>();
            mock.Setup(m => m.Add(It.IsAny<Movie>())).Returns(movieToReturn);
            var controller = new MovieController(mock.Object);

            var result = controller.Post(movieModel);
            var status = result as CreatedAtRouteResult;
            var content = status.Value as MovieBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(content, new MovieBasicInfoModel(movieToReturn));
        }
    }
}
