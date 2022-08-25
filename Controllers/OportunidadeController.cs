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
        bool flag;
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
        data.Vendedor = (oportunidades.Count() == 0)? vendedor : Funcoes.Roleta(vendedor, oportunidades);
       
        /// Ver melhorias //
        if (data.Vendedor != null)
        {
            await _oportunidadeService.Create(data);
            flag = true;
        }
        else
        {
            flag = false;
        }


        return (flag)? CreatedAtAction(nameof(GetOportunidade), data) : NotFound("Vendedor não pose ser cadastrado");

    }

      
        
        
       
}

