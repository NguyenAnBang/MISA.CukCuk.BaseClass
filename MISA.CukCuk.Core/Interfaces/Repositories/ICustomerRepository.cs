using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Interfaces.Repositories
{
    public interface ICustomerRepository : IDataAccessBaseRepository<Customer>
    {
        /// <summary>
        /// Repository làm việc với database 
        /// </summary>
        /// <returns></returns>
        /// 
        //Kiểm tra xem mã khách hàng có bị trùng không
        public bool CheckDuplicateCustomerCode(string customerCode);

        //Kiểm tra xem số điện thoại có bị trùng không
        public bool CheckDuplicatePhoneNumber(string phoneNumber);

        //Kiểm tra xem email có bị trùng không
        public bool CheckDuplicateEmail(string email);
    }
}
