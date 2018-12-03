using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicArrestWarrantApi.Models
{
    [Table("Persons")]
    public class PersonModel
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string AliasName { get; set; }
        public string SafeAtHomeNumber { get; set; }
        public string DriversLicenseNumber { get; set; }
        public string DriversLicenseIssuingStateCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Ssn { get; set; }
        public string StateIdNumber { get; set; }
        public string PersonType { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Race { get; set; }
        public int Gender { get; set; }
        public int FkEntryId { get; set; }

        [ForeignKey("FkEntryId")]
        public EntryModel Entry { get; set; }
    }
}