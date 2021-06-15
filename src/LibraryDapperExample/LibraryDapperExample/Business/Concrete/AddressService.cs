﻿using LibraryDapperExample.Business.Abstract;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Response;
using LibraryDapperExample.Utilities.Abstract;
using LibraryDapperExample.Utilities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Business.Concrete
{
    public class AddressService : IAddressService
    {
        private readonly IMediator _mediatR;
        public AddressService(IMediator mediatR) => _mediatR = mediatR;
      
        public async Task<IResult<CreateAddressCommandResponse>> Create(CreateAddressCommandRequest requestModel)
        {
            if (string.IsNullOrEmpty(requestModel.CountryName) &&
                string.IsNullOrEmpty(requestModel.CountyName) &&
                string.IsNullOrEmpty(requestModel.StateName) &&
                string.IsNullOrEmpty(requestModel.DistrictName)) return new Result<CreateAddressCommandResponse>(false);
            var result = await _mediatR.Send(requestModel);
            if (!result.Success) return new Result<CreateAddressCommandResponse>(false);
            return new Result<CreateAddressCommandResponse>(true);
        }

        public async Task<IResult<UpdateAddressCommandResponse>> Update(UpdateAddressCommandRequest requestModel)
        {
            if (string.IsNullOrEmpty(requestModel.CountryName) && requestModel.CountryId == Guid.Empty &&
               string.IsNullOrEmpty(requestModel.CountyName) && requestModel.CountyId == Guid.Empty &&
               string.IsNullOrEmpty(requestModel.StateName) && requestModel.StateId == Guid.Empty &&
               string.IsNullOrEmpty(requestModel.DistrictName) && requestModel.DistrictId == Guid.Empty) return new Result<UpdateAddressCommandResponse>(false);
            var result = await _mediatR.Send(requestModel);
            if (!result.Success) return new Result<UpdateAddressCommandResponse>(false);
            return new Result<UpdateAddressCommandResponse>(true);
        }
    }
}
