﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Serializable]
    public class City
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
    }
}