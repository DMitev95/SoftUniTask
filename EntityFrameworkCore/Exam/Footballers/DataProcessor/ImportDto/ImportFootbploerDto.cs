﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Footballers.Data.Models.Enums;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImportFootbploerDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [XmlElement("ContractStartDate")]
        [Required]
        public string ContractStartDate { get; set; }

        [XmlElement("ContractEndDate")]
        [Required]
        public string ContractEndDate { get; set; }

       

        [XmlElement("BestSkillType")]
        [EnumDataType(typeof(BestSkillType))]
        public int BestSkillType { get; set; }
        [XmlElement("PositionType")]
        [EnumDataType(typeof(PositionType))]
        public int PositionType { get; set; }
    }
}
