namespace SigAguia.Domain.Unidades
{
    public class Unidade
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; } = string.Empty;

        public bool EhMatriz { get; set; }

        public bool Ativa { get; set; } = true;
        public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;
    }
}