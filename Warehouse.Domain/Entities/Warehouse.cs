using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Domain.Entities
{
    public class Warehouse
    {
        [Key]
        public int WarehouseID { get; set; } // Primary Key

        [Required]
        [MaxLength(100)]
        public string WarehouseName { get; set; } // Name of the warehouse

        [Required]
        public float MaxStockAmount { get; set; } // Maximum capacity of the warehouse

        [Required]
        public bool IsHazardousOnly { get; set; } // Indicates if the warehouse stores only hazardous products

        // Navigation property to StockMovements
        public ICollection<StockMovement> StockMovements { get; set; }
    }
}
