﻿namespace Application.Models.Identity;

public class AuthResponse
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? TokenValidDate { get; set; }
    public string ReturnUrl { get; set; }
}