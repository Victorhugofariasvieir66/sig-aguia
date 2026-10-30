namespace SigAguia.Application.Pessoas.AtualizarPessoa
{
    public class AtualizarPessoaCommand
    {
        public string NomeCompleto { get; set; } = string.Empty;
        public DateOnly? DataNascimento { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? EstadoCivil { get; set; }
    }
}