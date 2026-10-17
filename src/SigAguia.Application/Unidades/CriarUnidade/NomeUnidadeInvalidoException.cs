namespace SigAguia.Application.Unidades.CriarUnidade
{
    public class NomeUnidadeInvalidoException : Exception
    {
        public NomeUnidadeInvalidoException()
            : base("O nome da unidade é obrigatório.")
        {
        }
    }
}