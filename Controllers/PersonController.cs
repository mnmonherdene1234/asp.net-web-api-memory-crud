using Microsoft.AspNetCore.Mvc;
using Student.Models;

namespace Student.Controllers;

[ApiController]
[Route("person")]
public class PersonConroller : ControllerBase
{
    class QueryParameters{
        public int x {get; set;}
        public int y {get; set;}
    }
    
    [HttpGet]
    public int GetPersons([FromQuery] QueryParameters query)
    {
        return query.x + query.y;
    }

    [HttpGet("{x}/{y}")]
    public int GetId(int x, int y){
        return x + y;
    }
}