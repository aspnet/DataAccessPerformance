using System;
using System.Threading;

namespace BenchmarkDb.Pooling
{
    public class ObjectPool<T> where T : class
    {
        private readonly T[] _items;
        private readonly Func<T> _factory;

        public ObjectPool(int maximumRetained, Func<T> factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            _items = new T[maximumRetained];
            _factory = factory;
        }

        public T Get()
        {
            for (var i = 0; i < _items.Length; i++)
            {
                var item = _items[i];
                if (item != null && Interlocked.CompareExchange(ref _items[i], null, item) == item)
                {
                    return item;
                }
            }

            return _factory();
        }

        public void Return(T obj)
        {
            for (var i = 0; i < _items.Length; i++)
            {
                if (Interlocked.CompareExchange(ref _items[i], obj, null) == null)
                {
                    return;
                }
            }
        }
    }
}
