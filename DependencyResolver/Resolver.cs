using System;
using Microsoft.Extensions.DependencyInjection;
using WordLearning.Domain.Entry;
using WordLearning.Domain.Repositories;
using WordLearning.Infrastructure.Mappers;
using WordLearning.Infrastructure.Repositories;

namespace WordLearning.DependencyResolver
{
    public static class Resolver
    {
        public static IServiceProvider ServiceProvider { get; private set; }


        public static void Resolve()
        {
            if (ServiceProvider != null) throw new InvalidOperationException();
            // サービスを登録
            var services = new ServiceCollection();
            services.AddSingleton<IWlRootFolderRepository, SQLiteWlRootFolderRepository>();

            // サービスプロバイダーをビルド
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
