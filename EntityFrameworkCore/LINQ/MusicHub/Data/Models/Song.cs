using MusicHub.Common;
using MusicHub.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }
        //Id – integer, Primary Key
        [Key]
        public int Id { get; set; }

        //Name – text with max length 20 (required)
        [Required]
        [MaxLength(GlobalConstants.SongNameMxLenght)]
        public string Name { get; set; }

        //Duration – timeSpan(required)
        [Required]
        public TimeSpan Duration { get; set; }

        //CreatedOn – date(required)
        [Required]
        public DateTime CreatedOn { get; set; }

        //Genre ¬– genre enumeration with possible values: "Blues, Rap, PopMusic, Rock, Jazz" (required)
        [Required]
        public Genre Genre { get; set; }

        //AlbumId – integer, foreign key
        [ForeignKey(nameof(Album))]
        public int? AlbumId { get; set; }
        //Album – the song's album
        public virtual Album Album { get; set; }

        

        //WriterId – integer, Foreign key(required)
        [ForeignKey(nameof(Writer))]
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        //Price – decimal (required)
        [Required]
        public decimal Price { get; set; }

        //SongPerformers – a collection of type SongPerformer
        public virtual ICollection<SongPerformer> SongPerformers { get; set; }

    }
}
