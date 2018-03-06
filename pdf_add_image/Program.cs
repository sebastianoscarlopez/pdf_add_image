using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace pdf_add_image
{
    class Program
    {
        static void Main(string[] args)
        {
            var src = @"C:\temporal\Contratos\solicitudAlta_otroEjemplo.pdf";
            var dest = @"C:\temporal\Contratos\prueba.pdf";
            var img = @"C:\temporal\guybrush.jpeg";
            var txt = "TEXTO PRUEBA";
            var pageIdx = 3;
            var imgX = 100;
            var imgY = 50;
            var txtX = imgX + 100;
            var txtY = imgY + 100;
            new Program().procesar(src, dest, img, txt, pageIdx, imgX, imgY, txtX, txtY);
        }
        void procesar(string src, string dest, string img, string txt, int pageIdx, float imgX, float imgY, float txtX, float txtY)
        {
            var reader = new PdfReader(src);
            var writer = new PdfWriter(dest);
            var pdfDest = new PdfDocument(reader, writer);
            var document = new Document(pdfDest);

            var image = new Image(ImageDataFactory.Create(img));
            image.SetFixedPosition(pageIdx, imgX, imgY);
            var text= new Paragraph(txt);
            text.SetFixedPosition(pageIdx, txtX, txtY);
            document.Add(image);
            document.Add(text);
            document.Close();
        }
    }
}
