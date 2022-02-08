using System.Text.Json;

namespace Pierre.Darcas.FeatureMatching.Console;

public class FeatureMatchingConsole
{
    static async Task Main(string[] args)
    {
        byte[] image = await File.ReadAllBytesAsync(args[0]);
        
        var imageScenesData = new List<byte[]>();
        foreach (var imagePath in Directory.EnumerateFiles(args[1]))
        {
            var imageBytes = await File.ReadAllBytesAsync(imagePath);
            imageScenesData.Add(imageBytes);
        }

        var featureMatchingLib = new ObjectDetection();

        var featureMatchingResults = await featureMatchingLib.DetectObjectInScenes(image,imageScenesData);
        
        foreach (var objectDetectionResult in featureMatchingResults)
        {
            System.Console.WriteLine($"Points:{JsonSerializer.Serialize(objectDetectionResult.Points)}");
        }

    }
}