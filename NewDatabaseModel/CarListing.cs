using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace NewDatabaseModel
{
    [Table("CarListing")]
    public partial class CarListing
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Model { get; set; } = null!;

        public int Year { get; set; }

        [Unicode(false)]
        public string? Description { get; set; }

        [Column("UserID")]
        public int UserId { get; set; }

        // Navigation property to User (optional, if you have a User table)
        //[ForeignKey("UserId")]
        //[InverseProperty("CarListings")]
        //public virtual User? User { get; set; }//  // optional relationship
    }
}