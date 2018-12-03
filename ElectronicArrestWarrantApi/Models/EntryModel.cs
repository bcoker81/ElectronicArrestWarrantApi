using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicArrestWarrantApi.Models
{
    [Table("Entries")]
    public class EntryModel
    {
        [Key]
        public int EntryId { get; set; }
        public decimal BondAmount { get; set; }
        public string BondAdditionalText { get; set; }
        public string WarrantNumber { get; set; }
        public string SigningJudge { get; set; }
        public string WarrantAdditionalText { get; set; }
        public string IssuingCourtOri { get; set; }
        public string CourtMasterCaseNumber { get; set; }
        public string ServicingOri { get; set; }

        public ICollection<ChargeModel> Charges { get; set; }
        public ICollection<PersonModel> Persons { get; set; }
    }
}