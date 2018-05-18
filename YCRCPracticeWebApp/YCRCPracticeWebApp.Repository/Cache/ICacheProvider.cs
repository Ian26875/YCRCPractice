using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YCRCPracticeWebApp.Repository.Cache
{
    /// <summary>
    /// Interface ICacheProvider
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// Determines whether [contains] [the specified key].
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if [contains] [the specified key]; otherwise, <c>false</c>.</returns>
        bool Contains(string key);

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="TItem">The type of the t item.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>TItem.</returns>
        TItem Get<TItem>(string key);

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <typeparam name="TItem">The type of the t item.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        void Set<TItem>(string key, TItem item);

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        void Remove(string key);
    }
}
