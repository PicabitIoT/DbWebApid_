namespace WebApi.Entities;
using System.Text.Json.Serialization;

using System.ComponentModel.DataAnnotations.Schema;
[Table("TableTest")] 
public class Datv
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
 
}