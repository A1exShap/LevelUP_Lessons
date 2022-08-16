namespace Lesson3
{
    internal class SimpleGenericCache<T>
    {
        private const int DEFAULT_TIMEOUT = 30;

        private readonly Dictionary<string, CachedValue<T>> _cache = new();

        public int Count => _cache.Count;

        internal void Store(string key, T value, int timeout = DEFAULT_TIMEOUT)
        {
            _cache[key] = new CachedValue<T>
            {
                Value = value,
                Timeout = timeout,
                CreationTime = DateTime.Now
            };
        }

        internal T? Fetch(string key)
        {
            var isCachedValue = _cache.TryGetValue(key, out var value);

            var hasValidLifeTime = CheckTimeout(value);

            if (!hasValidLifeTime)
            {
                _cache.Remove(key);
            }

            return isCachedValue && hasValidLifeTime ? value.Value : default;
        }
        
        private bool CheckTimeout(CachedValue<T> cachedValue)
            => (DateTime.Now - cachedValue.CreationTime).TotalSeconds < cachedValue.Timeout;
    }
}
