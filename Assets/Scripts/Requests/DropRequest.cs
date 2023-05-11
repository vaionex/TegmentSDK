using System;

[Serializable]
public class DropRequest
{
    public DropData[] dataArray;
}
[Serializable]
public class DropData
{
    public string to;
    public double amount;
    public string notes;
    public string tokenId;
    public int sn;
}