using LeafletMapComponent;
using LeafletMapComponent.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ScoutOnline.Core.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutStudioOnline.Components
{
    public class MapModel : ComponentBase
    {
        [Inject]
        private IJSRuntime jsRuntime { get; set; }

        [Inject]
        private MapsService MapService { get; set; }

        private Map MapControl;

        private MapType _currentMapType = MapType.Openstreet;

        private LatLng _mapCenterPosition = new LatLng(59.948080f, 30.326621f);

        private TileLayer CurrentLayer;        

        protected override void OnInitialized()
        {
            MapControl = new Map(jsRuntime)
            {
                Center = _mapCenterPosition,
                Zoom = 13f
            };

            ScoutOnline.Core.Map.MapInfo map = MapService.Maps[_currentMapType];
        }

        private void InitCurrentLayer(MapInfo map)
        {
            CurrentLayer = new TileLayer
            {
                UrlTemplate = map.BaseUrl,
                Subdomains = map.Subdomains,
                MaximumZoom = map.MaxZoom,
                Attribution = map.Attribution,
                Projection = map.Projection
            };
        }
    }
}
