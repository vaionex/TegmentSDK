using System;
[Serializable]
public class RawTxRequest
{
    public RawTxData[] dataArray;
}
[Serializable]
public class RawTxData
{
    public string to;
    public double amount;
}