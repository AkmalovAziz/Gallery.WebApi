﻿using Gallery.DataAccess.ViewModels;
using Gallery.Domain.Entities.Images;

namespace Gallery.DataAccess.Interfaces.Images;

public interface IImageRepository : IRepository<Image, ImageViewModel>
{
}