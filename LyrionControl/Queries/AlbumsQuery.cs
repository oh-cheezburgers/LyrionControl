using System.Collections;
using System.Globalization;

namespace LyrionControl.JsonRpcClient.Queries
{
    public class AlbumsQuery : Request
    {
        public AlbumsQuery(int start, int itemsPerRequest)
        {
            Params = new ArrayList
            {
                string.Empty,
                new ArrayList
                {
                    QueryTypes.Albums,
                    start,
                    itemsPerRequest,
                }
            };
        }
    }
}