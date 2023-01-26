using System.ComponentModel.DataAnnotations;

namespace CategoriasMVC.Models;

public class ProdutoViewModel
{
    public int ProdutoId { get; set; }
    [Required]
    public string? Nome { get; set; }
    [Required]
    public string? Descricao { get; set; }  
    [Required]
    public decimal Preco { get; set; }
    [Required]
    [Display(Name ="Caminho da Imagem")]
    public string? ImagemUrl { get; set; }
    [Display(Name ="Categoria")]
    public int CategoriaId { get; set; }
}