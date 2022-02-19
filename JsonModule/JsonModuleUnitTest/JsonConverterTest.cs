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
            var targetObj = new ActualOutputRes();
            targetObj.Status = 1;
            var sunTime1 = new SunTime();
            sunTime1.Date = "2022/02/01";
            sunTime1.OnTime = 480;
            sunTime1.OverTime = 60;
            targetObj.TimeList.Add(sunTime1);

            FileStream fs = new FileStream(@"ActualOutputRes.json", FileMode.Open, FileAccess.Read);

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
    }
}
