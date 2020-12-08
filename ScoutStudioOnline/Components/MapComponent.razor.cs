using LeafletMapComponent;
using LeafletMapComponent.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ScoutStudioOnline.Core.Map;


namespace ScoutStudioOnline.Components
{
    public class MapModel : ComponentBase
    {
        [Inject]
        private IJSRuntime _jsRuntime { get; set; }

        [Inject]        
        protected MapsService MapService { get; set; }
        
        protected Map MapControl { get; set; }

        [Parameter]
        public bool IsShowSelectMap { get; set; } = true;
        
        private MapType _currentMapType;
        [Parameter]
        public MapType CurrentMapType
        {
            get { return _currentMapType; }
            set
            {                
                _currentMapType = value;
                if (_isInitMap)
                {                    
                    OnMapChange(_currentMapType);
                }
            }
        }

        private LatLng _mapCenterPosition = new LatLng(59.948080f, 30.326621f);

        private TileLayer _currentLayer;

        private bool _isInitMap = false;

        protected override void OnInitialized()
        {
            MapControl = new Map(_jsRuntime)
            {
                Center = _mapCenterPosition,
                Zoom = 13f
            };

            MapInfo map = MapService.Maps[CurrentMapType];

            InitCurrentLayer(map);

            MapControl.OnInitialized += () =>
            {
                MapControl.AddLayer(_currentLayer);
                _isInitMap = true;
            };
        }

        private void OnMapChange(MapType mapType)
        {
            var newMap = MapService.Maps[mapType];
            MapControl.RemoveLayer(_currentLayer);

            InitCurrentLayer(newMap);

            MapControl.AddLayer(_currentLayer);
        }

        private void InitCurrentLayer(MapInfo map)
        {
            _currentLayer = new TileLayer
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
