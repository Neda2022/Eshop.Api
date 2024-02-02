

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Shop.Domain.Entities.ProductAgg.Repository;

namespace Shop.Application.Productes.RemoveImage;

    public record RemoveProductImageCommand(long ProductId, long ImageId):IBaseCommand;
internal class RemoveProductImageCommandHandler : IBaseCommandHandler<RemoveProductImageCommand>
{
    private readonly IProductRepository _repository;
    private readonly IFileService _fileService;

    public RemoveProductImageCommandHandler(IProductRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetTracking(request.ProductId);
        if (product == null) { return OperationResult.NotFound(); }

        product.RemoveImage(request.ImageId);
        await _repository.Save();
        return OperationResult.Success();
    }

}




