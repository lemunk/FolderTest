using System;
using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Services.Interface;
using WebAPI.ViewModels;

namespace WebAPI.Services
{
    public class NodeService : INodeService
    {
        public Guid? CreateNode(NodeViewModel nodeViewModel)
        {
            throw new NotImplementedException();
        }

        public List<Node> ListChildren(Guid parentId)
        {
            throw new NotImplementedException();
        }

        public List<Node> ListParents(Guid childId)
        {
            throw new NotImplementedException();
        }
    }
}
