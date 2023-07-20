using System;
//Response Checked
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class SwapResponseFormatter
    {
        public int statusCode;
    }
    [Serializable]
    public class SwapReaponseFormatterData
    {
        public string status;
        public string msg;
        public string[] txIds;
        public string[] errors; 
    }
}