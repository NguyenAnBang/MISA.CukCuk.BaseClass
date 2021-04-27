using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Exceptions;
using MISA.CukCuk.Core.Interfaces.Repositories;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Services
{
    public class CustomerServices : DataAccessBaseServices<Customer>, ICustomerServices
    {
        ICustomerRepository _customerRepository;
        public CustomerServices(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        protected override void Validate(Customer entity, bool isInsert)
        {
            //base.Validate(entity); //Nhận mã từ base
            if (entity is Customer) //Ép kiểu
            {
                var customer = entity as Customer;
                if(isInsert == false)
                {
                    CustomerException.CheckNullCustomerId(entity.CustomerId);
                }
                else
                {
                    //Kiểm tra xem customerCode đã tồn tại chưa (phía server) (duplicate)
                    var isCustomerCodeExists = _customerRepository.CheckDuplicateCustomerCode(customer.CustomerCode);
                    if (isCustomerCodeExists == true)
                    {
                        throw new CustomerException("Mã khách hàng đã tồn tại trên hệ thống!.");
                    }

                    //Kiểm tra email đã tồn tại chưa (phía server)
                    var isEmailExists = _customerRepository.CheckDuplicateEmail(customer.CustomerCode);
                    if (isEmailExists == true)
                    {
                        throw new CustomerException("Email đã tồn tại trên hệ thống!.");
                    }

                    //Kiểm tra số điện thoại đã tồn tại chưa (phía server)
                    var isPhoneNumberExists = _customerRepository.CheckDuplicatePhoneNumber(customer.CustomerCode);
                    if (isPhoneNumberExists == true)
                    {
                        throw new CustomerException("Số điện thoại đã tồn tại trên hệ thống!.");
                    }
                }
                
                //Kiểm tra xem customerCode có null hay không (phía client)
                CustomerException.CheckNullCustomerCode(customer.CustomerCode);
                //static là gọi luôn, không cần khởi tạo phương thức gọi đến nó
                //Kiểm tra xem id có null hay không (phía client)

                //Kiểm tra email hợp lệ không (phía client, không cần kết nối database)
                CustomerException.CheckValidEmail(customer.Email);
                
                //Kiểm tra số điện thoại hợp lệ không
                CustomerException.CheckValidPhoneNumber(customer.PhoneNumber);
                
            }
        }
        ///// <summary>
        ///// Xóa 1 bản ghi theo id, nhận giá trị từ customerRepository
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public int Delete(Guid id)
        //{
        //    var rowsAffect = _customerRepository.Delete(id);
        //    return rowsAffect;
        //}

        ///// <summary>
        ///// Lấy tất cả bản ghi từ database, nhận giá trị từ customerRepository
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<Customer> GetAll()
        //{
        //    var customers = _customerRepository.GetAll();
        //    return customers;
        //}

        ///// <summary>
        ///// Lấy 1 bản ghi từ database dựa theo id, nhận giá trị từ customerRepository
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public Customer GetCustomerById(Guid id)
        //{
        //    var customer = _customerRepository.GetCustomerById(id);
        //    return customer;
        //}

        ///// <summary>
        ///// Phân trang
        ///// </summary>
        ///// <param name="pageIndex"></param>
        ///// <param name="pageSize"></param>
        ///// <returns></returns>
        //public IEnumerable<Customer> GetCustomerPaging(int pageIndex, int pageSize)
        //{
        //    var customers = _customerRepository.GetPaging(pageIndex, pageSize);
        //    return customers;
        //}

        ///// <summary>
        ///// Insert 1 bản ghi vào database, nhận dữ liệu từ customerRepository, validate dữ liệu, rồi đẩy dữ liệu về controller
        ///// </summary>
        ///// <param name="customer"></param>
        ///// <returns></returns>
        //public int Post(Customer customer)
        //{
        //    //Validate dữ liệu

        //    var rowsAffect = _customerRepository.Post(customer);

        //    return rowsAffect;
        //}

        ///// <summary>
        ///// Update 1 bản ghi vào database dựa theo id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="customer"></param>
        ///// <returns></returns>
        //public int Put(Customer customer)
        //{
        //    //Validate dữ liệu
        //    //Kiểm tra email hợp lệ
        //    CustomerException.CheckValidEmail(customer.Email);
        //    //Kiểm tra số điện thoại hợp lệ
        //    CustomerException.CheckValidPhoneNumber(customer.PhoneNumber);

        //    var rowsAffect = _customerRepository.Put(customer);
        //    return rowsAffect;
        //}
    }
}
