﻿using Dapper;
using Library.Common;
using Juwon.Models;
using Juwon.Repository;
using Juwon.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library;
using Library.Helper;

namespace Juwon.Services.Implements
{
    public class DestinationService : IDestinationService
    {
        private readonly IRepository repository;

        public DestinationService(IRepository iRepository)
        {
            repository = iRepository;
        }

        public async Task<ResponseModel<Destination>> Create(Destination model)
        {
            var returnData = new ResponseModel<Destination>();

            //Destination Code & Name cannot be blank
            if (string.IsNullOrWhiteSpace(model.DestinationCode) || string.IsNullOrWhiteSpace(model.DestinationName))
            {
                returnData.ResponseMessage = Resource.ERROR_FullFillTheForm;
                return returnData;
            }

            model.CreatedBy = SessionHelper.GetUserSession().ID;
            string proc = "usp_Destination_Create";
            var param = new DynamicParameters();
            param.Add("@DestinationCode", model.DestinationCode);
            param.Add("@DestinationName", model.DestinationName);
            param.Add("@DestinationDescription", model.DestinationDescription);
            param.Add("@CreatedBy", model.CreatedBy);
            try
            {
                var result = await repository.ExecuteReturnScalar<int>(proc, param);
                switch (result)
                {
                    case -2:
                        returnData.ResponseMessage = Resource.ERROR_DuplicatedName;
                        break;
                    case -1:
                        returnData.ResponseMessage = Resource.ERROR_DuplicatedCode;
                        break;
                    case 1:
                        proc = "usp_Destination_GetByCode";
                        param = new DynamicParameters();
                        param.Add("@DestinationCode", model.DestinationCode);
                        var data = await repository.ExecuteReturnFirsOrDefault<Destination>(proc, param);
                        returnData.ResponseMessage = Resource.SUCCESS_Success;
                        returnData.Data = data;
                        returnData.IsSuccess = true;
                        break;
                    default:
                        break;
                }
                return returnData;
            }
            catch (Exception)
            {
                returnData.HttpResponseCode = 500;
                return returnData;
                throw;
            }
        }

        public async Task<ResponseModel<int>> Delete(int destinationId)
        {
            var returnData = new ResponseModel<int>();
            int modifiedBy = SessionHelper.GetUserSession().ID;
            string proc = "usp_Destination_Delete";
            var param = new DynamicParameters();
            param.Add("@DestinationId", destinationId);
            param.Add("@ModifiedBy", modifiedBy);
            try
            {
                var result = await repository.ExecuteReturnScalar<int>(proc, param);
                switch (result)
                {
                    case -3:
                        returnData.ResponseMessage = Resource.ERROR_NotFound;
                        returnData.IsSuccess = false;
                        break;
                    case 1:
                        returnData.ResponseMessage = Resource.SUCCESS_Delete;
                        returnData.IsSuccess = true;
                        break;
                    default:
                        break;
                }
                return returnData;
            }
            catch (Exception)
            {
                returnData.HttpResponseCode = 500;
                return returnData;
                throw;
            }
        }

        public async Task<ResponseModel<IList<Destination>>> GetAll()
        {
            var returnData = new ResponseModel<IList<Destination>>();
            string proc = "usp_Destination_GetAll";
            try
            {
                var result = await repository.ExecuteReturnList<Destination>(proc);
                if (result.Count > 0)
                {
                    returnData.Data = result;
                    returnData.ResponseMessage = Resource.SUCCESS_Success;
                    returnData.IsSuccess = true;
                }
                else
                {
                    returnData.ResponseMessage = Resource.ERROR_NotFound;
                    returnData.IsSuccess = false;
                }

                returnData.IsSuccess = true;
                return returnData;
            }
            catch (Exception)
            {
                return returnData;
            }
        }

        public async Task<ResponseModel<IList<Destination>>> GetActive()
        {
            var returnData = new ResponseModel<IList<Destination>>();
            string proc = "usp_Destination_GetAllActive";
            try
            {
                var result = await repository.ExecuteReturnList<Destination>(proc);
                if (result.Count > 0)
                {
                    returnData.Data = result;
                    returnData.ResponseMessage = Resource.SUCCESS_Success;
                    returnData.IsSuccess = true;
                }
                else
                {
                    returnData.ResponseMessage = Resource.ERROR_NotFound;
                    returnData.IsSuccess = false;
                }

                returnData.IsSuccess = true;
                return returnData;
            }
            catch (Exception)
            {
                return returnData;
            }
        }

        public async Task<ResponseModel<Destination>> GetByCode(string destinationCode)
        {
            var returnData = new ResponseModel<Destination>();
            string proc = "usp_Destination_GetByCode";
            var param = new DynamicParameters();
            param.Add("@DestinationCode", destinationCode);
            var data = await repository.ExecuteReturnFirsOrDefault<Destination>(proc, param);
            if (data != null)
            {
                returnData.ResponseMessage = Resource.SUCCESS_Success;
                returnData.Data = data;
                returnData.IsSuccess = true;
            }
            else
            {
                returnData.ResponseMessage = Resource.ERROR_NotFound;
                returnData.IsSuccess = false;
            }
            return returnData;
        }

