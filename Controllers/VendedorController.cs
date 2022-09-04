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


    /// <summary>
    /// Lista Todas os Vendedores cadastrados
    /// </summary>
    /// <returns>Retorna a lista de vendedores</returns>
    /// <response code="200"> Retorna os itens da lista</response>
   
    [HttpGet]
    public async Task<List<VendedorModels>> Get() => await _vendedorService.GetAsync();

    /// <summary>
    /// Cria um novo vendedor e selecione uma região
    /// </summary>
    /// <remarks>
    /// 
    /// Exemplo: 
    /// 
    ///     POST /Vendedor
    ///     {
    ///      "id":"gerado automaticamente"
    ///      "nome": "João",
    ///      "email": "joao@gmail.com",
    ///      "regiao": "1"
    ///     }
    ///     
    /// Regiões: 
    /// * Vazio - 0,
    /// * Norte - 1,
    /// * Nordeste - 2,
    /// * Sudeste - 3,
    /// * Centro_Oeste - 4,
    /// * Sulv - 5 
    /// </remarks>
    /// <response code="201"> Um novo vendedor foi criado</response>
    /// <response code="400" >O novo vendedor não foi criado</response>
    
    [HttpPost]
    public async Task<IActionResult> CreatePost(VendedorModels date)
    {
        
        await _vendedorService.Create(date);
        return CreatedAtAction(nameof(Get), date);
    }

}
