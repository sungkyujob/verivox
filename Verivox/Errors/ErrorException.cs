namespace Verivox.Errors
{
    using System;

    /// <summary>
    /// Defines the <see cref="ErrorException" />
    /// </summary>
    public class ErrorException : Exception
    {
        /// <summary>
        /// Gets the ErrorCode
        /// </summary>
        public ErrorCode ErrorCode { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorException"/> class.
        /// </summary>
        /// <param name="errorCode">The errorCode<see cref="ErrorCode"/></param>
        /// <param name="ex">The ex<see cref="Exception"/></param>
        public ErrorException(ErrorCode errorCode, Exception ex)
            : base(ex.Message, ex)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// The SetDetail
        /// </summary>
        /// <param name="detail">The detail<see cref="string"/></param>
        public void SetDetail(string detail)
        {
            ErrorCode.Message = detail;
        }
    }

    /// <summary>
    /// Defines the <see cref="InvalidRequestException" />
    /// </summary>
    public class InvalidRequestException : ErrorException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRequestException"/> class.
        /// </summary>
        /// <param name="ex">The ex<see cref="Exception"/></param>
        public InvalidRequestException(Exception ex) : base(ErrorCode.InvalidRequest, ex)
        {
        }
    }

    /// <summary>
    /// Defines the <see cref="ForbiddenException" />
    /// </summary>
    public class ForbiddenException : ErrorException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="ex">The ex<see cref="Exception"/></param>
        public ForbiddenException(Exception ex) : base(ErrorCode.Forbidden, ex)
        {
        }
    }

    /// <summary>
    /// Defines the <see cref="InternalServerException" />
    /// </summary>
    public class InternalServerException : ErrorException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerException"/> class.
        /// </summary>
        /// <param name="ex">The ex<see cref="Exception"/></param>
        public InternalServerException(Exception ex) : base(ErrorCode.InternalServer, ex)
        {
        }
    }
}
