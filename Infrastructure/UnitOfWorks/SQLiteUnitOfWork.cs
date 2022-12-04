using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using WordLearning.Domain.Aggregate;
using WordLearning.Domain.Entry;
using WordLearning.Domain.Entry.EntryCore;
using WordLearning.Infrastructure.Mappers;
using WordLearning.Infrastructure.Stores;

namespace WordLearning.Infrastructure.UnitOfWorks
{
    internal class SQLiteUnitOfWork<T> : UnitOfWorkBase<T> 
        where T : WlEntity, IAggregateRoot
    {
        private static readonly IServiceProvider _serviceProvider;

        static SQLiteUnitOfWork() 
        {
            // サービスを登録
            var services = new ServiceCollection();
            services.AddSingleton<IAggregateRootMapper<WlRootFolder>, SQLiteWlRootFolderMapper>();
            services.AddSingleton<IAggregateRootStore<WlRootFolder>, SQLiteWlRootFolderStore>();

            // サービスプロバイダーをビルド
            _serviceProvider = services.BuildServiceProvider();
        }

        private SQLiteUnitOfWork() : base(_serviceProvider)
        {
        }

        private static readonly Lazy<SQLiteUnitOfWork<T>> _instance = new(() => new SQLiteUnitOfWork<T>());

        public static SQLiteUnitOfWork<T> Instance => _instance.Value;
    }
}