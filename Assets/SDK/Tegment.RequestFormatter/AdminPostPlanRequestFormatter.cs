using System;

namespace Tegment.RequestFormatter
{
    public class AdminPostPlanRequestFormatter
    {
        public string serviceType;
        public double cost;
        public int apiCallLimit;
        public double feeManagerFundPerMonth;
        public AdminPostPlanRequestFormatter_unavailableApiList unavailableApiList;
        public int projectLimit;
        public int serviceFeeManagerFillingLimit;
    }

    public class AdminPostPlanRequestFormatter_unavailableApiList
    {
        public string[] apiList;
    }
}