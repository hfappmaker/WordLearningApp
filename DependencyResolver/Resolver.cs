using System;
using Microsoft.Extensions.DependencyInjection;
using WordLearning.Domain.Repositories;
using WordLearning.Infrastructure.Repositories;

namespace WordLearning.DependencyResolver
{
    public static class Resolver
    {
        public static IServiceProvider ServiceProvider { get; private set; }


        public static void Resolve()
        {
            // サービスを登録
            var services = new ServiceCollection();
            services.AddSingleton<IWlRootFolderRepository, XmlWlRootFolderRepository>();

            // サービスプロバイダーをビルド
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
