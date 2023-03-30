namespace PuddleDonkey.Base;

/// <summary>
/// Interface representing the main downloader.
/// </summary>
public interface IJobManager {
    /// <summary>
    /// Adds a Job to the Manager's Queue, This should be called by a class
    /// inheriting <seealso cref="IJobFactory"/> or <seealso cref="IJobArtisan"/>
    /// </summary>
    /// <param name="Job">The Job object</param>
    void EnqueueJob(IJob Job);

    /// <summary>
    /// Store for Secrets, Should not be displayed in cleartext in frontend.
    /// </summary>
    IDataStore Secrets { get; }

    /// <summary>
    /// Store for Configurations, May be displayed in cleartext in frontend.
    /// </summary>
    IDataStore Config { get; }

    /// <summary>
    /// List of job factories used by the downloader. If the factory is also an
    /// artisan, it may appear in both
    /// </summary>
    ICollection<IJobFactory> Factories { get; }

    /// <summary>
    /// List of job artisans used by the downloader. If the factory is also an
    /// factory, it may appear in both
    /// </summary>
    ICollection<IJobArtisan> Artisans { get; }
}
