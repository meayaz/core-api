using AutoMapper;
using CoreApi.Domain;
using CoreApi.Domain.Response;
using CoreApi.Domain.Service;
using CoreApi.Extensions;
using CoreApi.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericService<Product> productService;

        private readonly IMapper mapper;

        public ProductController(IGenericService<Product> productService, IMapper mapper)
        {
            this.productService = productService;

            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            BaseResponse<IEnumerable<Product>> productListResponse = await productService.GetWhere(x => x.Id > 0);

            if (productListResponse.Success)
            {
                return Ok(productListResponse.Extra);
            }
            else
            {
                return BadRequest(productListResponse.ErrorMessage);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFindById(int id)
        {
            BaseResponse<Product> productResponse = await productService.GetById(id);

            if (productResponse.Success)
            {
                return Ok(productResponse.Extra);
            }
            else
            {
                return BadRequest(productResponse.ErrorMessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductResource productResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                Product product = mapper.Map<ProductResource, Product>(productResource);

                var productResponse = await productService.Add(product);

                if (productResponse.Success)
                {
                    return Ok(productResponse.Extra);
                }
                else
                {
                    return BadRequest(productResponse.ErrorMessage);
                }
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(ProductResource productResource, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                Product product = mapper.Map<ProductResource, Product>(productResource);

                product.Id = id;

                var productResponse = await productService.Update(product);

                if (productResponse.Success)
                {
                    return Ok(productResponse.Extra);
                }
                else
                {
                    return BadRequest(productResponse.ErrorMessage);
                }
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            BaseResponse<Product> productResponse = await productService.Delete(id);

            if (productResponse.Success)
            {
                return Ok(productResponse.Extra);
            }
            else
            {
                return BadRequest(productResponse.ErrorMessage);
            }
        }
    }
}