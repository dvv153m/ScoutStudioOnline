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

        [Parameter]
        public Map MapControl { get; set; }

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

            MapInfo map = MapService.Maps[_currentMapType];

            InitCurrentLayer(map);

            MapControl.OnInitialized += () =>
            {
                MapControl.AddLayer(CurrentLayer);
            };
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
