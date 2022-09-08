﻿using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Brands.Commands.CreateBrand;
using RentACar.Application.Features.Brands.Dtos;
using RentACar.Application.Features.Brands.Models;
using RentACar.Application.Features.Brands.Queries.GetListBrand;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandDto result = await Mediator.Send(createBrandCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
            BrandListViewModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }
    }
}