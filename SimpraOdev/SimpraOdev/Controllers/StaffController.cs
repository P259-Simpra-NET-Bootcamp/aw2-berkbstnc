using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimApi.Data.Repository;
using SimpraOdev.Data.Models;

namespace SimpraOdev.Controllers;
[Route("simapi/v1/[controller]")]
[ApiController]
public class StaffController : ControllerBase
    {
    private readonly IStaffRepository repository;
    public StaffController(IStaffRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public List<Staff> GetAll()
    {
        var list = repository.GetAll();
        return list;
    }

    [HttpGet("{id}")]
    public Staff GetById(int id)
    {
        var row = repository.GetById(id);
        return row;
    }

    [HttpPost]
    public void Post([FromBody] Staff request)
    {
        repository.Insert(request);
        repository.Complete();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Staff request)
    {
        request.Id = id;
        repository.Update(request);
        repository.Complete();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        repository.DeleteById(id);
        repository.Complete();
    }

    [HttpGet("{name}")]
    public IActionResult GetStaffByName(string name)
    {
        var staffList = repository.FindByName(name);
        return Ok(staffList);
    }

    [HttpGet("{surname}")]
    public IActionResult GetStaffBySurname(string surname)
    {
        var staffList = repository.FindBySurname(surname);
        return Ok(staffList);
    }
}

