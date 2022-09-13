using api.contracts;
using Microsoft.AspNetCore.Mvc;
using api.models;
namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    private List<Values> _valuesList = new List<Values>
    {
        new Values("jack sutton", 1),
        new Values("Jevon", 2),
        new Values("Matt", 3),
        new Values("Big Doinks In Amish", 4),
        new Values("Chelton Evans", 5)
    };

    public ValuesController()
    {
        Console.WriteLine("controller initiated");
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        try
        {
            var returnResult = Ok(_valuesList);        
            return returnResult;
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByID(int id)
    {
        try
        {
            var _valueFromList = _valuesList.Where(item => item.ID == id);
            var _value = Ok(_valueFromList);
            if (_valueFromList is null)
            {
                return NotFound();
            }
            else
            {
                return _value;
            }

        }
        catch
        {
            return NotFound();
        }
        
        
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem(CreateValueRequest reqBody)
    {
        try
        {
            return Ok();
            _valuesList.Add(new Values(reqBody.fullname, reqBody.id));
        }
        catch (Exception e)
        {
            return NotFound();

        }

        
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, UpsertValueRequest reqBody)
    {
        try
        {
            var _valueFromList = _valuesList.Where(item => item.ID == id);
            _valueFromList.First().FullName = reqBody.fullname;
            var _returnValue = Ok(_valueFromList);
            return _returnValue;
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    


}