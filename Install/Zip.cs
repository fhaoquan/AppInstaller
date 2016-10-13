using ICSharpCode.SharpZipLib.Zip;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace Install
{


    public static class Zip
    {
        private static int compressionLevel = 9;
        private static byte[] buffer = new byte[2048];
        private static ArrayList GetFileList(string directory)
        {
            ArrayList fileList = new ArrayList();
            bool isEmpty = true;
            foreach (string file in Directory.GetFiles(directory))
            {
                fileList.Add(file);
                isEmpty = false;
            }
            if (isEmpty)
            {
                if (Directory.GetDirectories(directory).Length == 0)
                {
                    fileList.Add(directory + @"/");
                }
            }
            foreach (string dirs in Directory.GetDirectories(directory))
            {
                foreach (object obj in GetFileList(dirs))
                {
                    fileList.Add(obj);
                }
            }
            return fileList;
        }

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="fileToZip">要压缩的文件param>
        /// <param name="zipedFile">要输出文件</param>
        public static void CompressFile(string fileToZip, string zipedFile)
        {
            if (!File.Exists(fileToZip))
            {
                throw new FileNotFoundException("The specified file " + fileToZip + " could not be found.");
            }
            using (ZipOutputStream zipStream = new ZipOutputStream(File.Create(zipedFile)))
            {
                string fileName = Path.GetFileName(fileToZip);
                ZipEntry zipEntry = new ZipEntry(fileName);
                zipStream.PutNextEntry(zipEntry);
                zipStream.SetLevel(compressionLevel);
                using (FileStream streamToZip = new FileStream(fileToZip, FileMode.Open, FileAccess.Read))
                {
                    int size = streamToZip.Read(buffer, 0, buffer.Length);
                    zipStream.Write(buffer, 0, size);
                    while (size < streamToZip.Length)
                    {
                        int sizeRead = streamToZip.Read(buffer, 0, buffer.Length);
                        zipStream.Write(buffer, 0, sizeRead);
                        size += sizeRead;
                    }
                }
            }
        }
        /// <summary>
        /// 多文件压缩
        /// </summary>
        /// <param name="filesToZip"></param>
        /// <param name="zipedFile"></param>
        public static void CompressFiles(List<string> fileList, string zipedDirectory)
        {
            if (fileList.Count == 0) return;
            using (ZipOutputStream zipStream = new ZipOutputStream(File.Create(zipedDirectory)))
            {
                //  ArrayList fileList = GetFileList(directoryToZip);
                int directoryNameLength = (Directory.GetParent(fileList[0].ToString())).ToString().Length;
                zipStream.SetLevel(compressionLevel);
                ZipEntry zipEntry = null;
                FileStream fileStream = null;
                foreach (string fileName in fileList)
                {
                    zipEntry = new ZipEntry(fileName.Remove(0, directoryNameLength));
                    zipStream.PutNextEntry(zipEntry);
                    if (!fileName.EndsWith(@"/"))
                    {
                        fileStream = File.OpenRead(fileName);
                        fileStream.Read(buffer, 0, buffer.Length);
                        zipStream.Write(buffer, 0, buffer.Length);
                    }
                }
                fileStream.Dispose();
            }
        }
        /// <summary>
        /// 压缩目录
        /// </summary>
        /// <param name="directoryToZip">要压缩的目录</param>
        /// <param name="zipedDirectory">压缩后的路径</param>
        public static void CompressDirectory(string directoryToZip, string zipedDirectory)
        {


            using (ZipOutputStream zipStream = new ZipOutputStream(File.Create(zipedDirectory)))
            {
                ArrayList fileList = GetFileList(directoryToZip);
                int directoryNameLength = (Directory.GetParent(directoryToZip)).ToString().Length;
                zipStream.SetLevel(compressionLevel);
                ZipEntry zipEntry = null;
                FileStream fileStream = null;
                foreach (string fileName in fileList)
                {
                    zipEntry = new ZipEntry(fileName.Remove(0, directoryNameLength));
                    zipStream.PutNextEntry(zipEntry);
                    if (!fileName.EndsWith(@"/"))
                    {
                        fileStream = File.OpenRead(fileName);
                        fileStream.Read(buffer, 0, buffer.Length);
                        zipStream.Write(buffer, 0, buffer.Length);
                    }
                }
                fileStream.Dispose();
            }
        }

        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="zipFilePath">压缩包路径</param>
        /// <param name="unZipFilePatah">解压缩路径</param>
        public static void DeCompressFile(string zipFilePath, string unZipFilePatah)
        {
            using (ZipInputStream zipStream = new ZipInputStream(File.OpenRead(zipFilePath)))
            {
                ZipEntry zipEntry = null;
                while ((zipEntry = zipStream.GetNextEntry()) != null)
                {
                    string fileName = Path.GetFileName(zipEntry.Name);
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        if (zipEntry.CompressedSize == 0)
                            break;
                        using (FileStream stream = File.Create(unZipFilePatah + fileName))
                        {
                            while (true)
                            {
                                int size = zipStream.Read(buffer, 0, buffer.Length);
                                if (size > 0)
                                {
                                    stream.Write(buffer, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="zipDirectoryPath">压缩包路径</param>
        /// <param name="unZipDirecotyPath">解压缩路径</param>
        public static void DeCompressDirectory(string zipDirectoryPath, string unZipDirecotyPath)
        {
            using (ZipInputStream zipStream = new ZipInputStream(File.OpenRead(zipDirectoryPath)))
            {
                ZipEntry zipEntry = null;
                while ((zipEntry = zipStream.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(zipEntry.Name);
                    string fileName = Path.GetFileName(zipEntry.Name);
                    if (!string.IsNullOrEmpty(directoryName))
                    {
                        Directory.CreateDirectory(directoryName);
                    }
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        if (zipEntry.CompressedSize == 0)
                            break;
                        if (zipEntry.IsDirectory)
                        {
                            directoryName = Path.GetDirectoryName(unZipDirecotyPath + zipEntry.Name);
                            Directory.CreateDirectory(directoryName);
                        }
                        using (FileStream stream = File.Create(unZipDirecotyPath + zipEntry.Name))
                        {
                            while (true)
                            {
                                int size = zipStream.Read(buffer, 0, buffer.Length);
                                if (size > 0)
                                {
                                    stream.Write(buffer, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="zipDirectoryPath">压缩包路径</param>
        /// <param name="unZipDirecotyPath">解压缩路径</param>
        public static void DeCompressDirectory(Stream fileStream, string unZipDirecotyPath)
        {
            using (ZipInputStream zipStream = new ZipInputStream(fileStream))
            {
                ZipEntry zipEntry = null;
                while ((zipEntry = zipStream.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(zipEntry.Name);
                    string fileName = Path.GetFileName(zipEntry.Name);
                    if (!string.IsNullOrEmpty(directoryName))
                    {
                        Directory.CreateDirectory(directoryName);
                    }
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        if (zipEntry.CompressedSize == 0)
                            break;
                        if (zipEntry.IsDirectory)
                        {
                            directoryName = Path.GetDirectoryName(unZipDirecotyPath + zipEntry.Name);
                            Directory.CreateDirectory(directoryName);
                        }
                        using (FileStream stream = File.Create(unZipDirecotyPath + zipEntry.Name))
                        {
                            while (true)
                            {
                                int size = zipStream.Read(buffer, 0, buffer.Length);
                                if (size > 0)
                                {
                                    stream.Write(buffer, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        /*
        //System.IO.Compression.dll,System.IO.Compression.FileSystem.dll
        //自带的压缩
        public static void Zip(List<string> files, string savefile)
        {
            var zip = ZipFile.Open(savefile, ZipArchiveMode.Update);
            //var file = "";
            //var ext = "";

            for(var file in files)
            {
                zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
            }
            zip.Dispose();
        }

        public static void unZip(List<string> files, string savefile)
        {
            var zip = ZipFile.Open(savefile, ZipArchiveMode.Update);
            //var file = "";
            //var ext = "";

            for(var file in files)
            {
                zip.ExtractToDirectory(file, Path.GetFileName(file), CompressionLevel.Optimal);
            }
            zip.Dispose();
        }
        */
    }
}
