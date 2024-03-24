
using Common.Application;
using MediatR;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.GetByFilter;
using Shop.Query.Sellers.GetById;

namespace Shop.Presentation.Facade.Sellers;

public class SellerFacad: ISellerFacad
{
    private readonly IMediator _mediator;

    public SellerFacad(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> CreateSeller(CreateSellerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditSeller(EditSellerCommand command)
    {
        return await _mediator.Send(command);

    }
    public async Task<SellerDto?> GetSellerById(long sellerId)
    {
        return await _mediator.Send(new GetSellerByIdQuery(sellerId));

    }

    

    public async Task<SellerFilterResult> GetSellersByFilter(SellerFilterParam filterParams)
    {
        return await _mediator.Send(new GetSellerByFilterQuery(filterParams));
    }
}

