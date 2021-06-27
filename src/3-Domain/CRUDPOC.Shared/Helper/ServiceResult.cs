using System;
using System.Text.Json.Serialization;

namespace CRUDPOC.Shared.Helper
{
    [Serializable]
    public class ServiceResult<T> : ServiceResult
    {
        [JsonPropertyNameAttribute("Data")]
        public T Data { get; set; }

        public ServiceResult(T data)
        {
            Data = data;
        }

        public ServiceResult(T data, ServiceError error) : base(error)
        {
            Data = data;
        }

        public ServiceResult(ServiceError error) : base(error)
        {
        }
        public ServiceResult() 
        {
        }
    }

    public class ServiceResult
    {
        [JsonPropertyNameAttribute("Succeeded")]
        public bool Succeeded => this.Error == null;

        [JsonPropertyNameAttribute("Error")]
        public ServiceError Error { get; set; }

        public ServiceResult(ServiceError error)
        {
            if (error == null)
            {
                error = ServiceError.DefaultError;
            }

            Error = error;
        }

        public ServiceResult()
        {
        }

        #region Helper Methods

        public static ServiceResult Failed(ServiceError error)
        {
            return new ServiceResult(error);
        }

        public static ServiceResult<T> Failed<T>(ServiceError error)
        {
            return new ServiceResult<T>(error);
        }

        public static ServiceResult<T> Failed<T>(T data, ServiceError error)
        {
            return new ServiceResult<T>(data, error);
        }

        public static ServiceResult<T> Success<T>(T data)
        {
            return new ServiceResult<T>(data);
        }

        #endregion Helper Methods
    }
}