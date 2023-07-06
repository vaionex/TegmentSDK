using System;

namespace Tegment.ResponseFormatter
{
    [Serializable]
    public class APIResponseFormatter<T>
    {
        public int statusCode;
        public T data;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
}
