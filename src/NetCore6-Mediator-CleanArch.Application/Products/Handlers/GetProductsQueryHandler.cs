﻿using MediatR;
using NetCore6_Mediator_CleanArch.Application.Products.Queries;
using NetCore6_Mediator_CleanArch.Domain.Entities;
using NetCore6_Mediator_CleanArch.Domain.Interfaces;

namespace NetCore6_Mediator_CleanArch.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentException(nameof(productRepository));
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}