using PuddleDonkey.Base;
using PuddleDonkey.Test;

MinimalDownloader dl = new MinimalDownloader();

Youtube yt = new();
dl.Artisans.Add(yt);

yt.RequestJob("https://youtu.be/dQw4w9WgXcQ", dl);

foreach (IJob j in dl.Jobs) {
    j.DoDownload(dl);
}