using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDP.Model
{
    [Table("EmpDocs")]
    public class EmpDocs
    {
        [Key]
        [Column(Order = 0)]
        [ScaffoldColumn(false)]
        public int empId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int docId { get; set; }
        public string docPath { get; set; }
        [NotMapped]
        public string docName { get; set; }
    }
}
