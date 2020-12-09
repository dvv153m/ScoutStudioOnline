using System;
using System.Collections.Generic;


namespace ScoutStudioOnline.Infrastructure
{
    /// <summary>
    /// Страница
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Page<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalQuantity { get; set; }

        public Page(int totalQuantity, IEnumerable<T> pageInfo)
        {
            Data = pageInfo;
            TotalQuantity = totalQuantity;
        }
    }
}
