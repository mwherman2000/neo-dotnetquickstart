using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Reference: https://docs.microsoft.com/en-us/dotnet/standard/security/walkthrough-creating-a-cryptographic-application
// Reference: https://dotnetcodr.com/2013/11/11/introduction-to-asymmetric-encryption-in-net-cryptography/

namespace NPC.mwherman2000.NeoExpenses1.TestEncryption
{
    public partial class Form1 : Form
    {
        // Declare CspParmeters and RsaCryptoServiceProvider
        // objects with global scope of your Form class.
        CspParameters cspParameters = new CspParameters();
        RSACryptoServiceProvider rsa;

        // Path variables for source, encryption, and
        // decryption folders. Must end with a backslash.
        const string KeysFolder = @"c:\temp\TestEncryption\Keys\";
        const string EncrFolder = @"c:\temp\TestEncryption\Encrypt\";
        const string DecrFolder = @"c:\temp\TestEncryption\Decrypt\";
        const string SrcFolder =  @"c:\temp\TestEncryption\docs\";

        // Public key file
        const string KeyFile = @"rsaKeys.xml";
        const string PublicKeyFile = @"rsaPublicKey.xml";
        const string PublicPrivateKeyFile = @"rsaPublicPrivateKeys.xml";

        // Key container name for
        // private/public key value pair.
        const string keyName = "Key01";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEncryptFile_Click(object sender, System.EventArgs e)
        {
            if (rsa == null)
                MessageBox.Show("Key not set");
            else
            {

                // Display a dialog box to select a file to encrypt.
                openFileDialog1.InitialDirectory = SrcFolder;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fName = openFileDialog1.FileName;
                    if (fName != null)
                    {
                        FileInfo fInfo = new FileInfo(fName);
                        // Pass the file name without the path.
                        string inFilename = fInfo.FullName;
                        string outFilename = EncryptFile(inFilename);
                        MessageBox.Show(inFilename + " encrypted > " + outFilename, "Encrypt File");
                    }
                }
            }
        }

