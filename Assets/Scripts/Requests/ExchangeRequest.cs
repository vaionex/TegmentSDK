using System;

[Serializable]
public class ExchangeRequest 
{
    public ExchangeRequestRoot[] dataArray;
}

[Serializable]
public class ExchangeRequestRoot
{
    public string tokenId;
    public int sn;
    public double amount;
    public string type;
    public ExchnagePayment[] payment;
}
[Serializable]
public class ExchnagePayment
{
    public string to;
    public double amount;
}