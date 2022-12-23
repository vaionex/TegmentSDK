using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class API_constants {
    public const string baseURL = "https://api.relysia.com";

}

[System.Serializable]
public class ResetPassData
{
    public string status;
    public string message;
}
[System.Serializable]
public class ResetPassDataRoot
{
    public int statusCode;
    public ResetPassData data;
}
[System.Serializable]

public class AuthData
{
    public string status;
    public string msg;
    public string token;

    public string userId;
}
[System.Serializable]
public class AuthDataRoot
{
    public int statusCode;
    public AuthData data;
}

[System.Serializable]
public class UserData
{
    public string status;
    public string msg;
    public UserDetails userDetails;
}

[System.Serializable]
public class UserDataRoot
{
    public int statusCode;
    public UserData data;
}

[System.Serializable]
public class UserDetails
{
    public string userId;
    public object displayName;
    public string photoUrl;
    public string passwordHash;
    public long passwordUpdatedAt;
    public string validSince;
    public string lastLoginAt;
    public string createdAt;
    public DateTime lastRefreshAt;
    public string photo;
    public string phoneNumber;
}

[System.Serializable]
public class SendPaymentData
{
    public string status;
    public string msg;
    public List<string> txIds;
    public List<object> errors;
}

[System.Serializable]
public class SendPaymentRootData
{
    public int statusCode;
    public SendPaymentData data;
}

[System.Serializable]
public class AddressData
{
    public string status;
    public string msg;
    public string address;
    public string paymail;
}

[System.Serializable]
public class AddressDataRoot
{
    public int statusCode;
    public AddressData data;
}

