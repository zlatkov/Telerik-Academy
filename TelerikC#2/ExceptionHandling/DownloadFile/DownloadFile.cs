using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security;
using System.IO;

namespace DownloadFile
{
    class DownloadFile
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            try
            {
                Console.WriteLine("Enter the file url:");
                string fileUrl = Console.ReadLine();

                Uri fileUri = new Uri(fileUrl);
                string fileName = Path.GetFileName(fileUri.LocalPath);
                string localFilePath = Directory.GetCurrentDirectory() + "\\" + fileName;

                client.DownloadFile(fileUrl, localFilePath);
                Console.WriteLine("The file was downloaded successfully at: {0}", localFilePath);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("The file url is null.");
            }
            catch (UriFormatException e)
            {
                Console.WriteLine("The file url is invalid.");
            }
            catch (WebException we)
            {
                Console.WriteLine("An error occurred while downloading the file.");
            }
            catch (SecurityException se)
            {
                Console.WriteLine("You don't have permission to write to a local file.");
            }
            finally
            {
                client.Dispose();      
            }
        }
    }
}
