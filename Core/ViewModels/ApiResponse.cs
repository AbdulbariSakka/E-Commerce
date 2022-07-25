using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class ApiResponse <T>
    {
        public ApiResponse(Status status, string resultMessage, int errorCode, T data)
        {
            Status = status;
            ResultMessage = resultMessage;
            ErrorCode = errorCode;
            Data = data;
        }

        public Status Status { get; set; }

        public string ResultMessage { get; set; }

        public int ErrorCode { get; set; }

        public T Data { get; set; } 
    }
}
