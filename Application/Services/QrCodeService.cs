using Application.Abstractions.Interfaces;
using Domain.Entities;
using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronBarCode;
using System.Runtime.InteropServices;
using Microsoft.Graph.Models;
using static QRCoder.PayloadGenerator;

namespace Application.Services
{
    public class QrCodeService : IQrCodeService
    {
        private readonly string _filesDirectory;
        public QrCodeService() 
        {
            _filesDirectory = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                                                ? Path.Combine(Directory.GetCurrentDirectory(), "..", "Application", "Files")
                                                : Path.Combine("/app/Files");
            Directory.CreateDirectory(_filesDirectory);
        }

        public string GenerateQrCode(string data)
        {
            string fileName = Guid.NewGuid().ToString() + ".png";
            string filePath = Path.Combine(_filesDirectory, fileName);
            QRCodeWriter.CreateQrCode(data, 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng(filePath);


            return fileName;
        }
    }
}
