using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class CandidatePosition
    {
        [Key]
        public int id { get; set; }
      public int CandidateId { get; set; }
      public int PositionId { get; set; }
      public  Candidate Candidate { get; set; }
      public Position Position { get; set; }
    }
}
