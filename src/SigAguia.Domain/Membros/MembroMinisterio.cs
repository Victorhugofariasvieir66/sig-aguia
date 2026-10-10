namespace SigAguia.Domain.Membros
{
    public class MembroMinisterio
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid MembroId { get; set; }

        public Guid MinisterioId { get; set; }

        public DateOnly DataInicio { get; set; }

        public DateOnly? DataFim { get; set; }

        public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;
    }
}