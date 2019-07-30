using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDP.Model
{
    [Table("Jobs")]
    public class Jobs 

    {
        [Key]
        [ScaffoldColumn(false)]
        public int jobId { get; set; }
        public string jobTitle { get; set; }
        public int unitId { get; set; }
    }
}
