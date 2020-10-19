using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Trains.Server.Controllers;
using Trains.Server.Services;
using Trains.Shared;
using Trains.Shared.Enums;
using Xunit;

namespace Trains.Server.Tests
{
    public class TrainControllerTests
    {
        private readonly TrainController _trainController;
        private readonly Mock<ITrainsStorageService> _trainsStorageServiceMock;
        public TrainControllerTests()
        {
            _trainsStorageServiceMock = new Mock<ITrainsStorageService>();
            _trainController = new TrainController(_trainsStorageServiceMock.Object);
        }


        [Fact]
        public void Get_WithOneTrain_ReturnsTrainsList()
        {
            // Arrange
            _trainsStorageServiceMock.Setup(x => x.Trains).Returns(new HashSet<Train>() { new Train("Lotus", 1999, TrainColor.Blue, "ARS456", "LG", "Vilnius") });

            // Act
            var result = _trainController.Get();

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<Train>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var trainsValue = Assert.IsType<List<Train>>(okResult.Value);
            Assert.Single(trainsValue);
        }

        [Fact]
        public void Get_WithTrainId_ReturnsSingleTrain()
        {
            // Arrange
            var trainMock = new Train("Lotus", 1999, TrainColor.Blue, "ARS456", "LG", "Vilnius");
            _trainsStorageServiceMock.Setup(x => x.Trains).Returns(new HashSet<Train>() { trainMock });

            // Act
            var result = _trainController.Get(trainMock.Id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Train>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var train = Assert.IsType<Train>(okResult.Value);
            Assert.Equal(trainMock.LicensePlate, train.LicensePlate);
        }

        [Fact]
        public void Post_WithValidTrain_CreatesTrain()
        {
            // Arrange
            var trainMock = new Train("Lotus", 1999, TrainColor.Blue, "ARS456", "LG", "Vilnius");
            _trainsStorageServiceMock.Setup(x => x.Trains).Returns(new HashSet<Train>() { });

            // Act
            var result = _trainController.Post(trainMock); // TODO add validation case

            // Assert
            var actionResult = Assert.IsType<ActionResult<Train>>(result);
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var train = Assert.IsType<Train>(createdResult.Value);
            Assert.Equal(trainMock.LicensePlate, train.LicensePlate);
            _trainsStorageServiceMock.VerifyGet(x=>x.Trains);
        }

        [Fact]
        public void Put_WithChangedProperty_UpdatesTrain()
        {
            // Arrange
            var trainMock = new Train("Lotus", 1999, TrainColor.Blue, "ARS456", "LG", "Vilnius");
            _trainsStorageServiceMock.Setup(x => x.Trains).Returns(new HashSet<Train>() { trainMock });
            trainMock.LicensePlate = "AA";

            // Act
            var result = _trainController.Put(trainMock.Id, trainMock);

            // Assert
            Assert.IsType<OkResult>(result);
            Assert.Equal(trainMock.LicensePlate, _trainsStorageServiceMock.Object.Trains.First().LicensePlate);
            _trainsStorageServiceMock.VerifyGet(x => x.Trains);
        }

        [Fact]
        public void Delete_WithChangedProperty_UpdatesTrain()
        {
            // Arrange
            var trainMock = new Train("Lotus", 1999, TrainColor.Blue, "ARS456", "LG", "Vilnius");
            _trainsStorageServiceMock.Setup(x => x.Trains).Returns(new HashSet<Train>() { trainMock });

            // Act
            var result = _trainController.Delete(trainMock.Id);

            // Assert
            Assert.IsType<NoContentResult>(result);
            Assert.Empty(_trainsStorageServiceMock.Object.Trains);
            _trainsStorageServiceMock.VerifyGet(x => x.Trains);
        }
    }
}
