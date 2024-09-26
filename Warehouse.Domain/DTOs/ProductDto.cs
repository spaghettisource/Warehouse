using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement.Domain.Dtos;

namespace WarehouseManagement.Domain.Entities
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "The ProductName field is required.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Size per unit is required.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Size per unit must be at least 0.1.")]
        public double SizePerUnit { get; set; }

        [Required(ErrorMessage = "The IsHazardous field is required.")]
        public bool IsHazardous { get; set; }

        // Optional field
        public List<StockMovementDto> StockMovements { get; set; }
    }
}
