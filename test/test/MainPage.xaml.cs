using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using UIKit;
using Foundation;
using CarPlay;
using test.Services;
using test.Template;

namespace test
{
    public partial class MainPage : ContentPage
    {
        private UIPrintInteractionController _printInteractionController;
        private PDFToHtml PDFToHtml { get; set; }


        public MainPage()
        {
            InitializeComponent();


        }
        int count = 0;

        private UIPrintPageRenderer GetUIPrintPageRenderer()
        {
            return new UIPrintPageRenderer();
        }

        void Button_Clicked(object sender, System.EventArgs e)
        {
            onClick();

            return;
        }

        protected virtual async void onClick()
        {
            //var printer = DependencyService.Get<IPrinter>();

            //if (printer != null)
            //{
            //    printer.SelectPrinter();
            //}
            var template = new htm_printer() { };
            var page = template.GenerateString();
            PDFToHtml = new PDFToHtml();
            this.BindingContext = PDFToHtml;
            PDFToHtml.HTMLString = page;
            PDFToHtml.GeneratePDF();

        }
    }
}

