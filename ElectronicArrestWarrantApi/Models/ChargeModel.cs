using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicArrestWarrantApi.Models
{
    [Table("Charges")]
    public class ChargeModel
    {
        [Key]
        public int ChargesId { get; set; }
        public string ChargeCodeDescStatuteNumber { get; set; }
        public string ChargeCodeNcicMod { get; set; }
        public string LongDescription { get; set; }
        public DateTime ChargeDate { get; set; }
        public string ChargeLevel { get; set; }
        public string IssuingCourtCounty { get; set; }
        public string IssuingCourtJurisdiction { get; set; }
        public string CaseesAssignedJudgeNameMobar { get; set; }
        public string ServicingLawEnforcementOri { get; set; }
        public string CaseOcnNumber { get; set; }
        public string ImageOfWarrantDoc { get; set; }
        public int FkEntryId { get; set; }
        [ForeignKey("FkEntryId")]
        public EntryModel Entry { get; set; }
    }
}