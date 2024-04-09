namespace WebApi.Services;

using WebApi.Entities;
using WebApi.Models.Datvs;

public interface IDatvService
{
    IEnumerable<Datv> GetAll();
    Datv GetById(int id);
    void Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}

