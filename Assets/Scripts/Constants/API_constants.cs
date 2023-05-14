using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class API_constants {
    public const string baseURL = "https://api.relysia.com";

    //Authentication
    public const string signUP = "/v1/signUp";
    public const string auth = "/v1/auth";
    public const string passwordChange = "/v1/password/change";
    public const string passwordReset = "/v1/reset/password";
    //Identity
    public const string user = "/v1/user";
    //Wallets
    public const string createWallet = "/v1/createWallet";
    public const string address = "/v1/address";
    public const string allAddresses = "/v1/allAddresses";
    public const string leaderboard = "/v1/leaderboard";
    public const string wallets = "/v1/wallets";
    public const string mnemonic = "/v1/mnemonic";
    public const string balance = "/v2/balance";
    public const string history = "/v2/history";

    //Transactions
    public const string send = "/v1/send";
    public const string rawtx = "/v1/rawtx";
    public const string drop = "/v1/drop";
    public const string offer = "/v1/offer";
    public const string swap = "/v1/swap";
    public const string exchangeOffer = "/v1/exchangeOffer";
    public const string exchangeSwap = "/v1/exchangeSwap";
    public const string inspeact = "/v1/inspect";
    public const string pay = "/v1/pay";
    public const string invoice = "/v1/invoice";
    public const string paymentRequest = "/v1/paymentRequest/{invoiceId}"; //get param {invoiceId}
    public const string paymentRequest_Pay = "/v1/paymentRequest/pay/{invoiceId}";//param {invoiceId}
    public const string asm = "/v1/asm";
    public const string inspect = "/v1/inspect";

    //Smart contracts
    public const string issue = "/v1/issue";
    public const string token_v1 = "/v1/token/{id}";//Get param Token Id {id}
    public const string redeem = "/v1/redeem";
    public const string token_v2 = "/v2/token/{id}";//Get param Token Id {id}

    //Utility
    public const string URI = "/v1/URI";
    public const string tokenMetrics = "/v1/tokenMetrics";
    public const string metrics = "/v1/metrics";
    public const string currencyConversion = "/v1/currencyConversion";
    public const string transpile = "/v1/transpile";
    public const string compile = "/v1/compile";
    public const string post = "/v1/post";
    public const string sign = "/v1/sign";
    public const string upload = "/upload";


    //paymail
    public const string paymail_Get = "/v1/paymail/{paymailId}";//Get Param PaymailID
    public const string paymail_Put = "/v1/paymail";
    public const string paymail_Activate = "/v1/paymail/activate";
    public const string bsvalias_Get = "/v1/bsvalias/id/{paymail}";
    public const string bsvalias_Address = "/v1/bsvalias/address/{paymail}";
    public const string bsvalias_Verifypubkey = "/v1/bsvalias/verifypubkey/{paymail}/{pubkey}";
    public const string bsvalias_receiveTranssaction = "/v1/bsvalias/receive-transaction/{paymail}";
    public const string bsvalias_P2P_PaymentDestination = "/v1/bsvalias/p2p-payment-destination/{paymail}";
    public const string bsvalias_wellknown = "/.well-known/bsvalias";

    //Notifications
    public const string notification_Token = "/v1/notificationToken/{userId}";
    public const string send_notification = "/v1/sendnotification";

    //Delete
    public const string delete_user = "/v1/user";
    public const string delete_wallets = "/v1/wallets";// All wallets be careful
    public const string delete_notificationToken = "/v1/notificationToken/{userId}";
    public const string delete_Wallet = "/v1/wallet";// This is wallet specific

    //Administration
    public const string initBeta = "/v1/initBeta";
    public const string feeMetricsBeta = "/v1/feeMetricsBeta";
    public const string feeAddressBeta = "/v1/feeAddressBeta";
    public const string feeUtxoState = "/v1/feeUtxoState";
    public const string domain_GenerateToken = "/v1/domain/generateToken";
    public const string verifyToken = "v1/domain/{userId}/verifyToken";
    public const string admin_Setup_Post = "/admin/v1/setup";
    public const string admin_Setup_Get = "/admin/v1/setup/{serviceId}";
    public const string admin_Setup_Put = "/admin/v1/setup/{serviceId}";
    public const string admin_Setup_Delete = "/admin/v1/setup/{serviceId}";
    public const string admin_Setup_ServiceIds = "/admin/v1/setup/serviceIds";
    public const string admin_Metrics = "/admin/v1/metrics";
    public const string admin_tokenMetrics = "/admin/v1/tokenMetrics";
    public const string admin_Plans_Post = "/admin/v1/plans";
    public const string admin_Plans_Get = "/admin/v1/plans/{serviceType}";
    public const string admin_Plans_Delete = "/admin/v1/plans/{serviceType}";
    public const string admin_Plans_Put = "/admin/v1/plans/{serviceType}";
    public const string admin_Plans_List = "/admin/v1/plan/list";

    //Quota
    public const string plan_Activate = "/v1/plan/{serviceType}/activate";
    public const string quota = "/v1/plan/quota";
    public const string plan_Deactivate = "/v1/plan/deactivate";

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

[Serializable]
public class CreateWalletRoot
{
    public int statusCode;
    public CreateWalletData data;
}

[Serializable]
public class CreateWalletData
{
    public string status;
    public string msg;
    public string walletID;
}

[Serializable]
public class AllAddressesRoot
{
    public int statusCode;
    public AllAddressesData data;
}

[Serializable]
public class AllAddressesData
{
    public string status;
    public string msg;
    public string[] addressess;
}

[Serializable]
public class WalltesRoot
{
    public int statusCode;
    public WalletData data;
}

[Serializable]
public class WalletData
{
    public string status;
    public string msg;
    public WalletList[] wallets;
}
[Serializable]
public class WalletList
{
    public string walletID;
    public string walletTitle;
    public string walletLogo;
}

[Serializable]
public class MnemonicRoot
{
    public int statusCode;
    public MnemonicData data;
}
[Serializable]
public class MnemonicData
{
    public string status;
    public string msg;
    public string mnemonic;
}

[Serializable]
public class BalanceRoot
{
    public int statusCode;
    public BalanceData data;
}

[Serializable]
public class BalanceData
{
    public string status;
    public string msg;
    public BalanceData_Currency totalBalance;
    public BalanceData_Coins[] coins;
    public BalanceData_Meta meta;
}

[Serializable]
public class BalanceData_Currency
{
    public string currency;
    public int balance;
}

[Serializable]
public class BalanceData_Coins
{
    public string protocol;
    public int balance;
}

[Serializable]
public class BalanceData_Meta
{
    public string nextPageToken;
}


[Serializable]
public class RawTXDataResponse
{
    public string status;
    public string msg;
}

[Serializable]
public class RawTXRootData
{
    public int statusCode;
    public RawTXDataResponse data;
}


[Serializable]
public class DropDataResponse
{
    public string status;
    public string msg;
}

[Serializable]
public class DropTXRootData
{
    public int statusCode;
    public DropDataResponse data;
}

[Serializable]
public class OfferDataResponse
{
    public string status;
    public string msg;
}

[Serializable]
public class OfferRootData
{
    public int statusCode;
    public OfferDataResponse data;
}



[Serializable]
public class SwapDataResponse
{
    public string status;
    public string msg;
}

[Serializable]
public class SwapRootData
{
    public int statusCode;
    public SwapDataResponse data;
}


[Serializable]
public class ExchangeDataResponse
{
    public string status;
    public string msg;
}

[Serializable]
public class ExchangeRootData
{
    public int statusCode;
    public ExchangeDataResponse data;
}

[Serializable]
public class SwapOfferDataResponse
{
    public string status;
    public string msg;
}

[Serializable]
public class SwapOfferRootData
{
    public int statusCode;
    public SwapOfferDataResponse data;
}