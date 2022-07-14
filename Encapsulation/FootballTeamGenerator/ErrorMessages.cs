using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public static class ErrorMessages
    {
        public const string NullOrWhiteSpace = "A name should not be empty.";
        public const string StatsRangeExeption = "{0} should be between 0 and 100.";
        public const string PlayerNotInTeam = "Player {0} is not in {1} team.";
        public const string TeamDoesntExist = "Team {0} does not exist.";
    }
}
