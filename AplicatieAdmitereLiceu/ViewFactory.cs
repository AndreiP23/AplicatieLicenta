using LicentaNou2.Views;
using Microsoft.Extensions.DependencyInjection;

namespace LicentaNou2
{
    public interface IViewFactory
    {
        public T? Create<T>() where T : BaseView;
    }

    public class ViewFactory : IViewFactory
    {
        private readonly IServiceScope _scope;

        public ViewFactory(IServiceScopeFactory serviceScopeFactory)
        {
            _scope = serviceScopeFactory.CreateScope();
        }

        public T? Create<T>() where T : BaseView
        {
            return _scope.ServiceProvider.GetService<T>();
        }
    }
}
