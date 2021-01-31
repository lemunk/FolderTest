using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.DAL;
using WebAPI.Helpers;
using WebAPI.Models;
using WebAPI.Services.Interface;
using WebAPI.ViewModels;

namespace WebAPI.Services
{
    public class NodeService : INodeService
    {
        private readonly ApplicationDBContext _context;

        public NodeService(ApplicationDBContext context)
        {
            _context = context;
        }

        public Guid? CreateNode(NodeViewModel nodeViewModel)
        {
            if (PathAlreadyExists(nodeViewModel.Path))
            {
                return null;
            }

            var node = new Node
            {
                Name = nodeViewModel.Name,
                Path = nodeViewModel.Path,
                ParentId = nodeViewModel.ParentId,
                Type = nodeViewModel.Type
            };

            _context.Add(node);
            _context.SaveChanges();

            return node.Id;
        }

        public List<Node> ListChildren(Guid id)
        {
            var nodes = _context.Set<Node>().SelectManyRecursive(x => x.SubNodes).Select(x => x).ToList();
            return nodes;
        }

        public List<Node> ListParents(Guid childId)
        {
            throw new NotImplementedException();
        }

        private bool PathAlreadyExists(string path)
        {
            if (_context.Node.Any(x => x.Path == path))
            {
                return true;
            }
            return false;
        }
    }
}
