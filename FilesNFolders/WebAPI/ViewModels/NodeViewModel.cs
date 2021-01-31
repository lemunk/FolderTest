using System;
using System.ComponentModel.DataAnnotations;
using WebAPI.Models;

namespace WebAPI.ViewModels
{
    public class NodeViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
        public Guid? ParentId { get; set; }
        [Required]
        public NodeType Type { get; set; }
    }
}
