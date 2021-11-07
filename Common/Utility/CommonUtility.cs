using Android.Views;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Utility
{
    public static class CommonUtility
    {
        private static readonly TimeSpan MAX_HOLD_TIME = TimeSpan.FromSeconds(10);
        private static readonly object _lockObj = new();
        private static int _key;
        private static readonly ConcurrentDictionary<int, object> _temporaryStore = new();
        private static readonly ConcurrentQueue<(int Key, DateTime CreatedTime)> _monitorQueue = new();


        static CommonUtility()
        {
            Task.Run(() => Monitoring());
        }


        private static void Monitoring()
        {
            while (true)
            {
                if (_monitorQueue.TryPeek(out (int Key, DateTime CreatedTime) result))
                {
                    if (DateTime.Now - result.CreatedTime > MAX_HOLD_TIME)
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


        public static int SetData(object data)
        {
            lock (_lockObj)
            {
                _temporaryStore.TryAdd(_key, data);
                _monitorQueue.Enqueue((_key, DateTime.Now));
                return _key++;
            }
        }


        public static T GetData<T>(int key) where T : class
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


        public static bool RemoveData<T>(int key, out T removedData) where T : class
        {
            bool result = _temporaryStore.TryRemove(key, out object _removedData);
            if (_removedData is not T)
            {
                throw new InvalidCastException($"キャストエラー");
            }

            removedData = _removedData as T;
            return result;
        }


        public static bool RemoveData(int key)
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
                    IEnumerable<MethodInfo> targetMethodInfos = methodInfoLookup[targetMethodName];
                    if (targetMethodInfos.Count() > 1)
                    {
                        throw new Exception($"複数のメソッドの候補が存在します。 メソッド名:{targetMethodInfos.First().Name}");
                    }

                    eventInfo.AddEventHandler(view, Delegate.CreateDelegate(eventInfo.EventHandlerType, target, targetMethodInfos.First()));
                }
            }
        }
    }
}
