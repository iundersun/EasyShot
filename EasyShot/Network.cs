using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace EasyShot
{
    sealed class Network
    {
        const string API_Key = "f0579a19b4d20ded0877c679245ebcd3";

        #region ключ от imageshack
        //const string API_Key="017BFLWXf133cd7e82571845ecdcd6f426866ec7"; 
        #endregion

        public static string PostToImgur(byte[] data)
        {
            string answer="";
            using (var w = new WebClient())
            {
                var values = new NameValueCollection
				{
					{ "key", API_Key },
					{ "image", Convert.ToBase64String(data)}
				};
                try
                {
                    byte[] response = w.UploadValues("http://imgur.com/api/upload.xml", values);
                    XDocument xDocument = XDocument.Load(new MemoryStream(response));
                    //log(xDocument);
                    answer = (string)xDocument.Root.Element("original_image");
                }
                catch (WebException wex)
                {
                    answer ="!"+wex.Message;
                }
                return answer;
            }
        }


        //private static void log(XDocument doc)
        //{
        //    const string FORMAT = "{0:HH-mm-ss}";
        //    FileStream fs = new FileStream("app.log", FileMode.Open, FileAccess.Write);
        //    StreamWriter sw = new StreamWriter(fs);
        //    sw.WriteLine(String.Format(FORMAT,DateTime.Now));
        //    sw.WriteLine(doc);
        //    sw.Dispose();
        //    fs.Dispose();
        //}
    }
}
