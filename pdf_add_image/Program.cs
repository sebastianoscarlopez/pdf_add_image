using System;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace pdf_add_image
{
    class Program
    {
        private Document document = null;
        string src, dest, img;
        int pageIdx;
        float imgX, imgY, imgH, imgW;
        static void Main(string[] args)
        {
            var tpl = @"C:\temporal\Contratos\{0}.{1}";

            var file = @"Template_Alta_1_V_01";
            var fileFirma = string.Format(tpl, @"2018020500000006", "");
            new Program()
            {
                src = string.Format(tpl, file, "pdf"),
                dest = string.Format(tpl, file + @"_FIRMA_1", "pdf"),
                img = fileFirma,
                pageIdx = 3,
                imgX = 65f,
                imgY = 65f,
                imgH = 50f,
                imgW = 144f
            }.procesar().cerrar();
            new Program()
            {
                src = string.Format(tpl, file, "pdf"),
                dest = string.Format(tpl, file + @"_FIRMA_2", "pdf"),
                img = string.Format(tpl, @"2018031400000006", ""),
                pageIdx = 3,
                imgX = 65f,
                imgY = 65f,
                imgH = 50f,
                imgW = 144f
            }.procesar().cerrar();

            file = @"Template_Portabilidad_1_V_01";
            var prg = new Program()
            {
                src = string.Format(tpl, file, "pdf"),
                dest = string.Format(tpl, file + @"_FIRMA_1", "pdf"),
                img = string.Format(tpl, @"2018020500000006", ""),
                pageIdx = 1,
                imgX = 80f,
                imgY = 82f,
                imgH = 40f,
                imgW = 132f
            }.procesar();
            prg.pageIdx = 2;
            prg.imgY = 144f;
            prg.procesar().cerrar();
            prg = new Program()
            {
                src = string.Format(tpl, file, "pdf"),
                dest = string.Format(tpl, file + @"_FIRMA_2", "pdf"),
                img = string.Format(tpl, @"2018031400000006", ""),
                pageIdx = 1,
                imgX = 80f,
                imgY = 82f,
                imgH = 40f,
                imgW = 132f
            }.procesar();
            prg.pageIdx = 2;
            prg.imgY = 144f;
            prg.procesar().cerrar();
        }

        private float calcularAncho(int height, int width)
        {
            var relation = imgH / imgW;
            var relationImg = (float)height/ width;
            var scale = relationImg > relation
                ? imgH / height
                : imgW / width;
            var result = width * scale;
            return result;
        }

        Program procesar()
        {
            if (document == null)
            {
                var reader = new PdfReader(src);
                var writer = new PdfWriter(dest);
                var pdfDest = new PdfDocument(reader, writer);
                document = new Document(pdfDest);
            }
            var image = new Image(ImageDataFactory.Create(img));
            var imgFirma = System.Drawing.Image.FromFile(img);

            image.SetFixedPosition(
                pageNumber: pageIdx, left: imgX, bottom: imgY, width:
                calcularAncho(imgFirma.Height, imgFirma.Width));
            document.Add(image);
            return this;
        }
        void cerrar()
        {
            document.Close();
        }
    }
}
