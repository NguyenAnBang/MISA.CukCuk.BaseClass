using Microsoft.Extensions.Configuration;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using Dapper;
using MySqlConnector;
using System.Data;


namespace MISA.CukCuk.Infrastructure.Repositories
{
    public class CustomerRepository : DataAccessBaseRepository<Customer>, ICustomerRepository
    {        
        /// <summary>
        /// Check trùng mã khách hàng
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public bool CheckDuplicateCustomerCode(string customerCode)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                //Check trùng mã khách hàng
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_CustomerCode", customerCode);
                var Exists = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return Exists;
            }                      
        }

        public bool CheckDuplicateEmail(string email)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                //Check trùng số điện thoại
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@d_Email", email);
                var Exists = dbConnection.QueryFirstOrDefault<bool>("Proc_D_CheckCustomerEmailExist", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return Exists;
            }
        }

        public bool CheckDuplicatePhoneNumber(string phoneNumber)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                //Check trùng số điện thoại
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_PhoneNumber", phoneNumber);
                var Exists = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckPhoneNumberExists", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return Exists;
            }
        }


    }
}
