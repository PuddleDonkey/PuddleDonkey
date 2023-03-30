using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace PuddleDonkey.Base;

/// <summary>
/// Downloader using yt-dlp executable
/// </summary>
public class Ytdlp : JobBase {

    /// <summary>
    /// Constructor for ytdlp job.
    /// </summary>
    /// <param name="id">The URL of the video</param>
    /// <param name="caller">The type of the caller object</param>
    /// <param name="additionalArguments">Additional command line arguments</param>
    public Ytdlp(string id, Type caller,
                 ICollection<string>? additionalArguments = null)
        : base(id, "", "yt-dlp", caller) {
        if (additionalArguments is List<string> args) {
            _additionalArguments = args.ToList();
        }
        else {
            _additionalArguments = new List<string>();
        }
        _url = id;
    }

    private List<string> _additionalArguments;
    private string _url;

    /// <summary>
    /// Perform the Download.
    /// </summary>
    /// <param name="manager">The manager object</param>
    public override void DoDownload(IJobManager manager) {
        //...
        using (Process process = new Process()) {
            // Configure the process using the StartInfo properties.
            process.StartInfo.FileName = "yt-dlp";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.ArgumentList.Add(_url);
            _additionalArguments.ForEach(x => process.StartInfo.ArgumentList.Add(x));

            // Hide Window, and process stdout/stderr
            process.Start();
            Regex status_update = new Regex(
                "\\[download\\] +([0-9.]+)% of +([0-9.]+|Unknown) *(B|KiB|MiB|GiB) at +([0-9.]+|Unknown) *(B|KiB|MiB|GiB)/s ETA ([0-9:-]+)");
            Regex destination = new Regex("\\[download\\] +Destination: (.+)");
            Regex info = new Regex("\\[info\\] +(.+)");
            while (process.StandardOutput.ReadLine() is string line) {
                Console.Write($"\r{Status}");
                var match = status_update.Match(line);
                if (match.Success) {
                    DownloadStatusMatch(match);
                    continue;
                }
                match = info.Match(line);
                if (match.Success) {
                    InfoMatch(match);
                    continue;
                }
                match = destination.Match(line);
                if (match.Success) {
                    Status = $"Downloading to: {match.Groups[1]}";
                    continue;
                }
            }
            process.WaitForExit();
            Progress = 1.0f;
        }
    }

    private void DownloadStatusMatch(Match match) {
        var g = match.Groups;

        Progress = Convert.ToSingle(g[1].Value, new CultureInfo("en-GB")) * 0.01f;
        Status
         = $"{g[1]}% of {g[2]}{g[3]} ({g[4]}{g[5]}/s)";
    }

    private void InfoMatch(Match match) {
        var g = match.Groups;
        Status = g[1].Value;
    }
}
