using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Entities
{
    public enum GenreEnum
    {
        Action,
        [Display(Name = "Science Fiction")]
        ScienceFiction,
        Comedy
    }
}