        public async Task<ResponseModel<Destination>> GetById(int destinationId)
        {
            var returnData = new ResponseModel<Destination>();
            string proc = "usp_Destination_GetById";
            var param = new DynamicParameters();
            param.Add("@DestinationId", destinationId);
            var data = await repository.ExecuteReturnFirsOrDefault<Destination>(proc, param);
            if (data != null)
            {
                returnData.ResponseMessage = Resource.SUCCESS_Success;
                returnData.Data = data;
                returnData.IsSuccess = true;
            }
            else
            {
                returnData.ResponseMessage = Resource.ERROR_NotFound;
                returnData.IsSuccess = false;
            }
            return returnData;
        }

        public async Task<ResponseModel<Destination>> GetByName(string destinationName)
        {
            var returnData = new ResponseModel<Destination>();
            string proc = "usp_Destination_GetByName";
            var param = new DynamicParameters();
            param.Add("@DestinationName", destinationName);
            var data = await repository.ExecuteReturnFirsOrDefault<Destination>(proc, param);
            if (data != null)
            {
                returnData.ResponseMessage = Resource.SUCCESS_Success;
                returnData.Data = data;
                returnData.IsSuccess = true;
            }
            else
            {
                returnData.ResponseMessage = Resource.ERROR_NotFound;
                returnData.IsSuccess = false;
            }
            return returnData;
        }

        public async Task<ResponseModel<Destination>> Modify(Destination model)
        {
            var returnData = new ResponseModel<Destination>();

            //Destination Code & Name cannot be blank
            if (string.IsNullOrWhiteSpace(model.DestinationCode) || string.IsNullOrWhiteSpace(model.DestinationName))
            {
                returnData.ResponseMessage = Resource.ERROR_FullFillTheForm;
                return returnData;
            }
            model.ModifiedBy = SessionHelper.GetUserSession().ID;
            string proc = "usp_Destination_Modify";
            var param = new DynamicParameters();
            param.Add("@DestinationId", model.DestinationId);
            param.Add("@DestinationName", model.DestinationName);
            param.Add("@DestinationDescription", model.DestinationDescription);
            param.Add("@ModifiedBy", model.ModifiedBy);
            try
            {
                var result = await repository.ExecuteReturnScalar<int>(proc, param);
                switch (result)
                {
                    case -3:
                        returnData.ResponseMessage = Resource.ERROR_NotFound;
                        break;
                    case -2:
                        returnData.ResponseMessage = Resource.ERROR_DuplicatedName;
                        break;
                    case 1:
                        proc = "usp_Destination_GetById";
                        param = new DynamicParameters();
                        param.Add("@DestinationId", model.DestinationId);
                        var data = await repository.ExecuteReturnFirsOrDefault<Destination>(proc, param);
                        returnData.ResponseMessage = Resource.SUCCESS_Success;
                        returnData.Data = data;
                        returnData.IsSuccess = true;
                        break;
                    default:
                        break;
                }
                return returnData;
            }
            catch (Exception)
            {
                returnData.HttpResponseCode = 500;
                return returnData;
                throw;
            }
        }

        public async Task<ResponseModel<IList<Destination>>> SearchActive(string keyWord)
        {
            var returnData = new ResponseModel<IList<Destination>>();
            string proc = "usp_Destination_Search";
            var param = new DynamicParameters();
            param.Add("@keyWord", keyWord);
            try
            {
                var result = await repository.ExecuteReturnList<Destination>(proc, param);
                if (result.Count > 0)
                {
                    returnData.Data = result;
                    returnData.ResponseMessage = Resource.SUCCESS_Success;
                }
                else
                {
                    returnData.Data = null;
                    returnData.ResponseMessage = Resource.ERROR_NotFound;
                }

                returnData.IsSuccess = true;
                return returnData;
            }
            catch (Exception)
            {
                return returnData;
            }
        }

        public async Task<ResponseModel<IList<Destination>>> SearchAll(string keyWord)
        {
            var returnData = new ResponseModel<IList<Destination>>();
            string proc = "usp_Destination_SearchAll";
            var param = new DynamicParameters();
            param.Add("@keyWord", keyWord);
            try
            {
                var result = await repository.ExecuteReturnList<Destination>(proc, param);
                if (result.Count > 0)
                {
                    returnData.Data = result;
                    returnData.ResponseMessage = Resource.SUCCESS_Success;
                }
                else
                {
                    returnData.Data = null;
                    returnData.ResponseMessage = Resource.ERROR_NotFound;
                }

                returnData.IsSuccess = true;
                return returnData;
            }
            catch (Exception)
            {
                return returnData;
            }
        }
    }
}
