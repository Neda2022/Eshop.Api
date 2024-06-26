﻿

using Common.Application;
using Shop.Domain.Entities.CategoryAgg.Repository;
using Shop.Domain.Entities.CategoryAgg.Services;

namespace Shop.Application.Categories.AddChild;

public class AddChidCategoryCommandHandler : IBaseCommandHandler<AddChidCategoryCommand,long>
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryDomainService _domainService;

    public AddChidCategoryCommandHandler(ICategoryRepository repository
        , ICategoryDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }
    public async Task<OperationResult<long>> Handle(AddChidCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetTracking(request.ParantId);
        if (category == null)
            return OperationResult<long>.NotFound();
        category.AddChild(request.Title, request.Slug, request.SeoData, _domainService);
        await _repository.Save();
        return OperationResult<long>.Success(category.Id);
    }
}

