using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;

namespace WinService.Taks
{
    public class Test : IJob
    {
        //使用log4net.dll日志接口实现日志记录
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region IJob 成员

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                logger.Info("内部测试 任务开始运行");
                Console.WriteLine("内部测试 每秒执行一次");

                for (int i = 0; i < 10; i++)
                {
                    logger.InfoFormat("内部测试 正在运行{0}", i);
                }

                logger.Info("内部测试 任务运行结束");
            }
            catch (Exception ex)
            {
                logger.Error("内部测试 运行异常", ex);
            }

        }

        #endregion
    }
}
