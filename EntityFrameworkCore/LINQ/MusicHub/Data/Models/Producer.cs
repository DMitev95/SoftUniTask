using MusicHub.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Producer
    {
        public Producer()
        {
            this.Albums = new HashSet<Album>();    
        }
        //Id – integer, Primary Key
        [Key]
        public int Id { get; set; }
        //Name – text with max length 30 (required)
        [Required]
        [MaxLength(GlobalConstants.ProducerName)]
        public string Name { get; set; }

        //Pseudonym – text
        public string Pseudonym { get; set; }

        //PhoneNumber – text
        public string PhoneNumber { get; set; }
        //Albums – a collection of type Album
        public virtual ICollection<Album> Albums { get; set; }

    }
}
