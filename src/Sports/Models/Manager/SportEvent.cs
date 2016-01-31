using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sports.Models.Manager
{
    /// <summary>
    /// 系统支持预定的项目
    /// </summary>
    public class SportEvent
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EventId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public String EventName { get; set; }
    }
}