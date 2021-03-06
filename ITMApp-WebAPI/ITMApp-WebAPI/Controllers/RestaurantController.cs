﻿using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using BusinessLogic.DataHandler;
using Contracts;

namespace ITMApp_WebAPI.Controllers
{
    //[Authorize]
    //[RequireHttps]
    public class RestaurantController : ApiController
    {
        private RestaurantHandler _restaurantHandler = new RestaurantHandler();

        public List<RestaurantModel> Get()
        {
            return _restaurantHandler.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var restaurant = _restaurantHandler.Get(id);

            if (restaurant == null) return NotFound();

            return Ok(restaurant);
        }

        public IHttpActionResult Post(RestaurantModel restaurant)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (!_restaurantHandler.Post(restaurant)) return BadRequest("Incorrect Datainput");

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (!_restaurantHandler.Delete(id)) return BadRequest();

            return Ok();
        }

    }
}