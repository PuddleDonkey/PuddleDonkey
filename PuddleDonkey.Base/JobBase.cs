namespace PuddleDonkey.Base;

/// <summary>
/// Base class to represent a job.
/// </summary>
public abstract class JobBase : IJob {
    /// <summary>
    /// The name of the job to be displayed in the UI.
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// The description of the job to be displayed in the UI.
    /// </summary>
    public string Description { get; protected set; }

    /// <summary>
    /// The type of the job to be displayed in the UI.
    /// </summary>
    public string JobType { get; protected set; }

    /// <summary>
    /// The type of the object that created the job.
    /// </summary>
    public Type Source { get; protected set; }

    /// <summary>
    /// Get the status string of the job (normally X of Y MiB, X MiB/s).
    /// </summary>
    public string Status { get; protected set; }

    /// <summary>
    /// The progress (between 0 and 1) of the download.
    /// </summary>
    public float Progress { get; protected set; }

    /// <summary>
    /// Download the job.
    /// </summary>
    /// <param name="manager">The job manager</param>
    public abstract void DoDownload(IJobManager manager);

    /// <summary>
    /// Base Constructor
    /// </summary>
    /// <param name="name">The job's name</param>
    /// <param name="description">The job's description</param>
    /// <param name="jobType">The job's</param>
    /// <param name="source">The type of the object that created the job.</param>
    protected JobBase(string name, string description, string jobType, Type source) {
        Name = name;
        Description = description;
        JobType = jobType;
        Status = "";
        Progress = 0.0f;
        Source = source;
    }
}