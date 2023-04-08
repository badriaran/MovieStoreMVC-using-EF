﻿using System.ComponentModel.DataAnnotations;

namespace MovieStoreMVC.Models.DTO;

public class RegistrationModel
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string Username { get; set; }
    [Required]
    [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])")]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string PasswordConfirm { get; set; }
    public string Role { get; set; }
}
