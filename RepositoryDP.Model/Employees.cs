using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDP.Model
{
    [Table("Employees")]
    public class Employees : AuditableEntity<long>

    {
        [Key]
        [ScaffoldColumn(false)]
        public int empId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public int jobId { get; set; }
        public string imagePath { get; set; }
        [NotMapped]
        public string jobTitle { get; set; }
    }
}
