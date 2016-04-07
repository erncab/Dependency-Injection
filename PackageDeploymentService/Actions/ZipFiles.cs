using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace PackageDeploymentService.Actions
{
    public class ZipFiles : ActionBase
    {
        public string FileName { get; set; }

        public override void Execute()
        {
            if (!Directory.Exists(TargetFolder))
            {
                Directory.CreateDirectory(TargetFolder);
            }

            var zipFileName = string.Format(@"{0}\{1}.zip", TargetFolder, FileName);

            if (File.Exists(zipFileName))
            {
                File.Delete(zipFileName);
            }

            // http://stackoverflow.com/questions/22339260/how-do-i-add-files-to-an-existing-zip-archive
            // C# add files to zip file
            ZipFile.CreateFromDirectory(string.Format(@"{0}\bin", SourceFolder), zipFileName, CompressionLevel.Fastest, true);

            using (var memoryStream = new MemoryStream())
            {
                var zipFile = string.Format(@"{0}\{1}.zip", TargetFolder, FileName);

                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Update, true))
                {
                    var fileNames = Directory.GetFiles(SourceFolder, string.Format("*.{0}", Extension));
                    CreateZipEntriesFromFiles(fileNames, zipArchive);
                }

                using (var fileStream = new FileStream(zipFile, FileMode.Create))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    memoryStream.CopyTo(fileStream);
                }
            }
        }

        private void CreateZipEntriesFromFiles(IEnumerable<string> fileNames, ZipArchive zipArchive)
        {
            foreach (var fileName in fileNames)
            {
                var shortFileName = fileName.Replace(SourceFolder + "\\", "");

                if (FileCanBeCopied(shortFileName))
                {
                    Console.WriteLine(fileName);

                    zipArchive.CreateEntryFromFile(fileName, fileName.Replace(SourceFolder + "\\", ""));
                }
            }
        }

        protected override bool FileCanBeCopied(string shortFileName)
        {
            return Path.GetExtension(shortFileName) == string.Format(".{0}", Extension);
        }
    }
}