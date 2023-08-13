using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }

        public DateTime ContentCreationDate { get; set; }

        public bool ContentStatus { get; set; }

        public int HeadingId { get; set; }

        public virtual Heading Heading { get; set; }

        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
