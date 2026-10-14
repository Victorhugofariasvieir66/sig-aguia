namespace SigAguia.Application.Unidades.CriarUnidade
{
    public class MatrizJaExisteException : Exception
    {
        public MatrizJaExisteException()
            : base("Já existe uma unidade definida como Matriz.")
        {
        }
    }
}