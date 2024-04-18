using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TesteApi.Models;

public partial class Pessoa
{
    public int Id { get; set; }
    
    public string Nome { get; set; } = null!;

    public string Nome_Complemento { get; set; } = null!;

    public string? Rg { get; set; }

    public string? Cpf { get; set; }

    public string? Email { get; set; }

    public string? Telefone { get; set; }

    public int? Id_Anexo_Sys { get; set; }

    public DateTime? Data_Alteracao { get; set; }

    public DateTime? Data_Cadastro { get; set; }

    


}
