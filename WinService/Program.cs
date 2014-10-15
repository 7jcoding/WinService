using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Topshelf;
using Topshelf.HostConfigurators;

namespace WinService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<WinService>(s =>
                {
                    s.ConstructUsing(name => new WinService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                    s.WhenPaused(tc => tc.Pause());
                    s.WhenContinued(tc => tc.Continue());
                    s.WhenShutdown(tc => tc.Shutdown());
                });
                x.RunAsLocalSystem();

                x.SetDescription(Config.SERVICE_DESCRIPTION);       //描述相关
                x.SetDisplayName(Config.SERVICE_NAME);         //显示名称
                x.SetServiceName(Config.SERVICE_NAME);         //服务名称
            });
        }
    }
}
