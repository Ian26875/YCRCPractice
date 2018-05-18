using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace YCRCPracticeWebApp.Repository.Cache
{
    /// <summary>
    /// Class MemoryCacheProvider.
    /// </summary>
    /// <seealso cref="YCRCPracticeWebApp.Repository.Cache.ICacheProvider" />
    public class MemoryCacheProvider : ICacheProvider
    {
        /// <summary>
        /// The memory cache
        /// </summary>
        private readonly MemoryCache _memoryCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryCacheProvider"/> class.
        /// </summary>
        public MemoryCacheProvider()
        {
            this._memoryCache = MemoryCache.Default;
        }

        /// <summary>
        /// Determines whether [contains] [the specified key].
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if [contains] [the specified key]; otherwise, <c>false</c>.</returns>
        public bool Contains(string key)
        {
            return _memoryCache.Contains(key);
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="TItem">The type of the t item.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>TItem.</returns>
        public TItem Get<TItem>(string key)
        {
            return (TItem)_memoryCache.Get(key);
        }

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <typeparam name="TItem">The type of the t item.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        public void Set<TItem>(string key, TItem item)
        {
            var cacheItemPolicy = new CacheItemPolicy();
            _memoryCache.Set(key, item, cacheItemPolicy);
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
