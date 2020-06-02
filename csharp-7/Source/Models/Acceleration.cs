using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("acceleration")]
    public class Acceleration
    {
        [Key]
        [Column("id"), Required]
        public int Id { get; set; }

        [Column("name"), Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("slug"), Required]
        [MaxLength(50)]
        public string Slug { get; set; }

        [Column("challenge_id"), Required]
        public int ChallengeId { get; set; }

        [ForeignKey("ChallengeId"), Required]
        public virtual Challenge Challenge { get; set; }

        [Column("created_at"), Required]
        public DateTime CreatedAt { get; set; }

        public ICollection<Candidate> Candidates { get; set; }

        
    }
}