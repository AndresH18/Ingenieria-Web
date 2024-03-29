﻿namespace Pokemon.Models.ViewModels;

public class PageInfo
{
    public int TotalItems { get; set; }
    public int ItemsPerPage { get; set; } = -1;
    public int CurrentPage { get; set; }

    public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
}