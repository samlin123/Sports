using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sports.Models.Manager
{
    /// <summary>
    /// 场地信息
    /// </summary>
    public class Site
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SiteId { get; set; }

        /// <summary>
        /// 场地编号
        /// </summary>
        public String SiteNumber { get; set; }

        /// <summary>
        /// 场地说明
        /// </summary>
        public String Specification { get; set; }

        /// <summary>
        /// 场次模板
        /// </summary>
        public BookSiteTemplete Templete { get; set; }

        /// <summary>
        /// 场次预定情况
        /// </summary>
        List<SiteBookStatus> SiteBookStatus { get; set; }
    }
}