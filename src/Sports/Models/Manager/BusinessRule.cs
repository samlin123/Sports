using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sports.Models.Manager
{
    /// <summary>
    /// 业务规则
    /// </summary>
    public class BusinessRule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RuleId { get; set; }

        /// <summary>
        /// 允许预定时间，eg:提前xxx小时预定
        /// </summary>
        public int EnableBookTime { get; set; }

        /// <summary>
        /// 最迟取消订场时间,eg:提前xxx小时取消订单
        /// </summary>
        public int LastCancelBookTime { get; set; }

        /// <summary>
        /// 开始营业时间
        /// </summary>
        public DateTime OpenTime { get; set; }

        /// <summary>
        /// 打烊时间
        /// </summary>
        public DateTime CloseTime { get; set; }

        /// <summary>
        /// 最少订场时间，单位小时
        /// </summary>
        public int LeastBookTime { get; set; }

        /// <summary>
        /// 支持到店支付
        /// </summary>
        public bool EnableArrivalPay { get; set; }
        
        /// <summary>
        /// 自动确认订单
        /// </summary>
        public bool AutoConfirmBookRecord { get; set; }
    }
}