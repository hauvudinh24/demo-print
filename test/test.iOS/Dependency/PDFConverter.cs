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
        public void ConvertHTMLtoPDF(PDFToHtml _PDFToHtml)
        {
            try
            {
                Console.WriteLine("CONVERT");
                WKWebView webView = new WKWebView(new CGRect(0, 0, (int)_PDFToHtml.PageWidth, (int)_PDFToHtml.PageHeight), new WKWebViewConfiguration());
                webView.UserInteractionEnabled = false;
                webView.BackgroundColor = UIColor.White;
                webView.NavigationDelegate = new WebViewCallBack(_PDFToHtml);
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


//[assembly: Dependency(typeof(PDFConverter))]
//namespace test.iOS.Dependency
//{
//    public class PDFConverter : IPDFConverter
//    {
//        private WKWebView wkWebView;
//        private NSObject urlObservation;
//        private Action<byte[]> onHtmlRendered;

//        public PDFConverter(Action<byte[]> onHtmlRendered)
//        {
//            Console.Write("CONVERT " + onHtmlRendered);
//            this.onHtmlRendered = onHtmlRendered;
//        }

//        public void ConvertHTMLtoPDF(PDFToHtml _PDFToHtml)
//        {
//            Console.Write("RUN_HERE ");

//            WKWebView webView = new WKWebView(new CGRect(0, 0, (int)_PDFToHtml.PageWidth, (int)_PDFToHtml.PageHeight), new WKWebViewConfiguration());
//            webView.UserInteractionEnabled = false;
//            webView.BackgroundColor = UIColor.White;
//            webView.NavigationDelegate = new WebViewCallBack(_PDFToHtml);
//            webView.LoadHtmlString(_PDFToHtml.HTMLString, null);

//            //webView.AddObserver("loading", NSKeyValueObservingOptions.New, (obj) =>
//            //{
//            //    // Workaround for loading local images
//            //    Task.Delay(500).ContinueWith(_ =>
//            //    {
//            //        using (var renderer = new UIPrintPageRenderer())
//            //        {
//            //            CGSize pageSize = new CGSize(_PDFToHtml.PageWidth, _PDFToHtml.PageHeight);
//            //            CGRect rect = new CGRect(0, 0, pageSize.Width - (0 * 2), pageSize.Height - (0 * 2));
//            //            CGRect margin = new CGRect(0, 0, _PDFToHtml.PageWidth, _PDFToHtml.PageHeight);
//            //            renderer.AddPrintFormatter(wkWebView.ViewPrintFormatter, 0);

//            //            renderer.SetValueForKey(NSValue.FromCGRect(rect), new NSString("paperRect"));
//            //            renderer.SetValueForKey(NSValue.FromCGRect(margin), new NSString("printableRect"));

//            //            using (var pdfData = new NSMutableData())
//            //            {
//            //                UIGraphics.BeginPDFContext(pdfData, rect, null);

//            //                for (nuint i = 0; i < (nuint)renderer.NumberOfPages; i++)
//            //                {
//            //                    UIGraphics.BeginPDFPage();
//            //                    renderer.DrawPage((nint)i, UIGraphics.PDFContextBounds);
//            //                }

//            //                UIGraphics.EndPDFContext();

//            //                Device.BeginInvokeOnMainThread(() =>
//            //                {
//            //                    //if (viewController.View.ViewWithTag(wkWebView.Tag) is UIView viewWithTag)
//            //                    //{
//            //                    //    viewWithTag.RemoveFromSuperview();
//            //                    //}

//            //                    //if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
//            //                    //{
//            //                    //    WKWebsiteDataStore.DefaultDataStore.FetchDataRecordsOfTypes(WKWebsiteDataStore.AllWebsiteDataTypes, (records) =>
//            //                    //    {
//            //                    //        foreach (var record in records)
//            //                    //        {
//            //                    //            WKWebsiteDataStore.DefaultDataStore.RemoveData(WKWebsiteDataStore.AllWebsiteDataTypes, new[] { record }, () => { });
//            //                    //        }
//            //                    //    });
//            //                    //}

//            //                    urlObservation?.Dispose();
//            //                    urlObservation = null;

//            //                    onHtmlRendered?.Invoke(pdfData.ToArray());
//            //                });
//            //            }
//            //        }
//            //    });
//            //});
//        }
//    }
//}