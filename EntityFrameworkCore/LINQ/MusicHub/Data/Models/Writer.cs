using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        public Writer() 
        { 
            this.Songs = new HashSet<Song>();
        }

        //Id – integer, Primary Key
        [Key]
        public int Id { get; set; }

        //Name – text with max length 20 (required)
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        //Pseudonym – text	
        public string Pseudonym { get; set; }
        //Songs – a collection of type Song
        public virtual ICollection<Song> Songs { get; set; }

    }
}
