namespace WebApi.Models.Datvs;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class CreateRequest
{

    [Required]
    public string Name { get; set; }

    [Required]
    public string Mobile { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

}