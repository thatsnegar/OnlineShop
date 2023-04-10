using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Image
{
    public class ImageNavbarViewModel : object
    {
        public ImageNavbarViewModel(): base()
        {
        }

        //**********
        public string? ImageTitle { get; set; }
        //**********

        //**********
        public string? NavbarImageName { get; set; }
        //**********
    }
}
