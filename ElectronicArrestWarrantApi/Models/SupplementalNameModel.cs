using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicArrestWarrantApi.Models
{
    [Table("SupplementalNames")]
    public class SupplementalNameModel
    {
        [Key]
        public int SupplementalNameId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}