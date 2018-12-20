using System.Collections.Generic;

namespace Bullhorn.Net.Models.Response
{
    public interface IListWrapper<T>
    {
        int Count { get; set; }
        List<T> Data { get; set; }
        int Start { get; set; }
        int Total { get; set; }
    }
}