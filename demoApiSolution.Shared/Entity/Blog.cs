using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoApiSolution.Shared.Entity
{
    [Table(nameof(Blog))]
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Topic { get; set; }
        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
