using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class Movie
    {
        public virtual int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public virtual string Title { get; set; }


        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public virtual string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public virtual decimal Price { get; set; }
        public virtual IList<Actor> Actors { get; set; }
    }

    public class Actor
    {
        public virtual int ID { get; set; }

        public virtual string Name { get; set; }
    }
}