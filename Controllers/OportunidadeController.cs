using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ApiVendas.Class;
using ApiVendas.Services;
using ApiVendas.Models;
using ApiVendas.Functions;
using static System.Net.Mime.MediaTypeNames;
using System.Text;



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
    public async Task<List<OportunidadeModels>> ObterOportunidade() => await _oportunidadeService.AObterOportunidade();


    /// <summary>
    /// Obtem a lista de oportunidades por id
    /// </summary>
    /// 
    ///  <response code="201"> Um novo vendedor foi criado</response>
    
    [HttpGet("{id:length(24)}")]

    public async Task<ActionResult<OportunidadeModels>> ObterOportunidade(string id)
    {
        Console.WriteLine("Listando Opotunidade");
    ;       var vendedorOportunidade =  await _oportunidadeService.AObterId(id);

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
    public async Task<IActionResult> Criar(OportunidadeModels dados)
    {
        // obtem dados do cnpj de ooutra API
        var dados_cnpj = await _apiService.AObterApi(dados.Cnpj.Number);

        // obtem dados do Vendedor
        var vendedor = await _vendedorService.AObterId(dados.Seller.Id);

      
        var  oportunidades = await _oportunidadeService.AObterOportunidade();
        // Cria um Objeto Json
        JObject jobject = JObject.Parse(dados_cnpj);


        // Cria novo cnpj atraves do Tokens Json
        var cnpj = new CNPJ
        {
            Number = dados.Cnpj.Number,
            Social_reason= jobject.SelectToken("razao_social").ToString(),
            State = jobject.SelectToken("estabelecimento.estado.nome").ToString(),
            Activity = jobject.SelectToken("estabelecimento.atividade_principal.descricao").ToString()
        };

      

        dados.Cnpj = cnpj;
        dados.Seller = (oportunidades.Count() == 0)? vendedor : FuncoesVendedorController.Roleta(vendedor, oportunidades);
      
        var nflag = FuncoesOportunidadeController.VerificaRegiao(dados);

        
        /// Ver melhorias //
        if (nflag)
        {
            await _oportunidadeService.CriarOportunidade(dados);
            
        }
       

        return (!nflag) ? NotFound("Vendedor não pose ser cadastrado") : CreatedAtAction(nameof(ObterOportunidade), dados);

    }

      
        
        
       
}

