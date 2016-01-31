using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sports.Models.Manager
{
    /// <summary>
    /// 总订单
    /// </summary>
    public class BookRecord
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RecordId { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationDate { get; set; }

        /// <summary>
        /// 预订人列表：支持拼单模式
        /// </summary>
        List<BookMan> BookMans { get; set; }

        /// <summary>
        /// 全部费用
        /// </summary>
        public decimal TotalFee { get; set; }

        /// <summary>
        /// 子订单
        /// </summary>
        public List<BookSubRecord> SubRecords { get; set; }
    }
}