﻿using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace pdf_add_image
{
    class Program
    {
        static void Main(string[] args)
        {
            var src = @"C:\temporal\Contratos\solicitudAlta_otroEjemplo.pdf";
            var dest = @"C:\temporal\Contratos\prueba.pdf";
            var img = @"C:\temporal\guybrush.png";
            var txt = "TEXTO PRUEBA";
            var pageIdx = 3;
            var imgX = 100f;
            var imgY = 50f;
            var txtX = imgX + 100f;
            var txtY = imgY;
            new Program().procesar(src, dest, img, txt, pageIdx, imgX, imgY, txtX, txtY);
        }
        void procesar(string src, string dest, string img, string txt, int pageIdx, float imgX, float imgY, float txtX, float txtY)
        {
            var reader = new PdfReader(src);
            var writer = new PdfWriter(dest);
            var pdfDest = new PdfDocument(reader, writer);
            var document = new Document(pdfDest);

            var image = new Image(ImageDataFactory.Create(img));
            image.SetFixedPosition(pageNumber: pageIdx, left: imgX, bottom: imgY, width: 100f);
            var text= new Paragraph(txt);
            text.SetFixedPosition(pageNumber: pageIdx, left: txtX, bottom: txtY, width: 100f);
            document.Add(image);
            document.Add(text);
            document.Close();
        }
    }
}
