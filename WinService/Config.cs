using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace WinService
{
    public class Config
    {
        /// <summary>
        /// 服务实例名称
        /// </summary>
        public static readonly string SERVICE_NAME = ConfigurationManager.AppSettings["ServiceName"];
        /// <summary>
        /// 服务描述
        /// </summary>
        public static readonly string SERVICE_DESCRIPTION = ConfigurationManager.AppSettings["ServiceDescription"];
    }
}
