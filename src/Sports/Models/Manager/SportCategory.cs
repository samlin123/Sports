using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sports.Models.Manager
{
    /// <summary>
    /// 运动中心运营的项目
    /// </summary>
    public class SportCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// 项目类别
        /// </summary>
        public SportEvent Event { get; set; }

        /// <summary>
        /// 规则
        /// </summary>
        public BusinessRule Rule { get; set; }

        /// <summary>
        /// 场地个数
        /// </summary>
        public virtual List<Site>  Sites { get; set; }

        /// <summary>
        /// 场次模板
        /// </summary>
        public BookSiteTemplete BookTemplete { get; set; }
    }
}