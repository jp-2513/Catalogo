using Catalogo.Domain.Validation;
using System;

namespace Catalogo.Domain.Entities;

public sealed class Produto 
{
    public Produto(string nome, string descricao, decimal preco, string imagemUrl)
    {
        ValidateDomain(nome, descricao, preco, imagemUrl);
    }

    public int ProdutoId { get; private set; }
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public string ImagemUrl { get; private set; }

    public void Update(string nome, string descricao, decimal preco, string imagemUrl, int categoriaId)
    {
        ValidateDomain(nome, descricao, preco, imagemUrl);
        CategoriaId = categoriaId;
    }

    private void ValidateDomain(string nome, string descricao, decimal preco, string imagemUrl)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Nome inválido. O nome é obrigatório");

        DomainExceptionValidation.When(nome.Length < 3,
            "O nome deve ter no mínimo 3 caracteres");

        DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
            "Descrição inválida. A descrição é obrigatória");

        DomainExceptionValidation.When(descricao.Length < 5,
            "A descrição deve ter no mínimo 5 caracteres");

        DomainExceptionValidation.When(preco < 0, "Valor do preço inválido");

        DomainExceptionValidation.When(imagemUrl?.Length > 250,
            "O nome da imagem não pode exceder 250 caracteres");


        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        ImagemUrl = imagemUrl;

    }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}
