using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        [HttpGet("Children/{Id}")]
        public ActionResult<List<Node>> Children(Guid Id)
        {
            //todo
            return null;
        }

        [HttpGet("Parents/{Id}")]
        public ActionResult<List<Node>> Parents(Guid Id)
        {
            //todo
            return null;
        }

        [HttpPost]
        public IActionResult Post([FromBody] NodeViewModel nodeViewModel)
        {
            //todo
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return null;
        }
    }
}
