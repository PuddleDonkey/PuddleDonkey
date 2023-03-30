using System.Collections.ObjectModel;

namespace PuddleDonkey.Base;

/// <summary>
/// A tool to enable manual requests of youtube videos using <seealso
/// cref="Ytdlp"/>
/// </summary>
public class Youtube : IJobArtisan {
    /// <summary>
    /// The ID of the Job Creator
    /// </summary>
    /// <value>The string "youtube"</value>
    public string Id {
        get { return "youtube"; }
    }

    /// <summary>
    /// This does not require any configurations.
    /// </summary>
    /// <value>An empty list</value>
    public ICollection<string> RequiredConfigs {
        get { return new List<string>(); }
    }

    /// <summary>
    /// This does not require any secrets.
    /// </summary>
    /// <value>An empty list</value>
    public ICollection<string> RequiredSecrets {
        get { return new List<string>(); }
    }

    /// <summary>
    /// Request a youtube video be downloaded
    /// </summary>
    /// <param name="identifier">The URL of the video</param>
    /// <param name="manager">The manager object</param>
    /// <returns>A job object</returns>
    public void RequestJob(string identifier, IJobManager manager) {
        if (manager is null) {
            throw new ArgumentNullException(nameof(manager));
        }
        Ytdlp job = new Ytdlp(identifier, GetType());

        manager.EnqueueJob(job);
    }
}
