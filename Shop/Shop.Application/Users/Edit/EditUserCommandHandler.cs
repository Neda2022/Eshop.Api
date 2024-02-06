
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilites;
using Shop.Domain.Entities.UserAgg.Repository;
using Shop.Domain.Entities.UserAgg.Services;

namespace Shop.Application.Users.Edit;

public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    private readonly IUsrerRepository _repository;
    private readonly IDomainUserService _domainService;
    private readonly IFileService _fileService;

    public EditUserCommandHandler(IUsrerRepository repository, IDomainUserService domainService, IFileService fileService)
    {
        _repository = repository;
        _domainService = domainService;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.Id);
        var oldAvatar = user.Avatar;
        if (user == null) { OperationResult.NotFound(); }
        user.Edit(request.Name, request.Family, request.PhoneNumber,
            request.Email, request.Gender, _domainService);
        if (request.Avatar != null)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.Avatar, Directories.UserAvatar);
            user.SetAvatar(imageName);
        }
        DeleteOldAvatar(request.Avatar, oldAvatar);
         await _repository.Save();
        return OperationResult.Success();
    }
    private void DeleteOldAvatar(IFormFile? avatarFile, string oldAvatar)
    {
        if (avatarFile == null || oldAvatar=="avatar.png")
            return;
        _fileService.DeleteFile(Directories.UserAvatar, oldAvatar);
    }
}

