using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using log4net;
using Quartz;
using Quartz.Impl;

namespace WinService
{
    /// <summary>
    /// topshelf文档参考 http://docs.topshelf-project.com/en/latest/
    /// </summary>
    public class WinService
    {
        private Timer _timer = null;
        private readonly ILog logger;
        private IScheduler scheduler;

        public WinService()
        {
            double interval = 1000;
            _timer = new Timer(interval) { AutoReset = true };
            _timer.Elapsed += new ElapsedEventHandler(OnTick);
            logger = LogManager.GetLogger(GetType());
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            scheduler = schedulerFactory.GetScheduler();
        }

        protected virtual void OnTick(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Tick:" + DateTime.Now.ToLongTimeString());
        }
        /// <summary>
        /// 启动
        /// </summary>
        public void Start()
        {
            _timer.Start();
            scheduler.Start();
            logger.Info("Quartz服务成功启动");
            Console.WriteLine("Start:" + DateTime.Now.ToLongTimeString());
        }
        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
            scheduler.Shutdown();
            logger.Info("Quartz服务成功终止");
            Console.WriteLine("Stop:" + DateTime.Now.ToLongTimeString());
            System.Threading.Thread.Sleep(3000);
        }
        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause()
        {
            scheduler.PauseAll();
        }
        /// <summary>
        /// 继续
        /// </summary>
        public void Continue()
        {
            scheduler.ResumeAll();
        }
        /// <summary>
        /// 关闭
        /// </summary>
        public void Shutdown()
        {
            scheduler.Shutdown();
            logger.Info("Quartz服务成功终止");
        }
    }
}
