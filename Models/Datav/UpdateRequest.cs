namespace WebApi.Models.Datvs;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class UpdateRequest
{
    public string Name { get; set; }
    public string Mobile { get; set; }

    [EmailAddress]
    public string Email { get; set; }


    private string replaceEmptyWithNull(string value)
    {
        return string.IsNullOrEmpty(value) ? null : value;
    }
}