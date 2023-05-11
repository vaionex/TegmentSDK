using System;
[Serializable]
public class SendCoinsRequest
{
    public SendCoinsData[] dataArray;
}
[Serializable]
public class SendCoinsData
{
    public string to;
    public double amount;
}