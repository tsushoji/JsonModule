using JsonModule;
using JsonModule.entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace JsonModuleUnitTest
{
    [TestClass]
    public class JsonConverterTest
    {
        [TestMethod]
        public void CreateJsonFile()
        {
            var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var dicInfo = Directory.GetParent(exePath);
            var dicParent = dicInfo.FullName;
            var testJsonFileFolderPath = dicParent + "\\TestJsonFile";
            if (!(Directory.Exists(testJsonFileFolderPath)))
            {
                Directory.CreateDirectory(testJsonFileFolderPath);
            }

            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings
            {
                UseSimpleDictionaryFormat = true
            };
            DataContractJsonSerializer serializer;

            using (var fs = new FileStream("TestJsonFile\\LoginReq.json", FileMode.Create))
            {
                serializer = new DataContractJsonSerializer(typeof(LoginReq), settings);

                LoginReq loginReq = new LoginReq();
                loginReq.Address = "test@gmail.com";

                serializer.WriteObject(fs, loginReq);
            }

            using (var fs = new FileStream("TestJsonFile\\LoginRes.json", FileMode.Create))
            {
                serializer = new DataContractJsonSerializer(typeof(LoginRes), settings);

                LoginRes loginRes = new LoginRes();
                loginRes.Status = 1;
                loginRes.Authority = 10;

                serializer.WriteObject(fs, loginRes);
            }

            using (var fs = new FileStream("TestJsonFile\\AttendanceSendReq.json", FileMode.Create))
            {
                serializer = new DataContractJsonSerializer(typeof(AttendanceSendReq), settings);

                AttendanceSendReq attendanceSendReq = new AttendanceSendReq();
                attendanceSendReq.Date = "2022/03/01";
                attendanceSendReq.Type = 0;
                attendanceSendReq.Place = 2;
                attendanceSendReq.Rest = 60;
                attendanceSendReq.Time = "08:00";
                attendanceSendReq.NoWork = 0;

                serializer.WriteObject(fs, attendanceSendReq);
            }

            using (var fs = new FileStream("TestJsonFile\\AttendanceSendRes.json", FileMode.Create))
            {
                serializer = new DataContractJsonSerializer(typeof(AttendanceSendRes), settings);

                AttendanceSendRes attendanceSendRes = new AttendanceSendRes();
                attendanceSendRes.Status = 1;

                serializer.WriteObject(fs, attendanceSendRes);
            }

            using (var fs = new FileStream("TestJsonFile\\AttendanceConfirmReq.json", FileMode.Create))
            {
                serializer = new DataContractJsonSerializer(typeof(AttendanceConfirmReq), settings);

                AttendanceConfirmReq attendanceConfirmReq = new AttendanceConfirmReq();
                attendanceConfirmReq.Type = 0;
                attendanceConfirmReq.Word = "山田太郎";

                serializer.WriteObject(fs, attendanceConfirmReq);
            }

            using (var fs = new FileStream("TestJsonFile\\AttendanceConfirmRes.json", FileMode.Create))
            {
                serializer = new DataContractJsonSerializer(typeof(AttendanceConfirmRes), settings);

                AttendanceConfirmRes attendanceConfirmRes = new AttendanceConfirmRes();
                attendanceConfirmRes.Status = 1;
                attendanceConfirmRes.Personal = "山田太郎";
                attendanceConfirmRes.Team = "ICT";
                attendanceConfirmRes.IsWork = 1;
                attendanceConfirmRes.Place = 2;
                attendanceConfirmRes.OverTime = 120;

                serializer.WriteObject(fs, attendanceConfirmRes);
            }

            using (var fs = new FileStream("TestJsonFile\\ActualOutputReq.json", FileMode.Create))
            {
                serializer = new DataContractJsonSerializer(typeof(ActualOutputReq), settings);

                ActualOutputReq actualOutputReq = new ActualOutputReq();
                actualOutputReq.From = "2022/02/01";
                actualOutputReq.To = "2022/02/28";
                actualOutputReq.Addres = "test@gmail.com";

                serializer.WriteObject(fs, actualOutputReq);
            }

            using (var fs = new FileStream("TestJsonFile\\ActualOutputRes.json", FileMode.Create))
            {
                serializer = new DataContractJsonSerializer(typeof(ActualOutputRes), settings);

                ActualOutputRes actualOutputRes = new ActualOutputRes();
                actualOutputRes.Status = 1;
                var sunTimeList = new List<SunTime>();
                SunTime sunTime1 = new SunTime();
                sunTime1.Date = "2022/02/01";
                sunTime1.OnTime = 480;
                sunTime1.OverTime = 120;
                sunTimeList.Add(sunTime1);
                SunTime sunTime2 = new SunTime();
                sunTime2.Date = "2022/02/02";
                sunTime2.OnTime = 480;
                sunTime2.OverTime = 0;
                sunTimeList.Add(sunTime2);
                actualOutputRes.TimeList = sunTimeList;

                serializer.WriteObject(fs, actualOutputRes);
            }
        }

        [TestMethod]
        public void ConvertToJsonAndToByteLoginReq()
        {
            var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var dicInfo = Directory.GetParent(exePath);
            var dicParent = dicInfo.FullName;
            var testJsonFileFolderPath = dicParent + "\\TestJsonFile";
            var testJsonFilePath = testJsonFileFolderPath + "\\LoginReq.json";

            FileStream fs = new FileStream(testJsonFilePath, FileMode.Open, FileAccess.Read);

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

            byte[] data = JsonConverter<LoginReq>.ConvertToByte(goalJson);

            string json = JsonConverter<LoginReq>.ConvertToJson(data);

            Assert.AreEqual(goalJson, json);
        }

        [TestMethod]
        public void ConvertToJsonAndToByteLoginRes()
        {
            var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var dicInfo = Directory.GetParent(exePath);
            var dicParent = dicInfo.FullName;
            var testJsonFileFolderPath = dicParent + "\\TestJsonFile";
            var testJsonFilePath = testJsonFileFolderPath + "\\LoginRes.json";

            FileStream fs = new FileStream(testJsonFilePath, FileMode.Open, FileAccess.Read);

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

            byte[] data = JsonConverter<LoginRes>.ConvertToByte(goalJson);

            string json = JsonConverter<LoginRes>.ConvertToJson(data);

            Assert.AreEqual(goalJson, json);
        }

        [TestMethod]
        public void ConvertToJsonAndToByteAttendanceSendReq()
        {
            var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var dicInfo = Directory.GetParent(exePath);
            var dicParent = dicInfo.FullName;
            var testJsonFileFolderPath = dicParent + "\\TestJsonFile";
            var testJsonFilePath = testJsonFileFolderPath + "\\AttendanceSendReq.json";

            FileStream fs = new FileStream(testJsonFilePath, FileMode.Open, FileAccess.Read);

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

            byte[] data = JsonConverter<AttendanceSendReq>.ConvertToByte(goalJson);

            string json = JsonConverter<AttendanceSendReq>.ConvertToJson(data);

            Assert.AreEqual(goalJson, json);
        }

        [TestMethod]
        public void ConvertToJsonAndToByteAttendanceSendRes()
        {
            var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var dicInfo = Directory.GetParent(exePath);
            var dicParent = dicInfo.FullName;
            var testJsonFileFolderPath = dicParent + "\\TestJsonFile";
            var testJsonFilePath = testJsonFileFolderPath + "\\AttendanceSendRes.json";

            FileStream fs = new FileStream(testJsonFilePath, FileMode.Open, FileAccess.Read);

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

            byte[] data = JsonConverter<AttendanceSendRes>.ConvertToByte(goalJson);

            string json = JsonConverter<AttendanceSendRes>.ConvertToJson(data);

            Assert.AreEqual(goalJson, json);
        }

        [TestMethod]
        public void ConvertToJsonAndToByteAttendanceConfirmReq()
        {
            var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var dicInfo = Directory.GetParent(exePath);
            var dicParent = dicInfo.FullName;
            var testJsonFileFolderPath = dicParent + "\\TestJsonFile";
            var testJsonFilePath = testJsonFileFolderPath + "\\AttendanceConfirmReq.json";

            FileStream fs = new FileStream(testJsonFilePath, FileMode.Open, FileAccess.Read);

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

            byte[] data = JsonConverter<AttendanceConfirmReq>.ConvertToByte(goalJson);

            string json = JsonConverter<AttendanceConfirmReq>.ConvertToJson(data);

            Assert.AreEqual(goalJson, json);
        }

        [TestMethod]
        public void ConvertToJsonAndToByteAttendanceConfirmRes()
        {
            var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var dicInfo = Directory.GetParent(exePath);
            var dicParent = dicInfo.FullName;
            var testJsonFileFolderPath = dicParent + "\\TestJsonFile";
            var testJsonFilePath = testJsonFileFolderPath + "\\AttendanceConfirmRes.json";

            FileStream fs = new FileStream(testJsonFilePath, FileMode.Open, FileAccess.Read);

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

            byte[] data = JsonConverter<AttendanceConfirmRes>.ConvertToByte(goalJson);

            string json = JsonConverter<AttendanceConfirmRes>.ConvertToJson(data);

            Assert.AreEqual(goalJson, json);
        }

        [TestMethod]
        public void ConvertToJsonAndToByteActualOutputReq()
        {
            var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var dicInfo = Directory.GetParent(exePath);
            var dicParent = dicInfo.FullName;
            var testJsonFileFolderPath = dicParent + "\\TestJsonFile";
            var testJsonFilePath = testJsonFileFolderPath + "\\ActualOutputReq.json";

            FileStream fs = new FileStream(testJsonFilePath, FileMode.Open, FileAccess.Read);

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

            byte[] data = JsonConverter<ActualOutputReq>.ConvertToByte(goalJson);

            string json = JsonConverter<ActualOutputReq>.ConvertToJson(data);

            Assert.AreEqual(goalJson, json);
        }

        [TestMethod]
        public void ConvertToJsonAndToByteActualOutputRes()
        {
            var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var dicInfo = Directory.GetParent(exePath);
            var dicParent = dicInfo.FullName;
            var testJsonFileFolderPath = dicParent + "\\TestJsonFile";
            var testJsonFilePath = testJsonFileFolderPath + "\\ActualOutputRes.json";

            FileStream fs = new FileStream(testJsonFilePath, FileMode.Open, FileAccess.Read);

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
