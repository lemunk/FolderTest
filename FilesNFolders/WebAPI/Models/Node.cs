using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class Node
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public NodeType Type { get; set; }
        public virtual Node Parent { get; set; }
        public Guid? ParentId { get; set; }

        public virtual IList<Node> SubNodes { get; } = new List<Node>();

    }

    public enum NodeType
    {
        Folder,
        File
    }
}
