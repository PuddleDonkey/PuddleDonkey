namespace PuddleDonkey.Base;

/// <summary>
/// Interface for an addon
/// </summary>
public interface IJobFactory {
    /// <summary>
    /// The configuration required for operation.
    /// </summary>
    ICollection<string> RequiredConfigs { get; }

    /// <summary>
    /// The secrets required for operation.
    /// </summary>
    ICollection<string> RequiredSecrets { get; }

    /// <summary>
    /// Load all the availible jobs, and  add into the manager's queue. Should act
    /// statelessly as if it were a static method.
    /// </summary>
    /// <param name="manager">The job manager object</param>
    void LoadJobs(IJobManager manager);

    /// <summary>
    /// The ID of the Job Creator, may be used in the file output path
    /// </summary>
    string Id { get; }
}
