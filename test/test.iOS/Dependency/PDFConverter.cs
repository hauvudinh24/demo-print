using System;
using System.Drawing.Printing;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using SpriteKit;
using test;
using test.iOS.Dependency;
using test.iOS.Enum;
using test.iOS.Helper.Native;
using test.iOS.Interface;
using UIKit;
using WebKit;
using Xamarin.Forms;
using static Xamarin.Forms.Internals.GIFBitmap;

[assembly: Dependency(typeof(PDFConverter))]
namespace test.iOS.Dependency
{
    public class PDFConverter : IPDFConverter
    {
        PrintJob printer = new PrintJob();

        public void ConvertHTMLtoPDF(PDFToHtml _PDFToHtml)
        {
            try
            {
                WKWebView webView = new WKWebView(new CGRect(0, 0, (int)_PDFToHtml.PageWidth, (int)_PDFToHtml.PageHeight), new WKWebViewConfiguration());
                webView.UserInteractionEnabled = false;
                webView.BackgroundColor = UIColor.White;
                webView.NavigationDelegate = new WebViewCallBack(_PDFToHtml, printer);
                webView.LoadHtmlString(_PDFToHtml.HTMLString, null);
                Console.Write(_PDFToHtml.HTMLString);
            }
            catch
            {
                _PDFToHtml.Status = PDFEnum.Failed;
            }
        }
    }
}