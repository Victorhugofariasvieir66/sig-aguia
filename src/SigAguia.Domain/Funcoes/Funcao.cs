namespace SigAguia.Domain.Funcoes
{
    public class Funcao
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; } = string.Empty;

        public string? Descricao { get; set; }

        public bool Ativa { get; set; } = true;

        public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;
    }
}