using System;
using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Services.Interface
{
    public interface INodeService
    {
        Guid? CreateNode(NodeViewModel nodeViewModel);

        List<Node> ListChildren(Guid parentId);

        List<Node> ListParents(string name);
    }
}
