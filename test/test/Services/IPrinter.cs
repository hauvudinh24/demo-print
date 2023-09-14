using System.Threading.Tasks;
namespace test.Services
{
	public interface IPrinter
	{
        void SelectPrinter();
        void Printer();
        void ConvertHTMLtoPDF(PDFToHtml _PDFToHtml);
    }
}

