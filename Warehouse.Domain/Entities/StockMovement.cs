using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Domain.Entities
{
    public class StockMovement
    {
        [Key]
        public int MovementID { get; set; } // Primary Key

        [Required]
        public int WarehouseID { get; set; } // Foreign Key to Warehouse

        [Required]
        public int ProductID { get; set; } // Foreign Key to Product

        [Required]
        public int Amount { get; set; } // Quantity of the product moved

        [Required]
        public DateTime Date { get; set; } // Date and time of the movement

        [Required]
        public bool IsImport { get; set; } // True for Import, False for Export

        // Navigation properties
        [ForeignKey(nameof(WarehouseID))]
        public Warehouse Warehouse { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }
    }
}
