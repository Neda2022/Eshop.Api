
using Common.Application;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Query.Sellers.DTOs;

namespace Shop.Presentation.Facade.Sellers;

public interface ISellerFacad
    {
    Task<OperationResult> CreateSeller(CreateSellerCommand command);
    Task<OperationResult> EditSeller(EditSellerCommand command);

    Task<SellerDto?> GetSellerById(long sellerId);
    Task<SellerFilterResult> GetSellersByFilter(SellerFilterParam filterParams);
}

