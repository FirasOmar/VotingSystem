using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class VotingDBContext : DbContext
    {
        public VotingDBContext()
        {

        }

        public VotingDBContext(DbContextOptions<VotingDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Voter> Voter { get; set; }
        public virtual DbSet<Candidate> Candidate{get;set;}
        public virtual DbSet<User>User {get;set;}
        public virtual DbSet<Position>Position {get;set;}
        public virtual DbSet<VoteResult>VoteResult{ get; set; }
        public virtual DbSet<CandidatePosition>CandidatePosition {get;set;}

}
}
