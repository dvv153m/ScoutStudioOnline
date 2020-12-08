using System;
using System.Collections.Generic;
using System.Text;

namespace LeafletMapComponent.Models.Events
{
    public class DragEndEvent : Event
    {
        public float Distance { get; set; }
    }
}
