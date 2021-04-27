using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repositories;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Services
{
    public class CustomerGroupServices : DataAccessBaseServices<CustomerGroup>, ICustomerGroupServices
    {
        ICustomerGroupRepository _customerGroupRepository;
        public CustomerGroupServices(ICustomerGroupRepository customerGroupRepository) : base(customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }

        protected override void Validate(CustomerGroup entity, bool isInsert)
        {
            base.Validate(entity, isInsert);
        }
        //public int Delete(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<CustomerGroup> GetAll()
        //{
        //    var customerGroups = _customerGroupRepository.GetAll();
        //    return customerGroups;
        //}

        //public CustomerGroup GetCustomerById(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Post(CustomerGroup customer)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Put(Guid id, CustomerGroup customer)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
