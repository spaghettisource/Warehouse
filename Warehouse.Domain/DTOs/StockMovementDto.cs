using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Domain.Dtos
{
    public class StockMovementDto
    {
        public int MovementID { get; set; } // Optional: for updates

        [Required]
        public int WarehouseID { get; set; } // The ID of the warehouse

        [Required]
        public int ProductID { get; set; } // The ID of the product

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public int Amount { get; set; } // Quantity of the product moved

        [Required]
        public DateTime Date { get; set; } // Date of the movement

        [Required]
        public bool IsImport { get; set; } // True for Import, False for Export
    }
}
