using System.Collections.Generic;
using System.Linq;
using PuddleDonkey.Base;

namespace PuddleDonkey.Test;

/// <summary>
/// Minimal job downloader object, used for testing.
/// </summary>
public class MinimalDownloader : IJobManager {

    /// <summary>
    /// Store for Configurations, May be displayed in cleartext in frontend.
    /// </summary>
    public IDataStore Config { get; protected set; }

    /// <summary>
    /// Store for Secrets, Should not be displayed in cleartext in frontend.
    /// </summary>
    public IDataStore Secrets { get; protected set; }

    /// <summary>
    /// Job Queue. Should be manually processed by the program.
    /// </summary>
    public Queue<IJob> Jobs { get; private set; }

    private List<IJobFactory> _Factories;

    /// <summary>
    /// List of job factories used by the downloader. If the factory is also an
    /// artisan, it may appear in both
    /// </summary>
    public ICollection<IJobFactory> Factories {
        get { return _Factories; }
    }

    private List<IJobArtisan> _Artisans;

    /// <summary>
    /// List of job artisans used by the downloader. If the factory is also an
    /// factory, it may appear in both
    /// </summary>
    public ICollection<IJobArtisan> Artisans {
        get { return _Artisans; }
    }

    /// <summary>
    /// Adds a Job to the Manager's Queue, This should be called by a class
    /// inheriting <seealso cref="IJobFactory"/> or <seealso cref="IJobArtisan"/>
    /// </summary>
    /// <param name="Job">The Job object</param>
    public void EnqueueJob(IJob Job) => Jobs.Enqueue(Job);

    /// <summary>
    /// Constructor.
    /// </summary>
    public MinimalDownloader() {
        Jobs = new Queue<IJob>();
        Config = new DictionaryStore();
        Secrets = new DictionaryStore();
        _Factories = new List<IJobFactory>();
        _Artisans = new List<IJobArtisan>();
    }
}
