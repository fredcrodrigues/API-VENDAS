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

    /// <summary>
    /// Obtem a lista de oportunidades com vendedores
    /// </summary>
    ///  <response code="200"> Obtem a lista de oportunidades</response>
    
    [HttpGet]
    public async Task<List<OportunidadeModels>> GetOportunidade() => await _oportunidadeService.GetAsync();


    /// <summary>
    /// Obtem a lista de oportunidades por id
    /// </summary>
    /// 
    ///  <response code="201"> Um novo vendedor foi criado</response>
    
    [HttpGet("{id:length(24)}")]

    public async Task<ActionResult<OportunidadeModels>> GetOportunidade(string id)
    {
       var vendedorOportunidade =  await _oportunidadeService.GetAsyncId(id);

        if(vendedorOportunidade is null)
        
            NotFound();
        
        return vendedorOportunidade;
    }

    /// <summary>
    /// Cadastra Oportunidades
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// Exemplo: 
    /// 
    ///      POST /Oportunidade
    ///      {
    ///         "id": "gerado automaticamente"
    ///         "cnpj": {
    ///             "numero": "27865757000102"
    ///             }
    ///         "nome": "procurando vendendor de casas",
    ///         "valor": "100.00",
    ///         "vendedor":{
    ///             "id": "630d2395f451c150a2d6fc1b"
    ///             }
    ///       }
    ///         
    /// * Os outros valores são gerados automaticamente 
    /// * Necessário adicionar o CNPJ para que a API encontre-o
    /// 
    /// </remarks>
    ///     
    /// <response code="201"> Uma nova oportunidade foi criada </response>
    /// <response code="400"> Erro ao criar a oprotunidade</response>

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
        data.Vendedor = (oportunidades.Count() == 0)? vendedor : Function.Roleta(vendedor, oportunidades);
        var nflag = Function.VerifRegiao(data);
       
        /// Ver melhorias //
        if (nflag)
        {
            await _oportunidadeService.Create(data);
            
        }
       

        return (!nflag) ? NotFound("Vendedor não pose ser cadastrado") : CreatedAtAction(nameof(GetOportunidade), data);

    }

      
        
        
       
}

