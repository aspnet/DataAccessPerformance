using System;
using System.Collections.Concurrent;
using System.Threading;

namespace BenchmarkDb.Pooling
{
    public class ObjectPool<T> where T : class
    {
        private readonly ConcurrentQueue<T> _queue;
        private readonly T[] _items;
        private readonly int _maximumRetained;
        private readonly Func<T> _factory;

        public ObjectPool(int maximumRetained, Func<T> factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            _items = new T[maximumRetained];
            _queue = new ConcurrentQueue<T>();
            _maximumRetained = maximumRetained;
            _factory = factory;
        }

        public T Get()
        {
            if (!_queue.TryDequeue(out var item))
            {
                item = _factory();
            }

            return item;

            //for (var i = 0; i < _items.Length; i++)
            //{
            //    var item = _items[i];
            //    if (item != null && Interlocked.CompareExchange(ref _items[i], null, item) == item)
            //    {
            //        return item;
            //    }
            //}

            //return _factory();
        }

        public bool Return(T obj)
        {
            if (_queue.Count < _maximumRetained)
            {
                _queue.Enqueue(obj);
                return true;
            }

            //for (var i = 0; i < _items.Length; i++)
            //{
            //    if (Interlocked.CompareExchange(ref _items[i], obj, null) == null)
            //    {
            //        return true;
            //    }
            //}

            return false;
        }
    }
}
