using JsonModule;
using JsonModule.entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace JsonModuleUnitTest
{
    [TestClass]
    public class JsonConverterTest
    {
        [TestMethod]
        public void ConvertToJsonAndToByteTest1()
        {
            FileStream fs = new FileStream(@"ActualOutputRes_success.json", FileMode.Open, FileAccess.Read);

            int fileSize = (int)fs.Length; // ファイルのサイズ
            byte[] buf = new byte[fileSize]; // データ格納用配列

            int readSize; // Readメソッドで読み込んだバイト数
            int remain = fileSize; // 読み込むべき残りのバイト数
            int bufPos = 0; // データ格納用配列内の追加位置

            while (remain > 0)
            {
                // 1024Bytesずつ読み込む
                readSize = fs.Read(buf, bufPos, Math.Min(1024, remain));

                bufPos += readSize;
                remain -= readSize;
            }
            fs.Dispose();

            string goalJson = System.Text.Encoding.UTF8.GetString(buf);

            byte[] data = JsonConverter<ActualOutputRes>.ConvertToByte(goalJson);

            string json = JsonConverter<ActualOutputRes>.ConvertToJson(data);

            Assert.AreEqual(goalJson, json);
        }

        [TestMethod]
        public void ConvertToJsonAndToByteTest2()
        {
            FileStream fs = new FileStream(@"ActualOutputRes_fail.json", FileMode.Open, FileAccess.Read);

            int fileSize = (int)fs.Length; // ファイルのサイズ
            byte[] buf = new byte[fileSize]; // データ格納用配列

            int readSize; // Readメソッドで読み込んだバイト数
            int remain = fileSize; // 読み込むべき残りのバイト数
            int bufPos = 0; // データ格納用配列内の追加位置

            while (remain > 0)
            {
                // 1024Bytesずつ読み込む
                readSize = fs.Read(buf, bufPos, Math.Min(1024, remain));

                bufPos += readSize;
                remain -= readSize;
            }
            fs.Dispose();

            string goalJson = System.Text.Encoding.UTF8.GetString(buf);

            byte[] data = JsonConverter<ActualOutputRes>.ConvertToByte(goalJson);

            Assert.IsNull(data);

            string json = JsonConverter<ActualOutputRes>.ConvertToJson(data);

            Assert.IsNull(json);
        }
    }
}
