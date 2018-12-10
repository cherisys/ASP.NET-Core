using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("owner")]
    public class Owner:IEntity
    {
        [Key]
        [Column("OwnerId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Name is required.")]
        [StringLength(60,ErrorMessage ="Name cannot be longer than 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100,ErrorMessage = "Address cannot be longer than 100 characters.")]
        public string Address { get; set; }
    }
}
