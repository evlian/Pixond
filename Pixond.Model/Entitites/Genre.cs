using Pixond.Model.Entities;
using System;
using System.Collections.Generic;

namespace Pixond.Model
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}
