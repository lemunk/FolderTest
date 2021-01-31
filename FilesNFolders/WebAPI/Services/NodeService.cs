using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.DAL;
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
            var nodez = _context.Set<Node>().Where(x => x.Id == id).ToList();
            var nodes = new List<Node>();
            foreach (var node in nodez)
            {
                nodes.AddRange(SearchChildren(node));
            }
            return nodes;
        }

        public List<Node> ListParents(string name)
        {
            var source = _context.Node.Where(x => x.Name.ToLower() == name.ToLower()).ToList();
            var nodes = new List<Node>();
            foreach (var node in source)
            {
                nodes.AddRange(SearchParents(node));
            }
            return nodes;
        }

        private bool PathAlreadyExists(string path)
        {
            if (_context.Node.Any(x => x.Path == path))
            {
                return true;
            }
            return false;
        }

        private List<Node> SearchChildren(Node node)
        {
            var childeren = new List<Node>();

            var child = _context.Set<Node>().Where(x => x.ParentId == node.Id).ToList();
            if (child.Count > 0)
            {
                foreach (var x in child)
                {
                    childeren.Add(x);
                    SearchChildren(x);
                }
            }
            return childeren;
        }

        private List<Node> SearchParents(Node node)
        {
            var parents = new List<Node>();

            var parent = _context.Set<Node>().FirstOrDefault(x => x.Id == node.ParentId);
            if (parent != null)
            {
                parents.Add(parent);
                SearchParents(parent);
            }
            return parents;
        }
    }
}
