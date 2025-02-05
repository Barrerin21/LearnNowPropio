﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LearnNow.Class.Models
{
    public class CourseModel:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } =null!;
        public decimal Price { get; set; }
        public int Duration { get; set; }
       
    }
}
