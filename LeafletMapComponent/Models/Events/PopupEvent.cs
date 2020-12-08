using System;
using System.Collections.Generic;
using System.Text;

namespace LeafletMapComponent.Models.Events
{
    public class PopupEvent : Event
    {
        public Popup Popup { get; set; }
    }
}
