using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using test.iOS.Enum;
using test.iOS.Helper;
using test.iOS.Interface;
using Xamarin.Forms;

namespace test
{
    public class PDFToHtml
    {
        private bool ispdfloading;
        private PDFEnum pDFEnum;

        public bool IsPDFGenerating
        {
            get { return ispdfloading; }
            set
            {
                ispdfloading = value;
            }
        }

        public PDFEnum Status
        {
            get { return pDFEnum; }
            set
            {
                pDFEnum = value;
            }
        }

        public string HTMLString { get; set; }

        public string Data { get; set; }

        public string URLPrinter { get; set; }

        public double PageHeight { get; set; } = 172;

        public double PageWidth { get; set; } = 215;

        public string FilePath { get; set; }

        public void GeneratePDF()
        {
            try
            {
                DependencyService.Get<IPDFConverter>().ConvertHTMLtoPDF(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("PDF is not generated: " + ex.Message);
            }
        }
    }
}

