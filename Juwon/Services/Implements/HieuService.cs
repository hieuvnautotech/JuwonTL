using Dapper;
using Juwon.Models;
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
    public class HieuService : IHieuService
    {
        private readonly IRepository repository;
        private readonly string connectionString = DatabaseConnection.CONNECTIONSTRING;
        public HieuService(IRepository iRepository)
        {
            repository = iRepository;
        }

        public Task<ResponseModel<Supplier>> Create(Supplier model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<int>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<IList<Supplier>>> GetActive()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<IList<Supplier>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Supplier>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Supplier>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Supplier>> Modify(Supplier model)
        {
            throw new NotImplementedException();
        }

       

        
        //public async Task<int> BulkInsert(List<Supplier> insertList)
        //{
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        //var dataTable = repository.ConvertListToDataTable(insertList);
        //        var effectedRows = await connection.BulkInsertAsync(insertList);
        //        if (effectedRows > 0)
        //        {
        //            return 1;
        //        }
        //        return 0;
        //    }
        //}

        //public async Task<ResponseModel<Supplier>> Create(Supplier model)
        //{

        //    var returnData = new ResponseModel<Supplier>();
        //    int createdBy = SessionHelper.GetUserSession().ID;
        //    string proc = $"usp_Supplier_Create";
        //    var param = new DynamicParameters();
        //    param.Add("@SupplierName", model.SupplierName);
        //    param.Add("@SupplierAddress", model.SupplierAddress);
        //    param.Add("@SupplierUrl", model.SupplierUrl);
        //    param.Add("@SupplierEmail", model.SupplierEmail);
        //    param.Add("@SupplierPhone", model.SupplierPhone);
        //    param.Add("@CreatedBy", createdBy);
        //    try
        //    {
        //        var result = await repository.ExecuteReturnScalar<int>(proc, param);
        //        switch (result)
        //        {
        //            case -2:
        //                returnData.ResponseMessage = Resource.ERROR_DuplicatedName;
        //                break;
        //            case 0:
        //                break;
        //            default:
        //                model.SupplierId = result;
        //                model.CreatedDate = DateTime.Now;
        //                returnData.ResponseMessage = Resource.SUCCESS_Create;
        //                returnData.Data = model;
        //                returnData.IsSuccess = true;
        //                break;
        //        }
        //        return returnData;
        //    }
        //    catch (Exception)
        //    {
        //        returnData.HttpResponseCode = 500;
        //        return returnData;
        //    }


        //var returnData = new ResponseModel<Supplier>();

        ////Supplier Name cannot be blank
        //if (string.IsNullOrWhiteSpace(model.SupplierName))
        //{
        //    returnData.ResponseMessage = Resource.ERROR_FullFillTheForm;
        //    return returnData;
        //}

        //var list = new List<Supplier>();
        //model.Active = true;
        //model.CreatedDate = DateTime.Now;
        //model.CreatedBy = SessionHelper.GetUserSession().ID;
        //list.Add(model);

        //try
        //{
        //    var result = await BulkInsert(list);

        //    if (result > 0)
        //    {
        //        //string proc = "usp_Supplier_Search";
        //        //var param = new DynamicParameters();
        //        //param.Add("@SupplierName", model.SupplierName);
        //        //var data = await repository.ExecuteReturnFirsOrDefault<Supplier>(proc, param);
        //        model.SupplierId = 1;
        //        returnData.ResponseMessage = Resource.SUCCESS_Success;
        //        returnData.Data = model;
        //        returnData.IsSuccess = true;
        //    }
        //    return returnData;
        //}
        //catch (Exception)
        //{
        //    return returnData;
        //    throw;
        //}
    

        //public async Task<ResponseModel<int>> Delete(int supplierId)
        //{
        //    var returnData = new ResponseModel<int>();
        //    int modifiedBy = SessionHelper.GetUserSession().ID;
        //    string proc = $"usp_Supplier_Delete";
        //    var param = new DynamicParameters();
        //    param.Add("@supplierId", supplierId);
        //    param.Add("@ModifiedBy", modifiedBy);
        //    try
        //    {
        //        var result = await repository.ExecuteReturnScalar<int>(proc, param);
        //        switch (result)
        //        {
        //            case -3:
        //                returnData.ResponseMessage = Resource.ERROR_NotFound;
        //                break;
        //            case 0:
        //                break;
        //            default:
        //                returnData.ResponseMessage = Resource.SUCCESS_Delete;
        //                returnData.Data = result;
        //                returnData.IsSuccess = true;
        //                break;
        //        }
        //        return returnData;
        //    }
        //    catch (Exception)
        //    {
        //        returnData.HttpResponseCode = 500;
        //        return returnData;
        //    }
        //}

        //public Task<ResponseModel<IList<Supplier>>> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResponseModel<IList<Supplier>>> GetActive()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResponseModel<Supplier>> GetById(int processId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResponseModel<Supplier>> GetByName(string processName)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<ResponseModel<Supplier>> Modify(Supplier model)
        //{
        //    var returnData = new ResponseModel<Supplier>();
        //    model.ModifiedBy = SessionHelper.GetUserSession().ID;
        //    //Name cannot be blank
        //    if (string.IsNullOrWhiteSpace(model.SupplierName))
        //    {
        //        returnData.ResponseMessage = Resource.ERROR_FullFillTheForm;
        //        return returnData;
        //    }

        //    string proc = "usp_Supplier_Modify";
        //    var param = new DynamicParameters();
        //    param.Add("@SupplierId", model.SupplierId);
        //    param.Add("@SupplierName", model.SupplierName);
        //    param.Add("@SupplierAddress", model.SupplierAddress);
        //    param.Add("@SupplierUrl", model.SupplierUrl);
        //    param.Add("@SupplierEmail", model.SupplierEmail);
        //    param.Add("@@SupplierPhone", model.SupplierPhone);
        //    param.Add("@ModifiedBy", model.ModifiedBy);
        //    try
        //    {
        //        var result = await repository.ExecuteReturnScalar<int>(proc, param);
        //        switch (result)
        //        {
        //            case -3:
        //                returnData.ResponseMessage = Resource.ERROR_NotFound;
        //                break;
        //            case -2:
        //                returnData.ResponseMessage = Resource.ERROR_DuplicatedName;
        //                break;
        //            case 1:
        //                returnData.ResponseMessage = Resource.SUCCESS_Success;
        //                returnData.Data = model;
        //                returnData.IsSuccess = true;
        //                break;
        //            default:
        //                break;
        //        }
        //        return returnData;
        //    }
        //    catch (Exception)
        //    {
        //        returnData.HttpResponseCode = 500;
        //        return returnData;
        //        throw;
        //    }
        //}

        public async Task<ResponseModel<IList<Supplier>>> SearchActive(string keyWord)
        {
            var returnData = new ResponseModel<IList<Supplier>>();
            string proc = "usp_Hieu_Search";
            var param = new DynamicParameters();
            param.Add("@keyWord", keyWord);
            try
            {
                var result = await repository.ExecuteReturnList<Supplier>(proc, param);
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

        public async Task<ResponseModel<IList<Supplier>>> SearchAll(string keyWord)
        {
            //throw new NotImplementedException();
            var returnData = new ResponseModel<IList<Supplier>>();
            string proc = "usp_usp_Hieu_SearchAll";
            var param = new DynamicParameters();
            param.Add("@keyWord", keyWord);
            try
            {
                var result = await repository.ExecuteReturnList<Supplier>(proc, param);
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
