

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Domain.Entities.ProductAgg.Repository;
using Shop.Domain.Entities.ProductAgg.Services;

namespace Shop.Application.Productes.Edit;

internal class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
{
    private readonly IProductRepository _repository;
    private readonly IProductDomainService _domainService;
    private readonly IFileService _fileSercvice;

    public EditProductCommandHandler(IProductRepository repository,
        IProductDomainService domainService, IFileService fileSercvice)
    {
        _repository = repository;
        _domainService = domainService;
        _fileSercvice = fileSercvice;
    }

    public async Task<OperationResult> Handle(EditProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetTracking(request.ProductId);
        if (product == null)
            return OperationResult.NotFound();
        product.Edit(request.Title, request.ImageName, request.Description, request.CategoryId,
            request.SubCategoryId, request.SeconderyCategoryId, request.Slug, request.SeoData,
            _domainService);
      await  _repository.Save();
        return OperationResult.Success();

    }
}



