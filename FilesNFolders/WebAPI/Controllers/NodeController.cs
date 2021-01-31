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
            var nodes = _nodeService.ListChildren(Id);

            if (nodes == null)
            {
                return Conflict();
            }

            return nodes;
        }

        [HttpGet("Parents/{name}")]
        public ActionResult<List<Node>> Parents(string name)
        {
            var nodes = _nodeService.ListParents(name);

            if (nodes == null)
            {
                return Conflict();
            }
            return nodes;
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
