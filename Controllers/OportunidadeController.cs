using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ApiVendas.Services;
using ApiVendas.Models;
using ApiVendas.Functions;


namespace ApiVendas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OportunidadeController : ControllerBase
{
    public readonly OportunidadeService _oportunidadeService;
    public readonly VendedorService _vendedorService;
    public readonly ApiService _apiService;


    public OportunidadeController(OportunidadeService oportunidadeService, ApiService apiService, VendedorService vendedorService)
    {
        _oportunidadeService = oportunidadeService;
        _apiService = apiService;
        _vendedorService = vendedorService;


    } 

    [HttpGet]
    public async Task<List<OportunidadeModels>> GetOportunidade() => await _oportunidadeService.GetAsync();


    [HttpGet("{id:length(24)}")]

    public async Task<ActionResult<OportunidadeModels>> GetOportunidade(string id)
    {
       var vendedorOportunidade =  await _oportunidadeService.GetAsyncId(id);

        if(vendedorOportunidade is null)
        
            NotFound();
        
        return vendedorOportunidade;
    }

    [HttpPost]
    public async Task<IActionResult> Create(OportunidadeModels data)
    {
       
        var date_cnpj = await _apiService.GetApi(data.Cnpj.Numero);
        var vendedor = await _vendedorService.GetId(data.Vendedor.Id);
        
        var  oportunidades = await _oportunidadeService.GetAsync();
        
        JObject jobject = JObject.Parse(date_cnpj);

        var cnpj = new CNPJ
        {
            Numero = data.Cnpj.Numero,
            Razao_social = jobject.SelectToken("razao_social").ToString(),
            Estado = jobject.SelectToken("estabelecimento.estado.nome").ToString(),
            Atividade = jobject.SelectToken("estabelecimento.atividade_principal.descricao").ToString()
        };

        data.Cnpj = cnpj;
        Console.WriteLine(oportunidades.Count());
        Console.WriteLine(vendedor.Id);
        Console.WriteLine(vendedor.Nome);
        data.Vendedor = (oportunidades.Count() == 0)? vendedor : Funcoes.Roleta(vendedor, oportunidades);
        Console.WriteLine("Data Vendedor pos rroleta" + data.Vendedor);
        var nflag =  Funcoes.VerifcaRegiao(data);
        Console.WriteLine("Flag vem" + nflag);
        /// Ver melhorias //
        if (nflag)
        {
            await _oportunidadeService.Create(data);
            
        }
       

        return (!nflag) ? NotFound("Vendedor não pose ser cadastrado") : CreatedAtAction(nameof(GetOportunidade), data);

    }

      
        
        
       
}

