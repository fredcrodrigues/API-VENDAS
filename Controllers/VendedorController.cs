using Microsoft.AspNetCore.Mvc;
using ApiVendas.Services;
using ApiVendas.Models;

namespace ApiVendas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendedorController : ControllerBase
{
    private readonly VendedorService _vendedorService;


    public VendedorController(VendedorService vendedorService) => _vendedorService = vendedorService;
   
    [HttpGet]
    public async Task<List<VendedorModels>> Get() => await _vendedorService.GetAsync();

    [HttpPost]
    public async Task<IActionResult> CreatePost(VendedorModels date)
    {
       
        await _vendedorService.Create(date);
        return CreatedAtAction(nameof(Get), date);
    }

}
