using System.Collections.Generic;
using PuddleDonkey.Base;

namespace PuddleDonkey.Test;

/// <summary>
/// Store values in a dictionary
/// </summary>
public class DictionaryStore : Dictionary<string, string>, IDataStore {
    /// <summary>
    /// Get the value of the secret for a given key.
    /// </summary>
    /// <typeparam name="T">The Type calling the function, Normally a <seealso
    /// cref="IJobFactory"/> or <seealso cref="IJobArtisan"/></typeparam> <param
    /// name="key">The Key for the Value</param> <returns>The Stored
    /// Value</returns>
    public string GetValue<T>(string key) {
        string? value;

        if (key is string k && TryGetValue(k, out value)) {
            return value;
        }

        return "";
    }

    /// <summary>
    /// Sets the value of the secret for a given key.
    /// </summary>
    /// <typeparam name="T">The Type calling the function, Normally a <seealso
    /// cref="IJobFactory"/> or <seealso cref="IJobArtisan"/></typeparam> <param
    /// name="key">The Key for the Value</param> <param name="value">The Value To
    /// Set</param>
    public void SetValue<T>(string key, string value) => this[key] = value;
}
