﻿namespace P03_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        //TODO: Composite PK
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public byte ScoredGoals { get; set; }

        public byte Assists { get; set; }

        public byte MinutesPlayed { get; set; }
    }
}
