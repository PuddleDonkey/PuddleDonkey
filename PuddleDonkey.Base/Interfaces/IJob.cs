namespace PuddleDonkey.Base;

/// <summary>
/// Job interface class. Should be inherited by other job types.
/// </summary>
public interface IJob {
    /// <summary>
    /// The name of the job to be displayed in the UI.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// The description of the job to be displayed in the UI.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// The type of the job to be displayed in the UI.
    /// </summary>
    string JobType { get; }

    /// <summary>
    /// The Type of the object that created the job.
    /// </summary>
    Type Source { get; }

    /// <summary>
    /// Get the status string of the job (normally X of Y MiB, X MiB/s).
    /// </summary>
    string Status { get; }

    /// <summary>
    /// The progress (between 0 and 1) of the download.
    /// </summary>
    float Progress { get; }

    /// <summary>
    /// Download the job.
    /// </summary>
    /// <param name="manager">The job manager</param>
    void DoDownload(IJobManager manager);
}
