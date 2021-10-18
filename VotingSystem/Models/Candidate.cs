using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class Candidate
    {
        [Key]
        public int candidateId { get; set; }
        public string name { get; set; }

    }
}
