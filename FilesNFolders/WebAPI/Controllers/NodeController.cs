using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Services.Interface;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly INodeService _nodeService;
        public NodeController(INodeService nodeService)
        {
            _nodeService = nodeService;
        }

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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var nodeId = _nodeService.CreateNode(nodeViewModel);
            if (nodeId == null)
            {
                return NotFound();
            }
            return Created(nodeViewModel.Path, new { id = nodeId });
        }
    }
}
