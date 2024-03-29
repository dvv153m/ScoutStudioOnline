﻿using LeafletMapComponent.Models;
using System.Collections.Generic;

namespace ScoutStudioOnline.Core.Map
{
    public class MapsService
    {
        private Dictionary<MapType, MapInfo> _maps;
        public Dictionary<MapType, MapInfo> Maps 
        {
            get { return _maps; }
        }

        public MapsService()
        {
            _maps = new Dictionary<MapType, MapInfo>();

            _maps.Add(MapType.Openstreet, new MapInfo
            {
                Title = "OpenStreetMap",
                Type = MapType.Openstreet,
                BaseUrl = "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
                Subdomains = new string[] {"a", "b", "c"},
                MaxZoom = 19,
                Attribution = @"&copy; <a href=""https://www.openstreetmap.org/copyright"">OpenStreetMap</a>, Tiles courtesy of <a href=""https://hot.openstreetmap.org/"" target=""_blank"">Humanitarian OpenStreetMap Team</a>",
                Projection = MapProjection.EPSG3857
            });

            _maps.Add(MapType.Yandex, new MapInfo
            {
                Title = "Yandex",
                Type = MapType.Yandex,                
                BaseUrl = "https://core-renderer-tiles.maps.yandex.net/tiles?l=map&v=21.07.05-0-b210701140430&x={x}&y={y}&z={z}&lang=ru_RU",
                Subdomains = new string[] { "01", "02", "03", "04" },
                MaxZoom = 19,
                Attribution = @"&copy; <a href=""http://yandex.ru"" target=""_blank"">Яндекс</a>",
                Projection = MapProjection.EPSG3395
            });

            _maps.Add(MapType.YandexSatellite, new MapInfo
            {
                Title = "Yandex Спутник",
                Type = MapType.YandexSatellite,
                //BaseUrl = "https://sat{s}.maps.yandex.net/tiles?l=sat&v=3.307.0&x={x}&y={y}&z={z}",
                BaseUrl = "https://core-sat.maps.yandex.net/tiles?l=sat&v=3.564.0&x={x}&y={y}&z={z}&scale=1&lang=ru_RU",
                Subdomains = new string[] { "01", "02", "03", "04" },
                MaxZoom = 17,
                Attribution = @"&copy; <a href=""http://yandex.ru"" target=""_blank"">Яндекс</a>",
                Projection = MapProjection.EPSG3395
            });

            //todo add yandex hybrid
            //https://core-renderer-tiles.maps.yandex.net/tiles?l=skl&v=21.07.05-0-b210701140430&x={0}&y={1}&z={2}&lang={3}

            _maps.Add(MapType.GoogleStreet, new MapInfo
            {
                Title = "Google",
                Type = MapType.GoogleStreet,
                BaseUrl = "https://{s}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}",
                Subdomains = new string[] { "mt0", "mt1", "mt2", "mt3" },
                MaxZoom = 20,                
                Attribution = @"&copy; <a href=""http://google.ru"" target=""_blank"">Google</a>",
                Projection = MapProjection.EPSG3857
            });

            _maps.Add(MapType.GoogleHybrid, new MapInfo
            {
                Title = "Google Гибрид",
                Type = MapType.GoogleHybrid,
                BaseUrl = "https://{s}.google.com/vt/lyrs=s,h&x={x}&y={y}&z={z}",
                Subdomains = new string[] { "mt0", "mt1", "mt2", "mt3" },
                MaxZoom = 20,
                Attribution = @"&copy; <a href=""http://google.ru"" target=""_blank"">Google</a>",
                Projection = MapProjection.EPSG3857
            });

            _maps.Add(MapType.GoogleSatellite, new MapInfo
            {
                Title = "Google Спутник",
                Type = MapType.GoogleSatellite,
                BaseUrl = "https://{s}.google.com/vt/lyrs=s&x={x}&y={y}&z={z}",
                Subdomains = new string[] { "mt0", "mt1", "mt2", "mt3" },
                MaxZoom = 20,
                Attribution = @"&copy; <a href=""http://google.ru"" target=""_blank"">Google</a>",
                Projection = MapProjection.EPSG3857
            });

            _maps.Add(MapType.Wikimapia, new MapInfo
            {
                Title = "Wikimapia",
                Type = MapType.Wikimapia,
                BaseUrl = "http://{s}{s4}.wikimapia.org/?x={x}&y={y}&zoom={z}",
                Subdomains = new string[] { "i" },
                MaxZoom = 20,
                Attribution = @"&copy; <a href=""http://wikimapia.org"" target=""_blank"">Wikimapia.org</a>",
                Projection = MapProjection.EPSG3857
            });
        }       
    }
}
