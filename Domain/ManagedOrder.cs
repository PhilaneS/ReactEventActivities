using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ManagedOrder
    {
        [Key]
        public int OrderId { get; set; }

        
        public string OrderNumber { get; set; }

        public string WareHouse { get; set; }

        public string PuurchaseOrderNumber { get; set; }

        public string OrderType { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public string OrderDate { get; set; }

        public string OrderInDate { get; set; }

        public string HoldName { get; set; }    
        public string TotalUnits { get; set; }
        public string Value { get; set; }

        public string GrossWeight { get; set; }

        public string HoldReleaseDate { get; set; }
    }
}