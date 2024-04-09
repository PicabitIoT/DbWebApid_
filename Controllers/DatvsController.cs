namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Datvs;
using WebApi.Services;

[ApiController]
[Route("api/db/[controller]")]
public class DatvsController : ControllerBase
{
    private IDatvService _datvService;
    private IMapper _mapper;

    public DatvsController(
        IDatvService datvService,
        IMapper mapper)
    {
        _datvService = datvService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var datvs = _datvService.GetAll();
        return Ok(datvs);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var datv = _datvService.GetById(id);
        return Ok(datv);
    }

    [HttpPost]
    public IActionResult Create(CreateRequest model)
    {
            _datvService.Create(model);
            return Ok(new { message = "Datv created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _datvService.Update(id, model);
        return Ok(new { message = "Datv updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _datvService.Delete(id);
        return Ok(new { message = "Datv deleted" });
    }
}