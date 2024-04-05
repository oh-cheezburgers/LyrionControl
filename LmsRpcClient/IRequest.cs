using System.Collections;

namespace LmsMaui.JsonRpcClient
{
    public interface IRequest
    {
        string Method { get; set; }
        ArrayList Params { get; set; }
    }
}