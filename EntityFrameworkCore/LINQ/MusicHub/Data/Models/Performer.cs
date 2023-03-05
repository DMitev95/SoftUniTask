using MusicHub.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        public Performer()
        {
            this.PerformerSongs = new HashSet<SongPerformer>();
        }
        //Id – integer, Primary Key
        [Key]
        public int Id { get; set; }
        //FirstName – text with max length 20 (required) 
        [Required]
        [MaxLength(GlobalConstants.PerformarName)]
        public string FirstName { get; set; }

        //LastName – text with max length 20 (required)
        [Required]
        [MaxLength(GlobalConstants.PerformarName)]
        public string LastName { get; set; }

        //Age – integer(required)
        public int Age { get; set; }

        //NetWorth – decimal (required)
        public decimal NetWorth { get; set; }

        //PerformerSongs – a collection of type SongPerformer
        public virtual ICollection<SongPerformer> PerformerSongs { get; set; }

    }
}
