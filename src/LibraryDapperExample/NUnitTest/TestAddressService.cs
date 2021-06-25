using LibraryDapperExample.Business.Abstract;
using LibraryDapperExample.Business.Concrete;
using LibraryDapperExample.Controllers;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Handlers.Command;
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
        //[Test, TestCase("EmptyGuid", "TestGuid", "TestGuid", "TestGuid")]
        //[Test, TestCase("TestGuid", "EmptyGuid", "TestGuid", "TestGuid")]
        //[Test, TestCase("TestGuid", "TestGuid", "EmptyGuid", "TestGuid")]
        //[Test, TestCase("TestGuid", "TestGuid", "TestGuid", "EmptyGuid")]
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




    }
}
