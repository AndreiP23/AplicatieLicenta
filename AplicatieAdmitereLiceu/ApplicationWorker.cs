using LicentaNou2.Views;
using LicentaNou2;
using Microsoft.Extensions.Hosting;
using System.Windows.Forms;
using LicentaNou2.Views.Interfaces;

namespace LicentaNou2
{
    internal class ApplicationWorker : BackgroundService
    {
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly IViewFactory _viewFactory;

        public ApplicationWorker(IHostApplicationLifetime applicationLifetime, IViewFactory viewFactory)
        {
            _applicationLifetime = applicationLifetime;
            _viewFactory = viewFactory;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var formLogin = _viewFactory.Create<FrmLogin>();
            Application.Run(formLogin);

            if (formLogin.Authorized) 
            { 
                var formMain = _viewFactory.Create<FrmMain>();
                Program.mainView = formMain;
                Application.Run(formMain);
            }
            _applicationLifetime.StopApplication();

            return Task.CompletedTask;
        }
    }
}
