using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;

string projectId = "XXXXXXXXXXXXXXXXXXXXXX";
string bucketName = "luiscocoenriquezsegundo";
string localPath = "C://NetChapterArticles.txt";
string objectName = "NetChapterArticles.txt";

//-----------------------------------------------------------------------------
//Create Bucket (VALIDATED!)
//-----------------------------------------------------------------------------
//var storage = StorageClient.Create();
//var bucket = storage.CreateBucket(projectId, bucketName);
//Console.WriteLine($"Created {bucketName}.");

//-----------------------------------------------------------------------------
//List Buckets (VALIDATED!)
//-----------------------------------------------------------------------------
var storage = StorageClient.Create();
var bucketsluis = storage.ListBuckets(projectId);
Console.WriteLine("Buckets:");
foreach (var bucketluis in bucketsluis)
{
    Console.WriteLine(bucketluis.Name);
}
//-----------------------------------------------------------------------------
//File Upload (VALIDATED!)
//-----------------------------------------------------------------------------

using var fileStream = File.OpenRead(localPath);
storage.UploadObject(bucketName, objectName, null, fileStream);
Console.WriteLine($"Uploaded {objectName}.");

//-----------------------------------------------------------------------------
//File Download (VALIDATED!)
//-----------------------------------------------------------------------------

string downloadlocalpath = "C:\\New folder\\DownloadedFile.txt";
using var outputFile = File.OpenWrite(downloadlocalpath);
storage.DownloadObject(bucketName, objectName, outputFile);
Console.WriteLine($"Downloaded {objectName} to {localPath}.");

//-----------------------------------------------------------------------------
//List Files (VALIDATED!)
//-----------------------------------------------------------------------------

var storageObjects = storage.ListObjects(bucketName);
Console.WriteLine($"Files in bucket {bucketName}:");
foreach (var storageObject in storageObjects)
{
    Console.WriteLine(storageObject.Name);
}




