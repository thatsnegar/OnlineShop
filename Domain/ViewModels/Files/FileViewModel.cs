using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Files
{
    public class FileViewModel : Object
    {
        public FileViewModel() : base()
        {
        }

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.File),
            Name = nameof(Resources.Tables.File.Name))]
        public string Name { get; set; }
        //**********

        //**********
        public string Path { get; set; }
        //**********

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.File),
           Name = nameof(Resources.Tables.File.Alt))]
        public string Alt { get; set; }
        //**********

        //**********
        public long Size { get; set; }
        //**********
    }

}
