using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        //SongId – integer, Primary Key
        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }
        //Song – the performer's Song (required)
        public virtual Song Song { get; set; }

        [ForeignKey(nameof(Performer))]
        //PerformerId – integer, Primary Key
        public int PerformerId { get; set; }

        //Performer – the song's Performer (required)
        public virtual Performer Performer { get; set; }

    }
}
