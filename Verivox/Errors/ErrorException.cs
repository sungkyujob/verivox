namespace Verivox.Errors
{
    using System;
    public class ErrorException : Exception
    {
        public ErrorCode ErrorCode { get; }

        public ErrorException(ErrorCode errorCode, Exception ex)
            : base(ex.Message, ex)
        {
            ErrorCode = errorCode;
        }

        public void SetDetail(string detail)
        {
            ErrorCode.Message = detail;
        }
    }

    public class InvalidRequestException : ErrorException
    {
        public InvalidRequestException(Exception ex) : base(ErrorCode.InvalidRequest, ex) { }
    }

    public class ForbiddenException : ErrorException
    {
        public ForbiddenException(Exception ex) : base(ErrorCode.Forbidden, ex) { }
    }

    public class InternalServerException : ErrorException
    {
        public InternalServerException(Exception ex) : base(ErrorCode.InternalServer, ex) { }
    }
}