using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarltonsAutoGroupApi.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string State { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string PhoneNumber { get; set; }
    }
}
