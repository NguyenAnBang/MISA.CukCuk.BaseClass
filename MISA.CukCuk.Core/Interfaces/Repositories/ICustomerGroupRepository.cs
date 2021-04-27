using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Interfaces.Repositories
{
    public interface ICustomerGroupRepository : IDataAccessBaseRepository<CustomerGroup>
    {
        //Kiểm tra xem tên nhóm khách hàng có bị trùng không
        //public bool CheckDuplicateCustomerGroupName(string customerGroupName);
    }
}
