﻿namespace VACEfron.NET
{
    public class RankCard
    {
        public string Username { get; set; }
        public string AvatarUrl { get; set; }
        public string CustomBackground { get; set; }
        public int Level { get; set; }
        public int Rank { get; set; }
        public int CurrentXp { get; set; }
        public int NextLevelXp { get; set; }
        public int PreviousLevelXp { get; set; }
        public string XpColor { get; set; }
        public bool IsBoosting { get; set; }
    }
}