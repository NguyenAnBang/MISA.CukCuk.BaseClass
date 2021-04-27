using MISA.CukCuk.Core.Interfaces.Repositories;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Services
{
    public class DataAccessBaseServices<MISAEntity> : IDataAccessBaseServices<MISAEntity> where MISAEntity : class
    {
        IDataAccessBaseRepository<MISAEntity> _dataAccessBaseRepository;

        public DataAccessBaseServices(IDataAccessBaseRepository<MISAEntity> dataAccessBaseRepository)
        {
            _dataAccessBaseRepository = dataAccessBaseRepository;
        }

        /// <summary>
        /// Xóa 1 bản ghi theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public int Delete(Guid entityId)
        {
            var rowsAffect = _dataAccessBaseRepository.Delete(entityId);
            return rowsAffect;
        }
        /// <summary>
        /// Lấy tất cả bản ghi từ database, nhận giá trị từ dataAccessBaseRepository
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MISAEntity> GetAll()
        {
            var response = _dataAccessBaseRepository.GetAll();
            return response;
        }
        /// <summary>
        /// Lấy 1 bản ghi từ database dựa theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public MISAEntity GetCustomerById(Guid entityId)
        {
            var response = _dataAccessBaseRepository.GetCustomerById(entityId);
            return response;
        }
        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<MISAEntity> GetPaging(int pageIndex, int pageSize)
        {
            var response = _dataAccessBaseRepository.GetPaging(pageIndex, pageSize);
            return response;
        }
        /// <summary>
        /// Insert 1 bản ghi vào database, nhận dữ liệu từ dataAccessBaseRepository, validate dữ liệu, rồi đẩy dữ liệu về controller
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Post(MISAEntity entity)
        {
            //Validate dữ liệu
            Validate(entity, true);
            var rowsAffect = _dataAccessBaseRepository.Post(entity);
            return rowsAffect;
        }
        /// <summary>
        /// Update 1 bản ghi vào database dựa theo id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Put(MISAEntity entity)
        {
            Validate(entity, false);
            var rowsAffect = _dataAccessBaseRepository.Put(entity);
            return rowsAffect;
        }

        protected virtual void Validate(MISAEntity entity, bool isInsert) //isInsert để phân biệt giữa post và put, khi put thì không kiểm tra xem mã khách hàng có trùng hay không nữa.
        {
            //Viết những đoạn mã validate chung
        }
    }
}
