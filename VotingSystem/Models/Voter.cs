using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class Voter
    {
        [Key]
        public int idNo { get; set; }
       public string name { get; set; }
       public long mobileMo { get; set; }
       public bool voted { get; set; }
    }
}
