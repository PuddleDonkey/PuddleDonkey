namespace PuddleDonkey.Base;

/// <summary>
/// Interface for an addon.
///
/// This Should be used to request arbritary jobs
/// </summary>
public interface IJobArtisan {

    /// <summary>
    /// The configuration required for operation.
    /// </summary>
    ICollection<string> RequiredConfigs { get; }

    /// <summary>
    /// The secrets required for operation.
    /// </summary>
    ICollection<string> RequiredSecrets { get; }

    /// <summary>
    /// Request a singular job from the identifier. Should act statelessly as if
    /// it were a static method, and enqueue it in the manager.
    /// </summary>
    /// <param name="identifier">The Job Identifier, may be a URL or ID</param>
    /// <param name="manager">The Job manager</param>
    void RequestJob(string identifier, IJobManager manager);

    /// <summary>
    /// The ID of the Job Creator, may be used in the file output path
    /// </summary>
    string Id { get; }
}
