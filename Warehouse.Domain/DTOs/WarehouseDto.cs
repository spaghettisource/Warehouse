using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Domain.Entities
{
    public class WarehouseDto
    {
        public int WarehouseID { get; set; }

        public string WarehouseName { get; set; }

        public int MaxStockAmount { get; set; }

        public bool IsHazardousOnly { get; set; }

        public List<string> StockMovements { get; set; }
    }
}
