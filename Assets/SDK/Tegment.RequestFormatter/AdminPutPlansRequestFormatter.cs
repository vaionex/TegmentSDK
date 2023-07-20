using System;

namespace Tegment.RequestFormatter
{
    public class AdminPutPlansRequestFormatter
    {  
        public double cost;
        public int apiCallLimit;
        public double feeManagerFundPerMonth;
        public AdminPutPlanRequestFormatter_unavailableApiList unavailableApiList;
        public int projectLimit;
        public int serviceFeeManagerFillingLimit;
    }
    public class AdminPutPlanRequestFormatter_unavailableApiList
    {
        public string[] apiList;
    }
}
