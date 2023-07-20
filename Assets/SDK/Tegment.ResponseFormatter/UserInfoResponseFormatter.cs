using System;
//Response checked
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class UserInfoResponseFormatter
    {
        public int statusCode;
        public UserInfoResponseData data;
    }
    [Serializable]
    public class UserInfoResponseData
    {
        public string status;
        public string msg;
        public UserDetails userDetails;
    }
    [Serializable]
    public class UserDetails
    {
        public string userId;
        public string passwordHash;
        public long passwordUpdatedAt;
        public string validSince;
        public string lastLoginAt;
        public string createdAt;
        public string lastRefreshAt;
        public string photo;
        public string displayName;
        public string phoneNumber;
    }
}
