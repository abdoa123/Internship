using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDP.Model
{
    [Table("Units")]
    public class Units
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ScaffoldColumn(false)]
        public int unitId { get; set; }
        public string unitName { get; set; }
        public string unitCode { get; set; }
        public int departmentId { get; set; }
        [NotMapped]
        public string departmentName { get; set; }
    }
}
