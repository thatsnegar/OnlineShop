﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Image
{
    public class BreadCrumbsViewModel : object
    {
        public BreadCrumbsViewModel() : base()
        {
        }

        //**********
        public string? ImageTitle { get; set; }
        //**********

        //**********
        public string? BreadCrumbsImageName { get; set; }
        //**********
    }
}
