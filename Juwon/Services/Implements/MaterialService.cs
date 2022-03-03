using Dapper;
using Juwon.Models.DTOs;
using Juwon.Repository;
using Juwon.Services.Interfaces;
using Library;
using Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Juwon.Services.Implements
{
    public class MaterialService : IMaterialService
    {
        private readonly IRepository repository;

        public MaterialService(IRepository IRepository)
        {
            repository = IRepository;
        }

        public Task<ResponseModel<MaterialModel>> Create(MaterialModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<int>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<IList<MaterialModel>>> GetActive()
        {
            var returnData = new ResponseModel<IList<MaterialModel>>();
            string proc = $"usp_Material_GetActive";
            try
            {
                var result = await repository.ExecuteReturnList<MaterialModel>(proc);
                if (result.Count > 0)
                {
                    returnData.Data = result;
                    returnData.ResponseMessage = Resource.SUCCESS_Success;
                }
                else
                {
                    returnData.ResponseMessage = Resource.ERROR_NotFound;
                }

                returnData.IsSuccess = true;
                return returnData;
            }
            catch (Exception)
            {
                return returnData;
                throw;
            }
        }

        public async Task<ResponseModel<IList<MaterialModel>>> GetAll()
        {
            var returnData = new ResponseModel<IList<MaterialModel>>();
            string proc = $"usp_Material_GetAll";
            try
            {
                var result = await repository.ExecuteReturnList<MaterialModel>(proc);
                if (result.Count > 0)
                {
                    returnData.Data = result;
                    returnData.ResponseMessage = Resource.SUCCESS_Success;
                }
                else
                {
                    returnData.ResponseMessage = Resource.ERROR_NotFound;
                }

                returnData.IsSuccess = true;
                return returnData;
            }
            catch (Exception)
            {
                return returnData;
                throw;
            }
        }

        public async Task<ResponseModel<MaterialModel>> GetByCode(string materialCode)
        {
            var returnData = new ResponseModel<MaterialModel>();
            string proc = "usp_Material_GetByCode";
            var param = new DynamicParameters();
            param.Add("@MaterialCode", materialCode);
            try
            {
                var result = await repository.ExecuteReturnFirsOrDefault<MaterialModel>(proc, param);
                if (result != null)
                {
                    returnData.Data = result;
                    returnData.ResponseMessage = Resource.SUCCESS_Success;
                    returnData.IsSuccess = true;
                }
                else
                {
                    returnData.ResponseMessage = Resource.ERROR_NotFound;
                }

                return returnData;
            }
            catch (Exception)
            {
                return returnData;
            }
        }

        public async Task<ResponseModel<MaterialModel>> GetById(int id)
        {
            var returnData = new ResponseModel<MaterialModel>();
            string proc = "usp_Material_GetByCode";
            var param = new DynamicParameters();
            param.Add("@MaterialId", id);
            try
            {
                var result = await repository.ExecuteReturnFirsOrDefault<MaterialModel>(proc, param);
                if (result != null)
                {
                    returnData.Data = result;
                    returnData.ResponseMessage = Resource.SUCCESS_Success;
                    returnData.IsSuccess = true;
                }
                else
                {
                    returnData.ResponseMessage = Resource.ERROR_NotFound;
                }

                return returnData;
            }
            catch (Exception)
            {
                return returnData;
            }
        }

        public Task<ResponseModel<MaterialModel>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<MaterialModel>> Modify(MaterialModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<IList<MaterialModel>>> SearchActive(string keyWord)
        {
            var returnData = new ResponseModel<IList<MaterialModel>>();
            string proc = $"usp_Material_SearchActive";
            var param = new DynamicParameters();
            param.Add("@KeyWord", keyWord);
            try
            {
                var result = await repository.ExecuteReturnList<MaterialModel>(proc);
                if (result.Count > 0)
                {
                    returnData.Data = result;
                    returnData.ResponseMessage = Resource.SUCCESS_Success;
                }
                else
                {
                    returnData.ResponseMessage = Resource.ERROR_NotFound;
                }

                returnData.IsSuccess = true;
                return returnData;
            }
            catch (Exception)
            {
                return returnData;
                throw;
            }
        }

        public async Task<ResponseModel<IList<MaterialModel>>> SearchAll(string keyWord)
        {
            var returnData = new ResponseModel<IList<MaterialModel>>();
            string proc = $"usp_Material_SearchAll";
            var param = new DynamicParameters();
            param.Add("@KeyWord", keyWord);
            try
            {
                var result = await repository.ExecuteReturnList<MaterialModel>(proc);
                if (result.Count > 0)
                {
                    returnData.Data = result;
                    returnData.ResponseMessage = Resource.SUCCESS_Success;
                }
                else
                {
                    returnData.ResponseMessage = Resource.ERROR_NotFound;
                }

                returnData.IsSuccess = true;
                return returnData;
            }
            catch (Exception)
            {
                return returnData;
                throw;
            }
        }
    }
}