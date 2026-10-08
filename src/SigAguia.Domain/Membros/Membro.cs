
namespace SigAguia.Domain.Membros
{
    public class Membro
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid PessoaId { get; set; }

        public DateOnly? DataIngresso { get; set; }

        public string Situacao { get; set; } = "Ativo";

        public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;
    }
}