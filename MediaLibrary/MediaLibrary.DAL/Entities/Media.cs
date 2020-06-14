﻿using MediaLibrary.DAL.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaLibrary.DAL.Entities
{
    public class Media
    {
        public Media()
        {
            this.Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Path { get; set; }
        public MediaType Type { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public bool Done { get; set; }
    }
}