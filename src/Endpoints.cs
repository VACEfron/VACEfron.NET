using System;
using System.IO;

namespace VACEfron.NET
{
    /// <summary>
    /// Class which contains all methods for the endpoints.
    /// </summary>
    public static class VACEfronEndpoint
    {
        /// <summary>
        /// Returns a MemoryStream for a batman slap meme.
        /// </summary>
        public static MemoryStream BatmanSlap(string text1, string text2, string batmanAvatarUrl = null, string robinAvatarUrl = null)
        {
            return RequestFunctions.ImageRequest($"batmanslap?text1={text1}&text2={text2}{(batmanAvatarUrl != null ? $"&batman={batmanAvatarUrl}" : string.Empty)}{(robinAvatarUrl != null ? $"&robin={robinAvatarUrl}" : string.Empty)}");
        }

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
        /// Returns a MemoryStream for a distracted boyfriend meme.
        /// </summary>
        public static MemoryStream DistractedBoyfriend(string boyfriendAvatarURL, string womanAvatarURL, string girlfriendAvatarURL)
        {
            return RequestFunctions.ImageRequest($"distractedbf?boyfriend={boyfriendAvatarURL}&woman={womanAvatarURL}&girlfriend={girlfriendAvatarURL}");
        }

        /// <summary>
        /// Returns a MemoryStream for a dock of shame meme.
        /// </summary>
        public static MemoryStream DockOfShame(string avatarUrl)
        {
            return RequestFunctions.ImageRequest($"dockofshame?user={avatarUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for a Goku drip meme.
        /// </summary>
        public static MemoryStream Drip(string avatarUrl)
        {
            return RequestFunctions.ImageRequest($"drip?user={avatarUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for an Among Us ejected meme.
        /// </summary>
        public static MemoryStream Ejected(string name, bool wasImposter, EjectColor crewmateColor = EjectColor.Random)
        {
            string color;
            if (crewmateColor == EjectColor.Random)
            {
                Array values = Enum.GetValues(typeof(EjectColor));
                color = values.GetValue(new Random().Next(values.Length - 1)).ToString().ToLower();
            }
            else
                color = crewmateColor.ToString().ToLower();

            return RequestFunctions.ImageRequest($"ejected?name={name}&imposter={wasImposter}&crewmate={color}");
        }

        /// <summary>
        /// Returns a MemoryStream for an Among Us emergency meeting meme.
        /// </summary>
        public static MemoryStream EmergencyMeeting(string text)
        {
            return RequestFunctions.ImageRequest($"emergencymeeting?text={text}");
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
                $"{(!string.IsNullOrEmpty(rankCard.CustomBackgroundUrl) ? $"&custombg={rankCard.CustomBackgroundUrl}" : string.Empty)}" +
                $"&level={rankCard.Level}" +
                $"&rank={rankCard.Rank}" +
                $"&currentxp={rankCard.CurrentXp}" +
                $"&nextlevelxp={rankCard.NextLevelXp}" +
                $"&previouslevelxp={rankCard.PreviousLevelXp}" +
                $"{(!string.IsNullOrEmpty(rankCard.XpColorHex) ? $"&xpcolor={rankCard.XpColorHex.Replace("#", string.Empty)}" : string.Empty)}" +
                $"{(rankCard.IsBoosting != null ? $"&isboosting={rankCard.IsBoosting}" : string.Empty)}" +
                $"{(rankCard.CircleAvatar != null ? $"&circleavatar={rankCard.CircleAvatar}" : string.Empty)}");
        }

        /// <summary>
        /// Returns a MemoryStream for a stonks meme.
        /// </summary>
        public static MemoryStream Stonks(string avatarUrl, bool notStonks = false)
        {
            return RequestFunctions.ImageRequest($"stonks?user={avatarUrl}&notstonks={notStonks}");
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

        /// <summary>
        /// Returns a MemoryStream for a wolverine meme.
        /// </summary>
        public static MemoryStream Wolverine(string avatarUrl)
        {
            return RequestFunctions.ImageRequest($"wolverine?user={avatarUrl}");
        }

        /// <summary>
        /// Returns a MemoryStream for a woman yelling at cat meme.
        /// </summary>
        public static MemoryStream WomanYellingAtCat(string womanAvatarUrl, string catAvatarUrl)
        {
            return RequestFunctions.ImageRequest($"womanyellingatcat?woman={womanAvatarUrl}&cat={catAvatarUrl}");
        }
    }
}
