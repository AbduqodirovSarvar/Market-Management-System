using Application.Abstractions.Interfaces;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using IronBarCode;


namespace Application.Services
{
    public class QrCodeService : IQrCodeService
    {
        private readonly string _filesDirectory;
        private readonly ILogger<QrCodeService> _logger;

        public QrCodeService(ILogger<QrCodeService> logger)
        {
            _logger = logger;
            _filesDirectory = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                                                ? Path.Combine(Directory.GetCurrentDirectory(), "..", "Application", "Files")
                                                : Path.Combine("/app/Files");
            try
            {
                Directory.CreateDirectory(_filesDirectory);
                _logger.LogInformation("Files directory created or exists at: {_filesDirectory}", _filesDirectory);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to create files directory: {ex.Message}", ex.Message);
                throw;
            }
        }

        /*public string GenerateQrCode(string data)
        {
            string fileName = Guid.NewGuid().ToString() + ".png";
            string filePath = Path.Combine(_filesDirectory, fileName);

            try
            {
                using (QRCodeGenerator qrGenerator = new())
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.M);
                    using QRCode qrCode = new QRCode(qrCodeData);
                    using Bitmap qrCodeImage = qrCode.GetGraphic(20);
                    qrCodeImage.Save(filePath, ImageFormat.Png);
                }

                _logger.LogInformation("QR code saved to: {filePath}", filePath);
                return fileName;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to generate QR code: {ex.Message}", ex.Message);
                throw;
            }
        }*/

        public string GenerateQrCode(string data)
        {
            string fileName = Guid.NewGuid().ToString() + ".png";
            string filePath = Path.Combine(_filesDirectory, fileName);

            try
            {
                var qrCode = QRCodeWriter.CreateQrCode(data, 500, QRCodeWriter.QrErrorCorrectionLevel.Medium);
                qrCode.SaveAsPng(filePath);

                _logger.LogInformation("QR code saved to: {FilePath}", filePath);
                return fileName;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to generate QR code: {Message}", ex.Message);
                throw;
            }
        }

    }
}
