using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class VoteResult
    {
        [Key]
        public int id { get; set; }
        public int voterId { get; set; }
        public int candidateId { get; set; }
        public int positionId { get; set; }
        public Candidate Candidate { get; set; }
        public Voter Voter { get; set; }
        public Position Position { get; set; }

    }
}
