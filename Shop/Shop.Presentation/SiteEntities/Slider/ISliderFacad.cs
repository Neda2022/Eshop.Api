
using Common.Application;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Query.SiteEntities.Sliders.DTOs;

namespace Shop.Presentation.Facade.SiteEntities.Slider;

public interface ISliderFacad
    {
    Task<OperationResult> CreateSlider(CreateSliderCommand command);
    Task<OperationResult> EditSlider(EditSliderCommand command);
    //Task<OperationResult> DeleteSlider(long sliderId);

    Task<SliderDto?> GetSliderById(long id);
    Task<List<SliderDto>> GetSliders();
}
