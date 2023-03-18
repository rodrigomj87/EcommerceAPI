using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Api.Controllers;
using Ecommerce.Api.DTOs;
using Ecommerce.Api.Extensions;
using Ecommerce.Api.ViewModels;
using Ecommerce.Business.ENUMs;
using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/produtos")]
    public class ProdutosController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public ProdutosController(INotificador notificador, 
                                  IProdutoRepository produtoRepository, 
                                  IProdutoService produtoService, 
                                  IMapper mapper,
                                  IUser user,
                                  IImageService imageService) : base(notificador, user)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores());
        }

        [AllowAnonymous]
        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> ObterTodosPaginado(int pageNumber, int pageSize, EProdutoOrder orderQuery, string searchTerm)
        {
            var produtos = await _produtoRepository.ObterProdutosFornecedores(pageNumber, pageSize, orderQuery, searchTerm);
            var produtosViewModel = _mapper.Map<IEnumerable<ProdutoViewModel>>(produtos);

            var totalItens = await _produtoRepository.ObterTotalItens(searchTerm);
            var totalPages = (int)Math.Ceiling((double)totalItens / pageSize);

            var summary = new
            {
                TotalItens = totalItens,
                TotalPages = totalPages,
                CurrentPage = pageNumber
            };

            return Ok(new { Produtos = produtosViewModel, Summary = summary });
        }
        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null) return NotFound();

            return produtoViewModel;
        }

        [ClaimsAuthorize("Produto", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var imagemNome = Guid.NewGuid() + "_" + produtoViewModel.Imagem;
            if (!_imageService.UploadImage(produtoViewModel.ImagemUpload, imagemNome))
            {
                return CustomResponse(produtoViewModel);
            }

            produtoViewModel.Imagem = imagemNome;
            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }

        [ClaimsAuthorize("Produto", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var produtoAtualizacao = await ObterProduto(id);
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (produtoViewModel.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + produtoViewModel.Imagem;
                if (!_imageService.UploadImage(produtoViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }

                produtoAtualizacao.Imagem = imagemNome;
            }
            else
            {
                produtoViewModel.Imagem = produtoAtualizacao.Imagem;
            }

            produtoAtualizacao.FornecedorId = produtoViewModel.FornecedorId;
            produtoAtualizacao.Nome = produtoViewModel.Nome;
            produtoAtualizacao.Descricao = produtoViewModel.Descricao;
            produtoAtualizacao.Valor = produtoViewModel.Valor;
            produtoAtualizacao.Ativo = produtoViewModel.Ativo;

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));

            return CustomResponse(produtoViewModel);
        }

        [ClaimsAuthorize("Produto", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null) return NotFound();

            await _produtoService.Remover(id);

            return CustomResponse(produto);
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));
        }

        #region refatorado na camada Business
        //private bool UploadArquivo(string arquivo, string imgNome)
        //{
        //    if (string.IsNullOrEmpty(arquivo))
        //    {
        //        NotificarErro("Forneça uma imagem para este produto!");
        //        return false;
        //    }

        //    var imageDataByteArray = Convert.FromBase64String(arquivo);

        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgNome);

        //    if (System.IO.File.Exists(filePath))
        //    {
        //        NotificarErro("Já existe um arquivo com este nome!");
        //        return false;
        //    }

        //    System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

        //    return true;
        //}
        #endregion
    }
}