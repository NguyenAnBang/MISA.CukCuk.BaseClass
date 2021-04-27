using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.Core.Interfaces.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.CukCuk.Infrastructure.Repositories
{
    public class DataAccessBaseRepository<MISAEntity> : IDataAccessBaseRepository<MISAEntity> where MISAEntity : class
    {

        protected string connectionString =  "" +
            "Host = 47.241.69.179; " +
            "Port = 3306; " +
            "Database = MF0_NVManh_CukCuk02; " +
            "User Id= dev; " +
            "Password = 12345678; " +
            "Convert Zero Datetime = True;";

        protected IDbConnection dbConnection;

        string tableName = typeof(MISAEntity).Name;

        /// <summary>
        /// Lấy tất cả dữ liệu từ database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MISAEntity> GetAll()
        {

            using (dbConnection = new MySqlConnection(connectionString))
            {
                var response = dbConnection.Query<MISAEntity>($"Proc_Get{tableName}s", commandType: CommandType.StoredProcedure);
                return response;
            }
        }

        public MISAEntity GetCustomerById(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{tableName}Id", entityId);

                var response = dbConnection.QueryFirstOrDefault<MISAEntity>($"Proc_Get{tableName}ById", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return response;
            }
        }

        public int Post(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var rowsAffect = dbConnection.Execute($"Proc_Insert{tableName}", param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

        public int Put(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                //Return dữ liệu
                var rowsAffect = dbConnection.Execute($"Proc_Update{tableName}", param: entity, commandType: CommandType.StoredProcedure);

                return rowsAffect;
            }
        }

        public int Delete(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{tableName}Id", entityId);

                var rowsAffect = dbConnection.Execute($"Proc_Delete{tableName}", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }              
        }

        public IEnumerable<MISAEntity> GetPaging(int pageIndex, int pageSize)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                //Return dữ liệu
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_PageIndex", pageIndex);
                dynamicParameters.Add("@m_PageSize", pageSize);

                var response = dbConnection.Query<MISAEntity>($"Proc_Get{tableName}Paging", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return response;
            }
        }
    }
}
