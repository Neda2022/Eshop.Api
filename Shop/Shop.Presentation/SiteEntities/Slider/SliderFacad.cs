﻿
using Common.Application;
using MediatR;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Query.SiteEntities.Sliders.DTOs;
using Shop.Query.SiteEntities.Sliders.GetById;
using Shop.Query.SiteEntities.Sliders.GetByList;

namespace Shop.Presentation.Facade.SiteEntities.Slider;

public class SliderFacad: ISliderFacad
{
    private readonly IMediator _mediator;

    public SliderFacad(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> CreateSlider(CreateSliderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditSlider(EditSliderCommand command)
    {
        return await _mediator.Send(command);
    }

    

    public async Task<SliderDto?> GetSliderById(long id)
    {
        return await _mediator.Send(new GetSliderByIdQuery(id));

    }
    public async Task<List<SliderDto>> GetSliders()
    {
        return await _mediator.Send(new GetSliderListQuery());
    }
}