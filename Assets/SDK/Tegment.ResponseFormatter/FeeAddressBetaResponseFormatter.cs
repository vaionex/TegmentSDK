using System;

namespace Tegment.ResponseFormatter {
    [Serializable]
    public class FeeAddressBetaResponseFormatter
    {
        public int statusCode;
        public FeeAddressBetaResponseFormatterData data;
    }
    [Serializable]
    public class FeeAddressBetaResponseFormatterData
    {
        public string status;
        public string msg;
    }
}
