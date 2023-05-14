using System;

[Serializable]
public class OfferRequest
{
    public OfferData[] dataArray;
}
[Serializable]
public class OfferData
{
    public string tokenId;
    public int sn;
    public double amount;
    public double wantedAmount;
}


