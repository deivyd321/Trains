using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Trains.Server.Controllers;
using Trains.Server.Repositories;
using Trains.Server.Services;
using Trains.Shared;
using Trains.Shared.Enums;
using Xunit;

namespace Trains.Server.Tests
{
    public class TrainControllerTests
    {
        private readonly TrainController _trainController;
        private readonly Mock<ITrainRepository> _trainRepositoryMock;
        public TrainControllerTests()
        {
            _trainRepositoryMock = new Mock<ITrainRepository>();
            _trainController = new TrainController(_trainRepositoryMock.Object);
        }


        [Fact]
        public void Get_WithOneTrain_ReturnsTrainsList()
        {
            // Arrange
            _trainRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<TrainEntity>() { new TrainEntity("Lotus", 1999, TrainColor.Blue, "ARS456", "LG", "Vilnius") });

            // Act
            var result = _trainController.Get();

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<TrainEntity>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var trainsValue = Assert.IsType<List<TrainEntity>>(okResult.Value);
            Assert.Single(trainsValue);
        }

        [Fact]
        public void Get_WithTrainId_ReturnsSingleTrain()
        {
            // Arrange
            var trainMock = new TrainEntity("Lotus", 1999, TrainColor.Blue, "ARS456", "LG", "Vilnius");
            _trainRepositoryMock.Setup(x => x.GetAsync(trainMock.Id)).ReturnsAsync(trainMock);

            // Act
            var result = _trainController.Get(trainMock.Id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<TrainEntity>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var train = Assert.IsType<TrainEntity>(okResult.Value);
            Assert.Equal(trainMock.LicensePlate, train.LicensePlate);
        }
        /*
        [Fact]
        public void Post_WithValidTrain_CreatesTrain()
        {
            // Arrange
            var trainMock = new TrainEntity("Lotus", 1999, TrainColor.Blue, "ARS456", "LG", "Vilnius");
            _trainRepositoryMock.Setup(x => x.Trains).Returns(new HashSet<TrainEntity>() { });

            // Act
            var result = _trainController.Post(trainMock); // TODO add validation case

            // Assert
            var actionResult = Assert.IsType<ActionResult<TrainEntity>>(result);
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var train = Assert.IsType<TrainEntity>(createdResult.Value);
            Assert.Equal(trainMock.LicensePlate, train.LicensePlate);
            _trainRepositoryMock.VerifyGet(x=>x.Trains);
        }

        [Fact]
        public void Put_WithChangedProperty_UpdatesTrain()
        {
            // Arrange
            var trainMock = new TrainEntity("Lotus", 1999, TrainColor.Blue, "ARS456", "LG", "Vilnius");
            _trainRepositoryMock.Setup(x => x.Trains).Returns(new HashSet<TrainEntity>() { trainMock });
            var trainUpdate = new TrainEntity("Lotus", 1999, TrainColor.Blue, "AAAAA", "LG", "Vilnius");

            // Act
            var result = _trainController.Put(trainMock.Id, trainUpdate);

            // Assert
            Assert.IsType<OkResult>(result);
            Assert.Equal(trainUpdate.LicensePlate, _trainRepositoryMock.Object.Trains.First().LicensePlate);
            _trainRepositoryMock.VerifyGet(x => x.Trains);
        }

        [Fact]
        public void Put_InvalidProperty_ThrowsException()
        {
            // Arrange
            var trainMock = new TrainEntity("Lotus", 1999, TrainColor.Blue, "ARS456", "LG", "Vilnius");
            _trainRepositoryMock.Setup(x => x.Trains).Returns(new HashSet<TrainEntity>() { trainMock });
            var trainUpdate = new TrainEntity("Lotus", 1999, TrainColor.Blue, "AA", "LG", "Vilnius");

            // Act and assert
            Assert.Throws<InvalidDataException>(()=> _trainController.Put(trainMock.Id, trainUpdate));
            Assert.Equal(trainMock.LicensePlate, _trainRepositoryMock.Object.Trains.First().LicensePlate);
        }

        [Fact]
        public void Delete_WithChangedProperty_UpdatesTrain()
        {
            // Arrange
            var trainMock = new TrainEntity("Lotus", 1999, TrainColor.Blue, "ARS456", "LG", "Vilnius");
            _trainRepositoryMock.Setup(x => x.Trains).Returns(new HashSet<TrainEntity>() { trainMock });

            // Act
            var result = _trainController.Delete(trainMock.Id);

            // Assert
            Assert.IsType<NoContentResult>(result);
            Assert.Empty(_trainRepositoryMock.Object.Trains);
            _trainRepositoryMock.VerifyGet(x => x.Trains);
        } */
    }
}
