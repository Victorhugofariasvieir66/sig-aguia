namespace SigAguia.Application.Membros.CriarMembro
{
    public class CriarMembroCommand
    {
        public Guid PessoaId { get; set; }

        public DateOnly? DataIngresso { get; set; }
    }
}