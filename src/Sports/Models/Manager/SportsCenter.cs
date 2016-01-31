using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sports.Models.Manager
{
    /// <summary>
    /// 运动中心类
    /// </summary>
    public class SportsCenter
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CenterId { get; set; }

        /// <summary>
        /// 运动中心名称
        /// </summary>
        public String CenterName { get; set; }

        /// <summary>
        /// 运动中心地址
        /// </summary>
        public String CenterAddress { get; set; }

        /// <summary>
        /// 中心提供的项目
        /// </summary>
        public virtual List<SportCategory> AllCatetory { get; set; }

        /// <summary>
        /// 场次模板,延迟加载
        /// </summary>
        public virtual List<BookSiteTemplete> AllTempletes { get; set; }

        /// <summary>
        /// 商业规则
        /// </summary>
        public BusinessRule Rule { get; set; }
    }
}