        private void buttonDecryptFile_Click(object sender, EventArgs e)
        {
            if (rsa == null)
                MessageBox.Show("Key not set");
            else
            {
                // Display a dialog box to select the encrypted file.
                openFileDialog2.InitialDirectory = EncrFolder;
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    string fName = openFileDialog2.FileName;
                    if (fName != null)
                    {
                        FileInfo fi = new FileInfo(fName);
                        string inFilename = fi.Name;
                        string outFilename = DecryptFile(inFilename);
                        MessageBox.Show(inFilename + " decrypted > " + outFilename, "Encrypt File");
                    }
                }
            }
        }

        static string prevXML = "";
        private void buttonCreateAsmKeys_Click(object sender, System.EventArgs e)
        {
            // Stores a key pair in the key container.
            cspParameters.KeyContainerName = keyName;
            // Reference: https://stackoverflow.com/questions/1307204/how-to-generate-unique-public-and-private-key-via-rsa
            if (rsa != null)
            {
                rsa.PersistKeyInCsp = false;    // don't save the keys in the Windows local key store
                rsa.Clear();                    // clear it if it's there
                rsa.Dispose();                  // dispose this RSA provider
            }
            rsa = new RSACryptoServiceProvider(cspParameters);
            rsa.PersistKeyInCsp = false;        // don't save the keys in the Windows local key store
            if (rsa.PublicOnly == true)
                label1.Text = "Key: " + cspParameters.KeyContainerName + " - Public Only";
            else
                label1.Text = "Key: " + cspParameters.KeyContainerName + " - Full Key Pair";
            string newXML = rsa.ToXmlString(true);
            if (prevXML != "") // check if it's equal to the new keys
            {
                bool equal = (newXML == prevXML);
                if (equal)
                {
                    MessageBox.Show("new keys == previous keys");
                }
                else
                {
                    MessageBox.Show("new keys != previous keys");
                }
            }
            prevXML = newXML;
        }

        void buttonExportPublicKey_Click(object sender, System.EventArgs e)
        {
            if (rsa == null)
            {
                MessageBox.Show("Key not set");
                return;
            }

            // Save the public key created by the RSA
            // to a file. Caution, persisting the
            // key to a file is a security risk.
            Directory.CreateDirectory(KeysFolder);
            bool exportPublicAndPrivateKeys = checkBoxExportPrivateKey.Checked;
            if (rsa.PublicOnly == true && exportPublicAndPrivateKeys)
            {
                MessageBox.Show("Key is PublicOnly. Cannot export Public and Private keys");
                return;
            }
            StreamWriter sw = new StreamWriter(KeysFolder + KeyFile, false);
            sw.Write(rsa.ToXmlString(exportPublicAndPrivateKeys)); // MWH
            sw.Close();

            sw = new StreamWriter(KeysFolder + PublicKeyFile, false);
            sw.Write(rsa.ToXmlString(false)); // MWH
            sw.Close();

            sw = new StreamWriter(KeysFolder + PublicPrivateKeyFile, false);
            sw.Write(rsa.ToXmlString(true)); // MWH
            sw.Close();

            // Reference: https://msdn.microsoft.com/en-us/library/system.io.compression.gzipstream%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
            using (FileStream originalFileStream = new FileStream(KeysFolder + PublicKeyFile, FileMode.Open))
            {
                using (FileStream compressedFileStream = File.Create(KeysFolder + PublicKeyFile + ".gz"))
                {
                    using (GZipStream compressedStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressedStream);
                    }
                }
                FileInfo compressedFileStreamInfo = new FileInfo(KeysFolder + PublicKeyFile + ".gz");
                long savings = originalFileStream.Length - compressedFileStreamInfo.Length;
                MessageBox.Show(String.Format("Compressed {0} from {1} to {2} bytes = {3} bytes = {4}%",
                                                KeysFolder + PublicKeyFile,
                                                originalFileStream.Length.ToString(),
                                                compressedFileStreamInfo.Length.ToString(),
                                                -savings,
                                                (-100 * savings / originalFileStream.Length).ToString())
                                );
            }
            using (FileStream compressedFileStream = new FileStream(KeysFolder + PublicKeyFile + ".gz", FileMode.Open))
            {
                using (FileStream decompressedFileStream = File.Create(KeysFolder + PublicKeyFile.Replace(".xml", "2.xml")))
                {
                    using (GZipStream steamToBeDecompressed = new GZipStream(compressedFileStream, CompressionMode.Decompress))
                    {
                        steamToBeDecompressed.CopyTo(decompressedFileStream);
                    }
                }
                FileInfo compressedFileStreamInfo = new FileInfo(KeysFolder + PublicKeyFile + ".gz"); // Seems to close early
                FileInfo decompressedFileStreamInfo = new FileInfo(KeysFolder + PublicKeyFile.Replace(".xml", "2.xml"));
                MessageBox.Show(String.Format("Decompressed {0} from {1} to {2} bytes",
                                                KeysFolder + PublicKeyFile + ".gz",
                                                compressedFileStreamInfo.Length.ToString(),
                                                decompressedFileStreamInfo.Length.ToString()));
            }

            using (FileStream originalFileStream = new FileStream(KeysFolder + PublicPrivateKeyFile, FileMode.Open))
            {
                using (FileStream compressedFileStream = File.Create(KeysFolder + PublicPrivateKeyFile + ".gz"))
                {
                    using (GZipStream compressedStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressedStream);
                    }
                }
                FileInfo compressedFileStreamInfo = new FileInfo(KeysFolder + PublicPrivateKeyFile + ".gz");
                long savings = originalFileStream.Length - compressedFileStreamInfo.Length;
                MessageBox.Show(String.Format("Compressed {0} from {1} to {2} bytes = {3} bytes = {4}%",
                                                KeysFolder + PublicPrivateKeyFile, 
                                                originalFileStream.Length.ToString(), 
                                                compressedFileStreamInfo.Length.ToString(),
                                                -savings,
                                                (-100 * savings / originalFileStream.Length).ToString())
                                );
            }
            using (FileStream compressedFileStream = new FileStream(KeysFolder + PublicPrivateKeyFile + ".gz", FileMode.Open))
            {
                using (FileStream decompressedFileStream = File.Create(KeysFolder + PublicPrivateKeyFile.Replace(".xml", "2.xml")))
                {
                    using (GZipStream steamToBeDecompressed = new GZipStream(compressedFileStream, CompressionMode.Decompress))
                    {
                        steamToBeDecompressed.CopyTo(decompressedFileStream);
                    }
                }
                FileInfo compressedFileStreamInfo = new FileInfo(KeysFolder + PublicPrivateKeyFile + ".gz"); // Seems to close early
                FileInfo decompressedFileStreamInfo = new FileInfo(KeysFolder + PublicPrivateKeyFile.Replace(".xml", "2.xml"));
                MessageBox.Show(String.Format("Decompressed {0} from {1} to {2} bytes",
                                                KeysFolder + PublicPrivateKeyFile + ".gz",
                                                compressedFileStreamInfo.Length.ToString(), 
                                                decompressedFileStreamInfo.Length.ToString()));
            }

            MessageBox.Show(KeysFolder + KeyFile + " exported", "Export Public Key");
        }

        void buttonImportPublicKey_Click(object sender, System.EventArgs e)
        {
            if (!File.Exists(KeysFolder + KeyFile))
            {
                MessageBox.Show("Missing key file: " + KeysFolder + KeyFile);
                return;
            }

            StreamReader sr = new StreamReader(KeysFolder + KeyFile);
            cspParameters.KeyContainerName = keyName;
            rsa = new RSACryptoServiceProvider(cspParameters);
            string keytxt = sr.ReadToEnd();
            sr.Close();
            if (String.IsNullOrEmpty(keytxt))
            {
                MessageBox.Show("Empty key file: " + KeysFolder + KeyFile);
                return;
            }
            rsa.FromXmlString(keytxt);
            rsa.PersistKeyInCsp = true;
            if (rsa.PublicOnly == true)
                label1.Text = "Key: " + cspParameters.KeyContainerName + " - Public Only";
            else
                label1.Text = "Key: " + cspParameters.KeyContainerName + " - Full Key Pair";
            MessageBox.Show(KeysFolder + KeyFile + " imported", "Import Public Key");
        }

        private void buttonGetPrivateKey_Click(object sender, EventArgs e)
        {
            cspParameters.KeyContainerName = keyName;

            rsa = new RSACryptoServiceProvider(cspParameters);
            rsa.PersistKeyInCsp = true;

            if (rsa.PublicOnly == true)
                label1.Text = "Key: " + cspParameters.KeyContainerName + " - Public Only";
            else
                label1.Text = "Key: " + cspParameters.KeyContainerName + " - Full Key Pair";

        }

        private string EncryptFile(string inFile)
        {

            // Create instance of Rijndael for
            // symmetric encryption of the data.
            RijndaelManaged rjndl = new RijndaelManaged();
            rjndl.KeySize = 256;
            rjndl.BlockSize = 256;
            rjndl.Mode = CipherMode.CBC;
            ICryptoTransform transform = rjndl.CreateEncryptor();

            // Use RSACryptoServiceProvider to
            // encrypt the Rijndael key.
            // rsa is previously instantiated: 
            // rsa = new RSACryptoServiceProvider(cspp);
            byte[] keyRSAEncrypted = rsa.Encrypt(rjndl.Key, false);

            // Create byte arrays to contain
            // the length values of the key and IV.
            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            int lKey = keyRSAEncrypted.Length;
            LenK = BitConverter.GetBytes(lKey);
            int lIV = rjndl.IV.Length;
            LenIV = BitConverter.GetBytes(lIV);

            // Write the following to the FileStream
            // for the encrypted file (outFs):
            // - length of the key
            // - length of the IV
            // - encrypted key
            // - the IV
            // - the encrypted cipher content

            int startFileName = inFile.LastIndexOf("\\") + 1;
            // Change the file's extension to ".enc"
            //string outFile = EncrFolder + inFile.Substring(startFileName, inFile.LastIndexOf(".") - startFileName) + ".enc";
            string outFile = EncrFolder + inFile.Substring(startFileName) + ".enc";

            using (FileStream outFs = new FileStream(outFile, FileMode.Create))
            {

                outFs.Write(LenK, 0, 4);
                outFs.Write(LenIV, 0, 4);
                outFs.Write(keyRSAEncrypted, 0, lKey);
                outFs.Write(rjndl.IV, 0, lIV);

                // Now write the cipher text using
                // a CryptoStream for encrypting.
                using (CryptoStream outStreamEncrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                {

                    // By encrypting a chunk at
                    // a time, you can save memory
                    // and accommodate large files.
                    int count = 0;
                    int offset = 0;

                    // blockSizeBytes can be any arbitrary size.
                    int blockSizeBytes = rjndl.BlockSize / 8;
                    byte[] data = new byte[blockSizeBytes];
                    int bytesRead = 0;

                    using (FileStream inFs = new FileStream(inFile, FileMode.Open))
                    {
                        do
                        {
                            count = inFs.Read(data, 0, blockSizeBytes);
                            offset += count;
                            outStreamEncrypted.Write(data, 0, count);
                            bytesRead += blockSizeBytes;
                        }
                        while (count > 0);
                        inFs.Close();
                    }
                    outStreamEncrypted.FlushFinalBlock();
                    outStreamEncrypted.Close();
                }
                outFs.Close();
            }
            return outFile;
        }

        private string DecryptFile(string inFile)
        {

            // Create instance of Rijndael for
            // symmetric decryption of the data.
            RijndaelManaged rjndl = new RijndaelManaged();
            rjndl.KeySize = 256;
            rjndl.BlockSize = 256;
            rjndl.Mode = CipherMode.CBC;

            // Create byte arrays to get the length of
            // the encrypted key and IV.
            // These values were stored as 4 bytes each
            // at the beginning of the encrypted package.
            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            // Construct the file name for the decrypted file.
            //string outFile = DecrFolder + inFile.Substring(0, inFile.LastIndexOf(".")) + ".txt";
            string outFile = DecrFolder + inFile.Replace(".enc", "");

            // Use FileStream objects to read the encrypted
            // file (inFs) and save the decrypted file (outFs).
            using (FileStream inFs = new FileStream(EncrFolder + inFile, FileMode.Open))
            {

                inFs.Seek(0, SeekOrigin.Begin);
                inFs.Seek(0, SeekOrigin.Begin);
                inFs.Read(LenK, 0, 3);
                inFs.Seek(4, SeekOrigin.Begin);
                inFs.Read(LenIV, 0, 3);

                // Convert the lengths to integer values.
                int lenK = BitConverter.ToInt32(LenK, 0);
                int lenIV = BitConverter.ToInt32(LenIV, 0);

                // Determine the start postition of
                // the ciphter text (startC)
                // and its length(lenC).
                int startC = lenK + lenIV + 8;
                int lenC = (int)inFs.Length - startC;

                // Create the byte arrays for
                // the encrypted Rijndael key,
                // the IV, and the cipher text.
                byte[] KeyEncrypted = new byte[lenK];
                byte[] IV = new byte[lenIV];

                // Extract the key and IV
                // starting from index 8
                // after the length values.
                inFs.Seek(8, SeekOrigin.Begin);
                inFs.Read(KeyEncrypted, 0, lenK);
                inFs.Seek(8 + lenK, SeekOrigin.Begin);
                inFs.Read(IV, 0, lenIV);
                Directory.CreateDirectory(DecrFolder);
                // Use RSACryptoServiceProvider
                // to decrypt the Rijndael key.
                byte[] KeyDecrypted = null;
                try
                {
                    KeyDecrypted = rsa.Decrypt(KeyEncrypted, false);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source);
                    return "FAILED";
                }

                // Decrypt the key.
                ICryptoTransform transform = rjndl.CreateDecryptor(KeyDecrypted, IV);

                // Decrypt the cipher text from
                // from the FileSteam of the encrypted
                // file (inFs) into the FileStream
                // for the decrypted file (outFs).
                using (FileStream outFs = new FileStream(outFile, FileMode.Create))
                {

                    int count = 0;
                    int offset = 0;

                    // blockSizeBytes can be any arbitrary size.
                    int blockSizeBytes = rjndl.BlockSize / 8;
                    byte[] data = new byte[blockSizeBytes];


                    // By decrypting a chunk a time,
                    // you can save memory and
                    // accommodate large files.

                    // Start at the beginning
                    // of the cipher text.
                    inFs.Seek(startC, SeekOrigin.Begin);
                    using (CryptoStream outStreamDecrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        do
                        {
                            count = inFs.Read(data, 0, blockSizeBytes);
                            offset += count;
                            outStreamDecrypted.Write(data, 0, count);

                        }
                        while (count > 0);

                        outStreamDecrypted.FlushFinalBlock();
                        outStreamDecrypted.Close();
                    }
                    outFs.Close();
                }
                inFs.Close();
            }
            return outFile;
        }
    }
}
