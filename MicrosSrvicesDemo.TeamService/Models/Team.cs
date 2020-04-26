﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuanMou.MicroService.TeamService.Models
{
    /// <summary>
    /// 团队模型
    /// </summary>
    public class Team
    {
        /// <summary>
        /// 团队主键
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 团队名称
        /// </summary>
        public string Name { set; get; }
       
    }
}
