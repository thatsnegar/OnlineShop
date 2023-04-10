using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Image
{
    public class MainPageBannerViewMode : object
    {
        public MainPageBannerViewMode() : base()
        {
        }

        //**********
        public string? ImageTitle { get; set; }
        //**********

        //**********
        public string? MainPageBannerName { get; set; }
        //**********

        //**********
        public string? FirstSlogan { get; set; }
        //**********

        //**********
        public string? SecondSlogan { get; set; }
        //**********

        //**********
        public string? ThirdSlogan { get; set; }
        //**********
    }
}
