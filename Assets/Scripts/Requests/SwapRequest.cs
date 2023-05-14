using System;

[Serializable]
public class SwapRequest
{
    public SwapData[] dataArray;
}
[Serializable]
public class SwapData
{
    public string swapHex;
}
