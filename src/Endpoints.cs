using System.IO;

namespace VACEfron.NET
{
    /// <summary>
    /// Class which contains all methods for the endpoints.
    /// </summary>
    public static class VACEfronEndpoint
    {
        /// <summary>
        /// Returns a MemoryStream for a car reverse meme.
        /// </summary>
        public static MemoryStream CarReverse(string text)
        {
            return RequestFunctions.ImageRequest($"carreverse?text={text}");
        }

        /// <summary>
        /// Returns a MemoryStream for a change my mind meme.
        /// </summary>
        public static MemoryStream ChangeMyMind(string text)
        {
            return RequestFunctions.ImageRequest($"changemymind?text={text}");
        }

        /// <summary>
        /// Returns a MemoryStream for a first time meme.
        /// </summary>
        public static MemoryStream FirstTime(string avatarUrl)
        {
            return RequestFunctions.ImageRequest($"firsttime?user={avatarUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for a grave meme.
        /// </summary>
        public static MemoryStream Grave(string avatarUrl)
        {
            return RequestFunctions.ImageRequest($"grave?user={avatarUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for an I am speed meme.
        /// </summary>
        public static MemoryStream IAmSpeed(string avatarUrl)
        {
            return RequestFunctions.ImageRequest($"iamspeed?user={avatarUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for an I can milk you meme.
        /// </summary>
        public static MemoryStream ICanMilkYou(string faceAvatarUrl, string cowAvatarUrl)
        {
            return RequestFunctions.ImageRequest($"icanmilkyou?user1={faceAvatarUrl}&user2={cowAvatarUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for a heaven meme.
        /// </summary>
        public static MemoryStream Heaven(string avatarUrl)
        {
            return RequestFunctions.ImageRequest($"heaven?user={avatarUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for an NPC meme.
        /// </summary>
        public static MemoryStream Npc(string text1, string text2)
        {
            return RequestFunctions.ImageRequest($"npc?text1={text1}&text2={text2}");
        }

        /// <summary>
        /// Returns a MemoryStream for a custom rank card.
        /// </summary>
        public static MemoryStream RankCard(RankCard rankCard)
        {
            return RequestFunctions.ImageRequest($"rankcard" +
                $"?username={rankCard.Username.Replace("#", "%23")}" +
                $"&avatar={rankCard.AvatarUrl}" +
                $"&custombg={rankCard.CustomBackground ?? string.Empty}" +
                $"&level={rankCard.Level}" +
                $"&currentxp={rankCard.CurrentXp}" +
                $"&nextlevelxp={rankCard.NextLevelXp}" +
                $"&previouslevelxp={rankCard.PreviousLevelXp}" +
                $"&xpcolor={rankCard.XpColor?.Replace("#", string.Empty) ?? string.Empty}" +
                $"&isboosting={rankCard.IsBoosting}");
        }

        /// <summary>
        /// Returns a MemoryStream for a stonks meme.
        /// </summary>
        public static MemoryStream Stonks(string avatarUrl)
        {
            return RequestFunctions.ImageRequest($"stonks?user={avatarUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for a table flip meme.
        /// </summary>
        public static MemoryStream TableFlip(string avatarUrl)
        {
            return RequestFunctions.ImageRequest($"tableflip?user={avatarUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for a water meme.
        /// </summary>
        public static MemoryStream Water(string text)
        {
            return RequestFunctions.ImageRequest($"water?text={text}");
        }

        /// <summary>
        /// Returns a MemoryStream for a wide filter.
        /// </summary>
        public static MemoryStream Wide(string imageUrl)
        {
            return RequestFunctions.ImageRequest($"wide?image={imageUrl}");
        }
    }
}
