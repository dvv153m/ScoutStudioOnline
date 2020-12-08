using System;
using System.Collections.Generic;
using System.Text;

namespace LeafletMapComponent.Models
{
    public class Group : InteractiveLayer
    {
        public Polygon[] Polygons { get; set; }

        public Marker[] Markers { get; set; }

    }
}
