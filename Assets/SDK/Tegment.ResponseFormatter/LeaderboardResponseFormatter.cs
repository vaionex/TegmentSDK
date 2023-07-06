using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class LeaderboardResponseFormatter
    {
        public int statusCode;
        public LeaderboardResponseData data;
    }
    [Serializable]
        public class LeaderboardResponseData { 
        public string status;
        public string msg;
        public LeaderboardResponseDataArray[] leaderboard;
        public int nextPageToken;
    }
    [Serializable]
    public class LeaderboardResponseDataArray
    {
        public string paymail;
        public int totalAmount;
        public string uid;
        public int rank;
        public string displayName;
    }
}