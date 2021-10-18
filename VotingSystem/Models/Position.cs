using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class Position
    {
        [Key]
        public int positionId { get; set; }
        public string PositionName { get; set; }
        public int limit { get; set; }
    }
}
