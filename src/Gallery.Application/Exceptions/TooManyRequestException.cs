﻿using System.Net;

namespace Gallery.Application.Exceptions;

public class TooManyRequestException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.TooManyRequests;
    public override string TitleMessage { get; protected set; } = string.Empty;
}