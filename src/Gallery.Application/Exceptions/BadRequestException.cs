using System.Net;

namespace Gallery.Application.Exceptions;

public class BadRequestException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;
    public override string TitleMessage { get; protected set; } = string.Empty;
}