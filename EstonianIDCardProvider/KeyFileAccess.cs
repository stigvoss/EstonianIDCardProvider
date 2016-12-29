using System;
using System.IO;

namespace EstonianIDCardProvider
{
    public class KeyFileAccess : IDisposable
    {
        private const string EXTENSION_KEY_FILE = ".kbfx";
        private const string EXTENSION_DATABASE_FILE = ".kdbx";

        private string _databaseFilePath;
        private FileStream _fileStream;

        public KeyFileAccess(string databaseFilePath)
        {
            _databaseFilePath = databaseFilePath;
        }

        public void Create()
        {
            string keyFilePath = GetKeyFilePath(_databaseFilePath);

            if (File.Exists(keyFilePath))
            {
                throw new Exception("Key File already exists!");
            }

            if (_fileStream == null)
            {
                _fileStream = File.Create(keyFilePath);
            }
        }

        public void Open()
        {
            string keyFilePath = GetKeyFilePath(_databaseFilePath);

            if (!File.Exists(keyFilePath))
            {
                throw new FileNotFoundException("Key File not found!");
            }

            if (_fileStream == null)
            {
                _fileStream = File.Open(keyFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
        }

        public byte[] Read()
        {
            _fileStream.Seek(0, SeekOrigin.Begin);

            long fileSize = _fileStream.Length;
            byte[] encryptedKey = new byte[fileSize];

            if (_fileStream == null)
            {
                throw new ArgumentNullException("Key File is not open!");
            }

            checked
            {
                _fileStream.Read(encryptedKey, 0, (int)fileSize);
            }

            return encryptedKey;
        }

        public void Write(byte[] encryptedKey)
        {
            _fileStream.Write(encryptedKey, 0, encryptedKey.Length);
        }

        private string GetKeyFilePath(string databaseFilePath)
        {
            string keyFilePath;

            if (databaseFilePath.EndsWith(EXTENSION_DATABASE_FILE))
            {
                string trimmedFilePath = databaseFilePath.Substring(0, databaseFilePath.Length - 5);
                keyFilePath = trimmedFilePath + EXTENSION_KEY_FILE;
            }
            else
            {
                keyFilePath = databaseFilePath + EXTENSION_KEY_FILE;
            }

            return keyFilePath;
        }

        public void Dispose()
        {
            if(_fileStream != null)
            {
                _fileStream.Dispose();
                _fileStream = null;
            }
        }
    }
}