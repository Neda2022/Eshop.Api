
using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Productes.AddImage;

public record AddProductImageCommand(long ProductId,IFormFile ImageFile, int Sequence) :IBaseCommand;

