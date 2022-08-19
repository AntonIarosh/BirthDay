using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using CongratulationAPI.AppServices.Services;
using CongratulationAPI.Domain.Entities;
using CongratulationAPI.Infrastructure.Repository;
using CongratulationAPI.Infrastructure.Repositoryes.KnowRepository;
using CongratulationAPI.Infrastructure.Repositoryes.UserRepository;
using CongratulationAPI.Mapper.Mapping;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CongratularionAPI.Tests
{
    public class KnowServiceTests
    {
        private readonly IMapper _mapper;

        private readonly Mock<IRepository<Know>> _repository;

        private readonly Mock<IKnowRepository> _knowRepository;

        private readonly KnowService _knowService;

        private readonly Fixture _fixture;

        public KnowServiceTests()
        {
            var config = new MapperConfiguration(mapconfig => mapconfig.AddProfile(new ApplicationMapperProfile()));
            _mapper = config.CreateMapper();

            _repository = new Mock<IRepository<Know>>();
            _knowRepository = new Mock<IKnowRepository>();

            _knowService = new KnowService(_repository.Object, _mapper, _knowRepository.Object);

            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetAllKnows_Should_Return_Knows()
        {
            //var knows = new List<Know> { new Know {Id = new Guid(), CreationDate = DateTime.UtcNow } };
            var knows = _fixture
                .Build<Know>()
                .Without(know=>know.KnowUser)
                .Without(know => know.FromUser)
                .CreateMany()
                .ToList();

            _knowRepository.Setup(knowRep => knowRep.GetAllKnowsWithUsersСonnectedFromBothSides())
                .ReturnsAsync(knows)
                .Verifiable();

            List<CongratulationAPI.Contracts.Know.KnowDto> result = await _knowService.GetAllKnows();

            _knowRepository.Verify();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Theory]
        [AutoData]
        public async Task Delete_Should_Throws_Exception(Guid id)
        {
            _repository
                .Setup(knowRep => knowRep.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(value: null)
                .Verifiable();


            await Assert.ThrowsAsync<Exception>(async() =>await _knowService.DeleteAsync(id));
        }

        [Theory]
        [AutoData]
        public async Task Delete_Should_Call_DeleteAsync(Guid id)
        {
            var know = _fixture
                .Build<Know>()
                .Without(know => know.KnowUser)
                .Without(know => know.FromUser)
                .Create();
            _repository
                .Setup(knowRep => knowRep.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(know)
                .Verifiable();

            await _knowService.DeleteAsync(id);

            _repository.Verify();
            _repository.Verify(service => service.DeleteAsync(It.IsAny<Know>()), Times.Once);
        }
    }
}
