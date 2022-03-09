using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace myAPI.Controllers
{
    [Route("QRCode")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        public byte[] ImageToByteArray(System.Drawing.Image imageIn )
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();    
        }

        [HttpGet("yourQrCode")]
        public async Task<ActionResult> GenerateQRCode(string text)
        {
            QRCodeGenerator qrcode = new QRCodeGenerator();
            QRCodeData qrdata = qrcode.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            //QRCode
            QRCode qrCode = new QRCode(qrdata);
            Image qrCodeImage = qrCode.GetGraphic(20);

            var bytes = ImageToByteArray(qrCodeImage);
            return File(bytes, "image/bmp");
        }


    }
}
