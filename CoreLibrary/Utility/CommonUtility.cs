using Android.Views;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace WordLearning.CoreLibrary.Utility
{
    public static class CommonUtility
    {
        private static readonly TimeSpan MaxHoldTime = TimeSpan.FromSeconds(10);
        private const int MaxStoreCount = 10000;
        private static readonly ConcurrentDictionary<string, object> _temporaryStore = new();
        private static readonly ConcurrentQueue<(string Key, DateTime CreatedTime)> _monitorQueue = new();


        static CommonUtility()
        {
            Task.Run(() => Monitoring());
        }


        private static void Monitoring()
        {
            while (true)
            {
                if (_monitorQueue.TryPeek(out (string Key, DateTime CreatedTime) result))
                {
                    if (DateTime.Now - result.CreatedTime > MaxHoldTime)
                    {
                        throw new InvalidOperationException($"保持期限切れ");
                    }

                    if (!_temporaryStore.ContainsKey(result.Key))
                    {
                        _monitorQueue.TryDequeue(out _);
                    }
                }

                Thread.Sleep(100);
            }
        }


        public static string SetData(object data)
        {
            if (_temporaryStore.Count == MaxStoreCount)
            {
                throw new InvalidOperationException($"上限を超えました。");
            }

            string newKey = Guid.NewGuid().ToString();
            _temporaryStore.TryAdd(newKey, data);
            _monitorQueue.Enqueue((newKey, DateTime.Now));
            return newKey;
        }


        public static T GetData<T>(string key) where T : class
        {
            if (!_temporaryStore.TryGetValue(key, out object value))
            {
                throw new KeyNotFoundException($"Key:{key}が存在しません。");
            }

            if (value is not T)
            {
                throw new InvalidCastException($"キャストエラー");
            }

            return value as T;
        }


        public static bool RemoveData<T>(string key, out T removedData) where T : class
        {
            bool result = _temporaryStore.TryRemove(key, out object _removedData);
            if (_removedData is not T)
            {
                throw new InvalidCastException($"キャストエラー");
            }

            removedData = _removedData as T;
            return result;
        }


        public static bool RemoveData(string key)
        {
            return _temporaryStore.TryRemove(key, out _);
        }


        public static void AddEventToEachView(dynamic root, FieldInfo[] idFields, object target = null)
        {
            target ??= root;
            ILookup<string, MethodInfo> methodInfoLookup = target.GetType().GetMethods().ToLookup(methodInfo => methodInfo.Name, methodInfo => methodInfo);
            foreach (FieldInfo idField in idFields)
            {
                int id = int.Parse(idField.GetValue(null).ToString());
                dynamic view = root.FindViewById(id);
                if (view == null)
                {
                    continue;
                }

                AddEvent(view, idField, target, methodInfoLookup);
            }
        }


        private static void AddEvent(View view, FieldInfo id, object target, ILookup<string, MethodInfo> methodInfoLookup)
        {
            EventInfo[] eventInfos = view.GetType().GetEvents();
            foreach (EventInfo eventInfo in eventInfos)
            {
                string targetMethodName = string.Join("_", id.Name, eventInfo.Name);
                if (methodInfoLookup.Contains(targetMethodName))
                {
                    MethodInfo[] targetMethodInfos = methodInfoLookup[targetMethodName].ToArray();
                    if (targetMethodInfos.Length > 1)
                    {
                        throw new Exception($"複数のメソッドの候補が存在します。 メソッド名:{targetMethodInfos[0].Name}");
                    }

                    eventInfo.AddEventHandler(view, Delegate.CreateDelegate(eventInfo.EventHandlerType, target, targetMethodInfos[0]));
                }
            }
        }


        public static T CreateInstance<T>(Assembly targetAssembly, string name, params object[] args)
        {

            if (!_assemblyTypeDictionary.ContainsKey(targetAssembly))
            {
                _assemblyTypeDictionary.TryAdd(targetAssembly, new ConcurrentDictionary<string, Type>(targetAssembly.GetExportedTypes().ToDictionary(type => type.Name, type => type)));
            }


            _assemblyTypeDictionary.TryGetValue(targetAssembly, out ConcurrentDictionary<string, Type> typeDictionary);
            typeDictionary.TryGetValue(name, out Type targetType);

            if (!typeof(T).IsAssignableFrom(targetType))
            {
                throw new InvalidOperationException();
            }

            return (T)Activator.CreateInstance(targetType, args);
        }

        private static readonly ConcurrentDictionary<Assembly, ConcurrentDictionary<string, Type>> _assemblyTypeDictionary = new();
    }
}
