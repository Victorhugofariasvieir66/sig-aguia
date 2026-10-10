namespace SigAguia.Domain.Ministerios
{
    public class Ministerio
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; } = string.Empty;

        public string? Descricao { get; set; }

        public bool Ativo { get; set; } = true;

        public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;
    }
}