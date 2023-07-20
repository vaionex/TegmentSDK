using System;
namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class DeleteUserResponseFormatter
    {
        public int statusCode;
        public DeleteUserResponseFormatterData data;
    }

    [Serializable]
    public class DeleteUserResponseFormatterData
    {
        public string status;
        public string msg;
    }
}