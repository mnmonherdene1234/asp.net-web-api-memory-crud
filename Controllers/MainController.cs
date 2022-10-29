using Microsoft.AspNetCore.Mvc;

namespace Student.Controllers;

[Route("")]
public class MainController{
    [HttpGet]
    public string Greeting(){
        return "Hello World";
    }
}