using AutoMapper;
using FluentValidation;
using FullMono.Repository.Core;
using FullMono.Repository.Entities;
using FullMono.Service.Validators;
using FullMono.Shared.Dtos;

namespace FullMono.Service.Services
{
    public class ProductService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<ProductDto> productValidator) : IProductService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<ProductDto> _productValidator = productValidator;

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
        {
            await ValidationHelper.ValidateDtoAsync(productDto, _productValidator);
            var product = _mapper.Map<Product>(productDto);
            // To be moved!!
            product.CreatedOn = DateTime.Now;
            product.CreatedBy = "Admin";

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> UpdateProductAsync(ProductDto productDto)
        {
            await ValidationHelper.ValidateDtoAsync(productDto, _productValidator);
            var product = _mapper.Map<Product>(productDto);
            // To be moved!!
            product.UpdatedOn = DateTime.Now;
            product.UpdatedBy = "Admin";
            _unitOfWork.Products.Update(product);

            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return false;

            _unitOfWork.Products.Remove(product);
            return await _unitOfWork.CompleteAsync() > 0;
        }
    }
}
