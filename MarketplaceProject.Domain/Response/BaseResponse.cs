﻿using MarketplaceProject.Domain.Enum;

namespace MarketplaceProject.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }

        public StatusCode statusCode { get; set; }

        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        T Data { get;}
    }
}
