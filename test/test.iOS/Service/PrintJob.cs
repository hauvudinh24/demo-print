using System;
using System.Drawing.Printing;
using System.Runtime;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using test.iOS;
using test.Services;
using UIKit;
using Vision;
using WebKit;
using Xamarin.Forms;
using test.iOS;
using test.Template;
using test.iOS.Enum;
using test.iOS.Helper.Native;
using CoreAudioKit;
using SpriteKit;
using static CoreFoundation.DispatchSource;

[assembly: Xamarin.Forms.Dependency(typeof(PrintJob))]
namespace test.iOS
{
	public class PrintJob
    {
        public PrintJob()
        {

        }

        public  void SelectPrinter( NSData renderer)
        {
            UIPrintInteractionController printController = UIPrintInteractionController.SharedPrintController;


            var controller = UIPrintInteractionController.SharedPrintController;

            var printInfo = UIPrintInfo.PrintInfo;
            printInfo.JobName = "Print";
            printInfo.OutputType = UIPrintInfoOutputType.General;
            var paperSizeInPoints = new CGSize(595, 842); // A4 size in points

            controller.PrintInfo = printInfo;
            controller.PrintPageRenderer = new GuestPrintPageRenderer();
            controller.ShowsPaperSelectionForLoadedPapers = true;
            controller.ShowsPageRange = true;

            try
            {
                var printerPicker = UIPrinterPickerController.FromPrinter(null);

                printerPicker.Present(true, (printerPickerController, userDidSelect, error) =>//PresentFromBarButtonItem(printButtonItem1, false, (printerPickerController, userDidSelect, error) =>//Present(false, (printerPickerController, userDidSelect, error) =>
                {
                    if (userDidSelect)
                    {
                        var selectedPrinter = printerPicker.SelectedPrinter;
                        if (selectedPrinter != null)
                        {
                            NSUserDefaults.StandardUserDefaults.SetString( selectedPrinter.Url.AbsoluteString, "URL_PRINTER");
                            NSUserDefaults.StandardUserDefaults.Synchronize();
                            Printer(selectedPrinter.Url.AbsoluteString, renderer);
                        }
                    }
                });
            }
            catch (Exception ex)
            {

            }
        }

        public void Printer(String printerUrl, NSData data)
        {
            var uiPrinter = UIPrinter.FromUrl(new NSUrl(printerUrl));

            var controller = UIPrintInteractionController.SharedPrintController;
            controller.PrintingItem = data;


            var printInfo = UIPrintInfo.PrintInfo;
            printInfo.JobName = "Print";
            printInfo.OutputType = UIPrintInfoOutputType.General;
            printInfo.Orientation = UIPrintInfoOrientation.Landscape;


            controller.PrintInfo = printInfo;
            //controller.PrintPageRenderer = renderer;
            controller.ShowsPaperSelectionForLoadedPapers = true;

            //controller.PrintToPrinter(uiPrinter, (printInteractionController, completed, error) =>
            //        {
            //            printInfo?.Dispose();
            //            uiPrinter?.Dispose();
            //        });

            controller.Present(true, (printInteractionController, completed, error) =>
                    {
                        printInfo?.Dispose();
                        uiPrinter?.Dispose();
                    });
        }

        void PrintingCompleted(UIPrintInteractionController controller, bool completed, NSError error)
        {

        }
    }
}

