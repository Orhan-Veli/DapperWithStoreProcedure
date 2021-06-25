using LibraryDapperExample.Business.Abstract;
using LibraryDapperExample.Business.Concrete;
using LibraryDapperExample.Controllers;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Handlers.Command;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response;
using LibraryDapperExample.Utilities.Concrete;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NUnitTest
{
    [TestFixture]
    class TestAddressService
    {
        [TestCase("CountryName", "CountyName", "StateName", "DistrictName")]
        [TestCase("", "CountyName", "StateName", "DistrictName")]
        [TestCase("CountryName", "", "StateName", "DistrictName")]
        [TestCase("CountryName", "CountyName", "", "DistrictName")]
        [TestCase("CountryName", "CountyName", "StateName", "")]
        public async Task CreateAddressTest_ReturnsTrue(string CountryName, string CountyName, string StateName, string DistrictName)
        {
            CreateAddressCommandRequest request = new CreateAddressCommandRequest
            {
                CountryName = CountryName,
                CountyName = CountyName,
                DistrictName = DistrictName,              
                StateName = StateName
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<CreateAddressCommandRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateAddressCommandResponse {Success = true });
            var addressService = new AddressService(fakeMediator.Object);
            var data = await addressService.Create(request);
            Assert.AreEqual(true, data.Success);
        }

        [TestCase("", "", "", "")]
        [TestCase(null, null, null, null)]
        public async Task CreateAddressTest_ReturnsFalse(string CountryName, string CountyName, string StateName, string DistrictName)
        {
            CreateAddressCommandRequest request = new CreateAddressCommandRequest
            {
                CountryName = CountryName,
                CountyName = CountyName,
                DistrictName = DistrictName,
                StateName = StateName
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<CreateAddressCommandRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateAddressCommandResponse { Success = true });
            var addressService = new AddressService(fakeMediator.Object);
            var data = await addressService.Create(request);
            Assert.AreEqual(false, data.Success);
        }

        public const string guid = "{ccae2079-2ebc-4200-879d-866fc82e6afa}";
        public const string empty = "{00000000-0000-0000-0000-000000000000}";
        [TestCase(guid, guid, guid, guid)]
        [TestCase(empty, guid, guid, guid)]
        [TestCase(guid, empty, guid, guid)]
        [TestCase(guid, guid, empty, guid)]
        [TestCase(guid, guid, guid, empty)]
        public async Task DeleteAddressTest_ReturnsTrue(Guid CountryId, Guid CountyId, Guid DistrictId, Guid StateId)
        {
            DeleteAddressCommandRequest request = new DeleteAddressCommandRequest
            {
                CountryId = CountryId,
                CountyId = CountyId,
                DistrictId = DistrictId,
                StateId = StateId
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<DeleteAddressCommandRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new DeleteAddressCommandResponse { Success = true });
            var addressService = new AddressService(fakeMediator.Object);
            var data = await addressService.Delete(request);
            Assert.AreEqual(true, data.Success);
        }

        [TestCase(empty, empty, empty, empty)]
        [TestCase(null, null, null, null)]
        public async Task DeleteAddressTest_ReturnsFalse(Guid CountryId, Guid CountyId, Guid DistrictId, Guid StateId)
        {
            DeleteAddressCommandRequest request = new DeleteAddressCommandRequest
            {
                CountryId = CountryId,
                CountyId = CountyId,
                DistrictId = DistrictId,
                StateId = StateId
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<DeleteAddressCommandRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new DeleteAddressCommandResponse { Success = true });
            var addressService = new AddressService(fakeMediator.Object);
            var data = await addressService.Delete(request);
            Assert.AreEqual(false, data.Success);
        }

        [TestCase] 
        public async Task GetAllAddressTest_ReturnsTrue()
        {
            List<GetAllAddressQueryResponse> getAllAddressQueryResponses = new List<GetAllAddressQueryResponse> {new GetAllAddressQueryResponse() };
            GetAllAddressQueryRequest request = new GetAllAddressQueryRequest();            
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<GetAllAddressQueryRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(getAllAddressQueryResponses);
            var addressService = new AddressService(fakeMediator.Object);
            var data = await addressService.GetAll(request);
            Assert.AreEqual(true, getAllAddressQueryResponses.Count > 0);
        }

        [TestCase("a", guid, "a", guid, "a", guid, "a", guid)]
        public async Task UpdateAddressTest_ReturnsTrue(string CountryName, Guid CountryId, string CountyName, Guid CountyId, string DistrictName, Guid DistrictId, string StateName, Guid StateId)
        {
            UpdateAddressCommandRequest requestModel = new UpdateAddressCommandRequest
            {
                CountryId = CountryId,
                CountryName = CountryName,
                CountyId = CountyId,
                CountyName = CountyName,
                DistrictId = DistrictId,
                DistrictName = DistrictName,
                StateId = StateId,
                StateName = StateName
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<UpdateAddressCommandRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new UpdateAddressCommandResponse {Success = true  });
            var addressService = new AddressService(fakeMediator.Object);
            var data = await addressService.Update(requestModel);
            Assert.AreEqual(true, data.Success);
        }

        [TestCase("a", guid, "a", guid, "a", guid, "a", guid)]
        [TestCase("", guid, "", guid, "", guid, "", guid)]
        [TestCase("a", empty, "a", empty, "a", empty, "a", empty)]        
        public async Task UpdateAddressTest_ReturnsFalse(string CountryName, Guid CountryId, string CountyName, Guid CountyId, string DistrictName, Guid DistrictId, string StateName, Guid StateId)
        {
            UpdateAddressCommandRequest requestModel = new UpdateAddressCommandRequest
            {
                CountryId = CountryId,
                CountryName = CountryName,
                CountyId = CountyId,
                CountyName = CountyName,
                DistrictId = DistrictId,
                DistrictName = DistrictName,
                StateId = StateId,
                StateName = StateName
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<UpdateAddressCommandRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new UpdateAddressCommandResponse { Success = true });
            var addressService = new AddressService(fakeMediator.Object);
            var data = await addressService.Update(requestModel);
            Assert.AreEqual(false, data.Success);
        }

    }
}
