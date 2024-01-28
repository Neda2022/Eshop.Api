

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilites;
using Shop.Domain.Entities.ProductAgg;
using Shop.Domain.Entities.ProductAgg.Repository;
using Shop.Domain.Entities.ProductAgg.Services;

namespace Shop.Application.Productes.Create;

public class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
{
   private readonly IProductRepository _repository;
   private readonly IProductDomainService _domainService;
    private readonly IFileService _fileSercvice;
    internal CreateProductCommandHandler(IProductRepository repository,
        IProductDomainService domainService,
        IFileService fileSercvice)
    {
        _repository = repository;
        _domainService = domainService;
        _fileSercvice = fileSercvice;
    }

    public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileSercvice.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);

        var product =  new Product(request.Title,
            imageName,
            request.Description,
            request.CategoryId,
            request.CategoryId,
            request.SeconderyCategoryId, 
            request.Slug,
            request.SeoData,
            _domainService);
        // Specifications  گرفتن آیدی محصول برای اضافه کردن  
         _repository.Add(product);
        var specifications= new List<ProductSpecification>();
        request.Specifications.ToList().ForEach(specification =>
        {
            specifications.Add(new ProductSpecification(specification.Key, specification.Value));
      
        });
        product.SetSpecification(specifications);
        await _repository.Save();
        return OperationResult.Success();
    }
}

