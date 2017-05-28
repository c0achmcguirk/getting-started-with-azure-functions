#r "System.Drawing"

using ImageResizer;
using System.Drawing;
using System.Drawing.Imaging;

public static void Run(Stream inImage, string name, string extension, Stream outImage, TraceWriter log)
{
    log.Info($"C# Blob trigger function Processed blob\n Name:{name}.{extension} \n Size: {inImage.Length} Bytes");

    var settings = new ImageResizer.ResizeSettings{
        MaxWidth = 350,
        Format = "jpg",
        Quality = 50
    };

    ImageResizer.ImageBuilder.Current.Build(inImage, outImage, settings);
}
