
namespace Tegment.Utility
{
    public static partial class PathConstants
    {
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
        public const string inspect = "/v1/inspect";
        public const string pay = "/v1/pay";
        public const string invoice = "/v1/invoice";
        public const string paymentRequest = "/v1/paymentRequest/{invoiceId}";
        public const string paymentRequest_Pay = "/v1/paymentRequest/pay/{invoiceId}";
        public const string asm = "/v1/asm";
      
        //Smart contracts
        public const string issue = "/v1/issue";
        public const string token_v1 = "/v1/token/{id}";
        public const string redeem = "/v1/redeem";
        public const string token_v2 = "/v2/token/{id}";
        public const string issue_v2 = "/v2/issue";

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
        public const string paymail_Get = "/v1/paymail/{paymailId}";
        public const string paymail_Put = "/v1/paymail";
        public const string paymail_Activate = "/v1/paymail/activate";
        public const string bsvalias_Get = "/v1/bsvalias/id/{paymailId}";
        public const string bsvalias_Address = "/v1/bsvalias/address/{paymailId}";
        public const string bsvalias_Verifypubkey = "/v1/bsvalias/verifypubkey/{paymailId}/{pubkey}";
        public const string bsvalias_receiveTranssaction = "/v1/bsvalias/receive-transaction/{paymailId}";
        public const string bsvalias_P2P_PaymentDestination = "/v1/bsvalias/p2p-payment-destination/{paymailId}";
        public const string bsvalias_wellknown = "/.well-known/bsvalias";

        //Notifications
        public const string notification_Token = "/v1/notificationToken/{userId}";
        public const string send_notification = "/v1/sendNotification";

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
}
