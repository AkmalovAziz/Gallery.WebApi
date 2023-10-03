﻿using System.Net;

namespace Gallery.Application.Exceptions;

public class ExpiredException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Gone;
    public override string TitleMessage { get; protected set; } = string.Empty;
}