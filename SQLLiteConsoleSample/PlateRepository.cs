using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLiteConsoleSample
{
    class PlateRepository
    {
        public float Length { get; set; }
        public float Width { get; set; }
        public float Thickness { get; set; }

        public float TrimTop { get; set; }
        public float TrimBottom { get; set; }
        public float TrimLeft { get; set; }
        public float TrimRight { get; set; }
        public float PriceM2 { get; set; }

        public string Grain { get; set; }
        public string Material { get; set; }
        public string Label { get => (Material == "" ? "Unbekannt" : Material) + " | " + Length + "x" + Width + "x" + Thickness + " | " + Comment + (Grain != "keine" ? (" | " + Grain) : ""); }
        public string Dimensions { get => Length + "x" + Width + "x" + Thickness; }
        public string Comment { get; set; }
        public string Supplier { get; set; }
        public string ImageSrc { get; set; }

        public int Priority { get; set; }

        public object Clone() => MemberwiseClone();
    }
}
