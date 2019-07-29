using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDP.Model
{
    [Table("Attachments")]
    public class Attachments
    {
        [Key]
        [ScaffoldColumn(false)]
        public int docId { get; set; }
        public string docName { get; set; }
    }
}
