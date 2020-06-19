namespace Catstagram.Server.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Validation.Cat;

    public class Cat
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(MaxDescription)]
        public string Description { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}