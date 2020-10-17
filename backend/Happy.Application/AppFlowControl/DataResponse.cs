using System.Collections.Generic;

namespace Happy.Application.AppFlowControl
{
    public sealed class DataResponse<TEntity> : Response
    {
        public List<TEntity> Data { get; set; } = new List<TEntity>();

        public DataResponse()
        {
        }

        public DataResponse(List<TEntity> data)
        {
            Data = data;
        }
    }
}
