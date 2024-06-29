using LicentaNou2.Presenters;
using LicentaNou2.Repositories;
using LicentaNou2.Util;
using LicentaNou2.Views;
using LicentaNou2.Views.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using pocketbase.net;
using System.Net;

namespace LicentaNou2
{
    internal static class Program
    {
        public static IMainView mainView { get; set; }
        public static IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var host = CreateHost();

            ServiceProvider = host.Services;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            host.Run();
        }
        static IHost CreateHost()
        {
            var builder = Host.CreateApplicationBuilder();
            var env = builder.Environment;

            // These files were already added to the default Application builder
            // But in order to specify the required flag we readd them here

            builder.Logging.ClearProviders();
            builder.Logging.AddNLog();

            // Increase possible shutdown time to allow all data to be processed/flushed
            builder.Services.Configure<HostOptions>(options =>
                options.ShutdownTimeout = TimeSpan.FromSeconds(120));
            builder.Services.AddHostedService<ApplicationWorker>();
            builder.Services.AddSingleton<IViewFactory, ViewFactory>();

            builder.Services.AddTransient<IMainView, FrmMain>();
            builder.Services.AddTransient<IMainRepository, MainRepository>();
            builder.Services.AddScoped<MainPresenter>();

            builder.Services.AddTransient<IRecomandariView, FrmRecomandari>();
            builder.Services.AddTransient<IRecomandariRepository, RecomandariRepository>();
            builder.Services.AddScoped<RecomandariPresenter>();

            builder.Services.AddTransient<IDetaliiRecomandareView, FrmDetaliiRecomandare>();
            builder.Services.AddTransient<IDetaliiRecomandareRepository, DetaliiRecomandareRepository>();
            builder.Services.AddScoped<DetaliiRecomandarePresenter>();

            builder.Services.AddTransient<IStatisticsView, FrmStatistics>();
            builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            builder.Services.AddScoped<StatisticsPresenter>();
            
            builder.Services.AddTransient<IMLAdmissionRepository, MLAdmissionRepository>();
            builder.Services.AddTransient<IMLAdmissionLogic, MLAdmissionLogic>();

            builder.Services.AddTransient<IDBConnection, DBConnection>();

            RegisterAllViewsAsService(builder.Services);

            return builder.Build();
        }
        static void RegisterAllViewsAsService(IServiceCollection services)
        {
            var forms = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.BaseType == typeof(BaseView))
                .ToList();

            forms.ForEach(form =>
            {
                services.AddTransient(form);
            });
        }
    }
}