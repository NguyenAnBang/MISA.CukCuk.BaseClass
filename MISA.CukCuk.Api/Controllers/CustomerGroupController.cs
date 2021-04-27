using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repositories;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v2/[Controller]s")]
    [ApiController]
    public class CustomerGroupController : ControllerBase
    {
        ICustomerGroupRepository _customerGroupRepository;
        ICustomerGroupServices _customerGroupService;

        public CustomerGroupController(ICustomerGroupRepository customerGroupRepository, ICustomerGroupServices customerGroupService)
        {
            _customerGroupRepository = customerGroupRepository;
            _customerGroupService = customerGroupService;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var customerGroups = _customerGroupRepository.GetAll();
            if (customerGroups.Count() > 0) return Ok(customerGroups);
            else return NoContent();
        }

        /// <summary>
        /// Lấy bản ghi từ database theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetGetCustomerById(Guid id)
        {
            var customerGroup = _customerGroupRepository.GetCustomerById(id);
            if (customerGroup != null)
            {
                return Ok(customerGroup);
            }
            else
            {
                return NoContent();
            }
        }
        

        /// <summary>
        /// Insert 1 bản ghi vào database 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post([FromBody] CustomerGroup customer)
        {
            var rowsAffect = _customerGroupService.Post(customer);

            if (rowsAffect > 0) return Ok();
            else return NoContent();
        }

        /// <summary>
        /// Update 1 bản ghi vào database (sau khi validate dữ liệu trong service)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] CustomerGroup customer)
        {
            var rowsAffect = _customerGroupService.Put(customer);
            if (rowsAffect > 0) return Ok(rowsAffect);
            else return NoContent();
        }

        /// <summary>
        /// Xóa 1 bản ghi trong database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var rowsAffect = _customerGroupRepository.Delete(id);
            if (rowsAffect > 0) return Ok(rowsAffect);
            else return NoContent();
        }

        /// <summary>
        /// Lấy bản ghi theo phân trang
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("Paging")]

        public IActionResult GetPaging(int pageIndex, int pageSize)
        {
            var customerGroups = _customerGroupRepository.GetPaging(pageIndex, pageSize);
            if (customerGroups.Count() > 0)
            {
                return Ok(customerGroups);
            }
            else
            {
                return NoContent();
            }
        }
        

    }
}
