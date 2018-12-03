using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicArrestWarrantApi.Models
{
    [Table("Addresses")]
    public class AddressModel
    {
        [Key]
        public int AddressId { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string AddressType { get; set; }
        public int FkPersonId { get; set; }
        [ForeignKey("FkPersonId")]
        public PersonModel Person { get; set; }
    }
}