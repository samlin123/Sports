using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sports.Models.Manager
{
    /// <summary>
    /// 子订单
    /// </summary>
    public class BookSubRecord
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SubRecordId { get; set; }

        /// <summary>
        /// 场地
        /// </summary>
        public Site Site { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        [NotMapped]
        public SiteBookStatus Status { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        public decimal Fee { get; set; }
    }
}