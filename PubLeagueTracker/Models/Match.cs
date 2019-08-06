using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PubLeagueTracker.Models
{
    public class Match : IValidatableObject
    {
        public int MatchId { get; set; }

        [Display(Name = "Season")]
        [Required]
        public int SeasonId { get; set; }

        public string Location { get; set; }

        [Display(Name = "Match Date")]
        public DateTime MatchDate { get; set; }

        public Season Season { get; set; }

        public List<MatchDetail> MatchDetail { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MatchDetail.Count != 2)
            {
                yield return new ValidationResult($"A match must have two teams.", new[] { "MatchDetail" });
            }

            var homeTeams = MatchDetail.Where(md => md.IsHomeTeam).Count();
            if (homeTeams != 1)
            {
                yield return new ValidationResult($"A match must have only one home team.", new[] { "MatchDetail" });
            }

            if (!MatchDetail.Select(md => md.TeamId).Distinct().Skip(1).Any())
            {
                yield return new ValidationResult($"Home and Away team cannot be the same", new[] { "MatchDetail" });
            }
        }
    }

    public class MatchDetail
    {
        public int MatchDetailId { get; set; }

        [Required]
        public int MatchId { get; set; }

        [Required]
        [Display(Name = "Team")]
        public int TeamId { get; set; }

        [Display(Description = "Is Home Team?", Name = "Is Home Team?")]
        public bool IsHomeTeam { get; set; }

        [Display(Description = "Score")]
        public int? Score { get; set; }

        public Team Team { get; set; }
        public Match Match { get; set; }
    }
}
