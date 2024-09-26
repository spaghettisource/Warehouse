using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; } // Primary Key

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } // Name of the product

        [Required]
        public float SizePerUnit { get; set; } // Size of each unit of the product

        [Required]
        public bool IsHazardous { get; set; } // Indicates if the product is hazardous

        // Navigation property to StockMovements
        public ICollection<StockMovement> StockMovements { get; set; }
    }
}
