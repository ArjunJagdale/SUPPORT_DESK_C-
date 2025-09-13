using System;
using System.ComponentModel.DataAnnotations;

namespace SupportDeskAppNew.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public string Status { get; set; } = "Open";

        [Required]
        public string Priority { get; set; } = "Low"; // <-- NEW PROPERTY

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
