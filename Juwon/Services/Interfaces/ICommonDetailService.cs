using Juwon.Models;
using Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juwon.Services.Interfaces
{
    public interface ICommonDetailService
    {
        Task<ResponseModel<IList<CommonDetailModel>>> GetAll();
        Task<ResponseModel<IList<CommonDetailModel>>> GetAllByMasterCode(string masterCode);
        Task<ResponseModel<CommonDetailModel>> GetById(int Id);
        Task<ResponseModel<CommonDetailModel>> GetByCodeAndMasterCode(string code, string masterCode);
        Task<ResponseModel<IList<CommonDetailModel>>> Search(string keyWord);
        Task<ResponseModel<CommonDetailModel>> Create(CommonDetail model);
        Task<ResponseModel<CommonDetailModel>> Modify(CommonDetail model);
        Task<ResponseModel<CommonDetailModel>> Delete(CommonDetail model);
    }
}
