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
        [TestCase("a","a","a","a")]
        [TestCase("a", "", "a", "a")]
        [TestCase("", "a", "a", "a")]
        [TestCase("a", "a", "", "a")]
        [TestCase("a", "a", "a", "")]
        public async Task CreateAddressTest_ReturnsTrue(string a,string b,string c,string d)
        {
            CreateAddressCommandRequest request = new CreateAddressCommandRequest
            {
                CountryName = a,
                CountyName = b,
                DistrictName = c,              
                StateName = d
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<CreateAddressCommandRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateAddressCommandResponse {Success = true });
            var addressService = new AddressService(fakeMediator.Object);
            var data = await addressService.Create(request);
            Assert.AreEqual(true, data.Success);
        }

        [TestCase("", "", "", "")]
        [TestCase(null, null, null, null)]
        public async Task CreateAddressTest_ReturnsFalse(string a, string b, string c, string d)
        {
            CreateAddressCommandRequest request = new CreateAddressCommandRequest
            {
                CountryName = a,
                CountyName = b,
                DistrictName = c,
                StateName = d
            };
            var fakeMediator = new Mock<IMediator>();
            fakeMediator.Setup(x => x.Send(It.IsAny<CreateAddressCommandRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateAddressCommandResponse { Success = true });
            var addressService = new AddressService(fakeMediator.Object);
            var data = await addressService.Create(request);
            Assert.AreEqual(false, data.Success);
        }
    }
}
