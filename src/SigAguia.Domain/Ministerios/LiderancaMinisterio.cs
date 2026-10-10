namespace SigAguia.Domain.Ministerios
{
    public class LiderancaMinisterio
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid MinisterioId { get; set; }

        public Guid MembroId { get; set; }

        public string TipoLideranca { get; set; } = string.Empty;

        public DateOnly DataInicio { get; set; }

        public DateOnly? DataFim { get; set; }

        public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;
    }
}