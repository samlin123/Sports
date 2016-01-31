using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sports.Models.Manager
{
    /// <summary>
    /// 场次模板
    /// </summary>
    public class BookSiteTemplete
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TempleteId { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string TempleteName { get; set; }

        /// <summary>
        /// 场次的详细信息以json的格式保存在数据库
        /// </summary>
        public string Content { get; set; }
    }
}