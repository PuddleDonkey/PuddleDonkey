namespace PuddleDonkey.Base;

/// <summary>
/// Interface representing a Data Store, Configuration or Secret.
/// </summary>
public interface IDataStore {
    /// <summary>
    /// Get the value of the secret for a given key.
    /// </summary>
    /// <typeparam name="T">The Type calling the function, Normally a <seealso
    /// cref="IJobFactory"/> or <seealso cref="IJobArtisan"/></typeparam> <param
    /// name="key">The Key for the Value</param> <returns>The Stored
    /// Value</returns>
    string GetValue<T>(string key);

    /// <summary>
    /// Sets the value of the secret for a given key.
    /// </summary>
    /// <typeparam name="T">The Type calling the function, Normally a <seealso
    /// cref="IJobFactory"/> or <seealso cref="IJobArtisan"/></typeparam> <param
    /// name="key">The Key for the Value</param> <param name="value">The Value To
    /// Set</param>
    void SetValue<T>(string key, string value);
}
