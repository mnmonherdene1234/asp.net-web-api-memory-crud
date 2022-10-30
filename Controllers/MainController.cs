using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkTest.Controllers;

[Route("")]
public class MainController{
    [HttpGet]
    public string Greeting(){
        return "Hello World";
    }
}