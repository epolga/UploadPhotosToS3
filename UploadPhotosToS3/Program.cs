using Amazon.S3;
using Amazon.S3.Transfer;
using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Configuration
        string bucketName = "cross-stitch-designs-photos"; // Replace with your S3 bucket name
        string rootDirectory = @"D:\ftproot\photos"; // Your local root folder
        string s3Prefix = "photos/"; // Optional: Base prefix in S3

        // Initialize the S3 client
        using var s3Client = new AmazonS3Client(); // Assumes credentials are configured

        // Upload all files
        await UploadDirectoryToS3(s3Client, bucketName, rootDirectory, s3Prefix);
        Console.WriteLine("Upload completed!");
    }

    static async Task UploadDirectoryToS3(IAmazonS3 s3Client, string bucketName, string localDirectory, string s3Prefix)
    {
        try
        {
            var transferUtility = new TransferUtility(s3Client);

            // Iterate through all files in the directory and subdirectories
            foreach (string filePath in Directory.GetFiles(localDirectory, "*.*", SearchOption.AllDirectories))
            {
                // Create the S3 key by removing the root directory part and replacing backslashes
                string s3Key = s3Prefix + filePath
                    .Replace(localDirectory, "") // Remove the local root path
                    .TrimStart('\\') // Remove leading backslash
                    .Replace('\\', '/'); // Convert to forward slashes for S3

                Console.WriteLine($"Uploading {filePath} to {s3Key}");

                // Upload the file
                await transferUtility.UploadAsync(filePath, bucketName, s3Key);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error uploading to S3: {ex.Message}");
        }
    }
}