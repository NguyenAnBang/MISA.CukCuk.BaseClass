using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Interfaces.Services
{
    public interface IDataAccessBaseServices<MISAEntity> where MISAEntity : class
    {
        //Lấy tất cả bản ghi từ database
        public IEnumerable<MISAEntity> GetAll();
        //Lấy 1 bản ghi theo id
        public MISAEntity GetCustomerById(Guid entityId);
        //Insert 1 bản ghi vào database
        public int Post(MISAEntity entity);
        //Update 1 bản ghi theo id
        public int Put(MISAEntity entity);
        //Xóa 1 bản ghi theo id
        public int Delete(Guid entityId);
        //Phân trang
        public IEnumerable<MISAEntity> GetPaging(int pageIndex, int pageSize);
    }
}
