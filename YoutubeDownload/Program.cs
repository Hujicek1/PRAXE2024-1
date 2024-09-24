using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeDownload;

class Program
{
    static async Task Main(string[] args)
    {
        var youtube = new YoutubeClient();
        string test = "Y";
        while(test == "Y"){
            System.Console.WriteLine("Write the YouTube video url: ");
            string videoUrl = Console.ReadLine();
            var video = await youtube.Videos.GetAsync(videoUrl);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoUrl);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"C:/Users/uih05152/Desktop/YoutubeDownload/Videos/{video.Title}.{streamInfo.Container}");
            System.Console.WriteLine("Do you want to download another one?(Y/N)");
            test = Console.ReadLine().ToUpper();
            if(test != "Y"){
                break;
            }
        }


    }
}
