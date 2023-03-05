using MusicHub.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }
        //Id – integer, Primary Key
        [Key]
        public int Id { get; set; }

        //Name – text with max length 40 (required)
        [Required]
        [MaxLength(GlobalConstants.AlbumNameLenght)]
        public string Name { get; set; }
        //ReleaseDate – date(required)
        [Required]
        public DateTime ReleaseDate { get; set; }
        //Price – calculated property(the sum of all song prices in the album)
        [NotMapped] //NotMapped will not create this property
        public decimal Price => this.Songs.Any() ? this.Songs.Sum(s => s.Price) : 0m;

        //ProducerId – integer, foreign key
        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; }
        //Producer – the album's producer
        public virtual Producer Producer { get; set; }
        //Songs – a collection of all Songs in the Album
        public virtual ICollection<Song> Songs { get; set; }

    }
}
