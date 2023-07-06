using System;

namespace Tegment.RequestFormatter
{
    [Serializable]
    public class PostUploadRequestFormatter 
    {
        public PostUploadRequestData[] data;
    }
    [Serializable]
    public class PostUploadRequestData {
        public string[] notes;
    }
}
