using System.Collections;

namespace LyrionControl.JsonRpcClient
{
    public interface IRequest
    {
        string Method { get; set; }
        ArrayList Params { get; set; }
    }
}