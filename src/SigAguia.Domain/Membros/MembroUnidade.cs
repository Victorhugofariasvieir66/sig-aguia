namespace SigAguia.Domain.Membros
{
    public class MembroUnidade
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid MembroId { get; set; }

        public Guid UnidadeId { get; set; }

        public string TipoVinculo { get; set; } = "Principal";

        public DateOnly DataInicio { get; set; }

        public DateOnly? DataFim { get; set; }

        public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;
    }
}