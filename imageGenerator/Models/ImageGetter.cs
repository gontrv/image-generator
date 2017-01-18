using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;
using System.Net;
using System.IO;

namespace imageGenerator.Models
{
    public class ImageGetter
    {
        // ends with slash
        string _storagePuth;
        public byte[] Data { get; set; }
        public string Ext { get; set; }

        public Dictionary<string, ImageFormat> _exts = new Dictionary<string, ImageFormat>
        {
            { "jpg", ImageFormat.Jpeg },
            { "png", ImageFormat.Png },
            { "gif", ImageFormat.Gif },
            { "bmp", ImageFormat.Bmp }
        };

        public ImageGetter(string storagePuth)
	    {
            _storagePuth = storagePuth;
	    }

        public bool  TryGet(string imgName)
        {
            if (string.IsNullOrEmpty(imgName)) return false;
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    Data = webClient.DownloadData(_storagePuth + imgName);
                    Ext = imgName.Substring(imgName.Length - 3);
                }
                catch (System.Net.WebException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                return true;
            }
        }
    }
}