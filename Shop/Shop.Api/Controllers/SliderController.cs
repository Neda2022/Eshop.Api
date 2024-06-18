using Common.Asp.NetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Domain.Entities.RoleAgg.Enums;
using Shop.Presentation.Facade.SiteEntities.Slider;
using Shop.Query.SiteEntities.Sliders.DTOs;

namespace Shop.Api.Controllers
{
    [PermissionChecker(Permission.CRUD_Slider)]

    public class SliderController : ApiController
    {
        private readonly ISliderFacad _sliderFacad;

        public SliderController(ISliderFacad sliderFacad)
        {
            _sliderFacad = sliderFacad;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<List<SliderDto>>> GetList()
        {
            var result = await _sliderFacad.GetSliders();
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<SliderDto?>> GetById(long id)
        {
            var result = await _sliderFacad.GetSliderById(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> Create([FromForm] CreateSliderCommand command)
        {
            var result = await _sliderFacad.CreateSlider(command);
            return CommandResult(result);
        }


        [HttpPut]
        public async Task<ApiResult> Edit([FromForm] EditSliderCommand command)
        {
            var result = await _sliderFacad.EditSlider(command);
            return CommandResult(result);
        }

        [HttpDelete("{sliderId}")]
        public async Task<ApiResult> Delete(long sliderId)
        {
            var result = await _sliderFacad.DeleteSlider(sliderId);
            return CommandResult(result);
        }


    }
}
