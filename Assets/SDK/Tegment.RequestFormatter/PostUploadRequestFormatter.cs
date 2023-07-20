using System;

namespace Tegment.RequestFormatter
{
    [Serializable]
    public class PostUploadRequestFormatter 
    {
        public PostUploadRequestData[] dataArray;
    }
    [Serializable]
    public class PostUploadRequestData {
        public string[] notes;
    }
}
