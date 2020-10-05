using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trains.Client.Models;
using Trains.Client.ViewModels;
using Trains.Shared;
using Trains.Shared.Enums;
using Xunit;

namespace Trains.Client.Tests
{
    public class TrainsViewModelTests
    {
        private readonly Mock<ITrainsModel> _trainsModelMock;
        private readonly TrainsViewModel _trainsViewModel;
        public TrainsViewModelTests()
        {
            _trainsModelMock = new Mock<ITrainsModel>();
            _trainsViewModel = new TrainsViewModel(_trainsModelMock.Object);
        }

        [Fact]
        public async Task RetrieveTrains()
        {
            //Arrange
            _trainsModelMock.SetupGet(x => x.Trains).Returns(new List<Train>() { new Train("Lotus", 1999, Color.Blue, "ARS456", "LG", "Vilnius") });

            //Act
            await _trainsViewModel.RetrieveTrainsAsync();
            var trains = _trainsViewModel.Trains;

            //Assert
            Assert.Single(trains);
        }
    }
}
