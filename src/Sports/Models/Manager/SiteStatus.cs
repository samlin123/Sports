using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports.Models.Manager
{
    public enum SiteStatus
    {
        /// <summary>
        /// 保留
        /// </summary>
        Reservation,

        /// <summary>
        /// 未确认
        /// </summary>
        NotConfirm,

        /// <summary>
        /// 确认未支付
        /// </summary>
        ConfirmNoPay,

        /// <summary>
        /// 已经支付
        /// </summary>
        Paid,

        /// <summary>
        /// 到付
        /// </summary>
        PaidArrival
    }
}