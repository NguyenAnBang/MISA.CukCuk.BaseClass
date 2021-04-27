using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.CukCuk.Infrastructure.Repositories
{
    public class CustomerGroupRepository : DataAccessBaseRepository<CustomerGroup>, ICustomerGroupRepository
    {
    }
}
