using System;

[Serializable]
public class SwapOfferRequest
{
    public SwapOfferRequestRoot[] dataArray;
}

public class SwapOfferRequestRoot
{
    public string swapId;
}
