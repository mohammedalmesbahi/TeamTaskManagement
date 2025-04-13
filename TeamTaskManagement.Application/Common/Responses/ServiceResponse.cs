﻿
namespace TeamTaskManagement.Application.Common.Responses
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ServiceResponse<T> SuccessResponse(T data, string message = "")
        {
            return new ServiceResponse<T> { Success = true, Data = data, Message = message };
        }

        public static ServiceResponse<T> FailureResponse(string message)
        {
            return new ServiceResponse<T> { Success = false, Message = message };
        }
    }
}
