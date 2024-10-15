﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Stok_Takip_App.HavaDurumu;

namespace Stok_Takip_App
{
    internal class Gunluk
    {
        public class temp
        {
            public double day {  get; set; }
            public double min { get; set; }
            public double max { get; set; }
        }
        public class weather
        {
            public string main { get; set; }
            public string description {  get; set; }
            public string icon {  get; set; }
        }
        public class daily
        {
            public long dt { get; set; }
            public temp temp { get; set; }
            public List<weather>  weather { get; set; }
        }
        public class root
        {
            public List<daily> daily { get; set; }
        }

    }
}
