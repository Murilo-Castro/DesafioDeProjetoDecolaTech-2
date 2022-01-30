namespace AnimesdoTioFe
{
    public class AnimesRepository : IRepository<Animes>
    {
        private List<Animes> ListaAnimes = new List<Animes>();
        public void Atualiza(int id, Animes objeto)
        {
            ListaAnimes[id] = objeto;
        }

        public void Exclui(int id)
        {
            ListaAnimes[id].Excluir();
        }

        public void Insere(Animes objeto)
        {
            ListaAnimes.Add(objeto);
        }

        public List<Animes> Lista()
        {
            return ListaAnimes;
        }

        public int ProximoId()
        {
            return ListaAnimes.Count;
        }

        public Animes RetornaPorId(int id)
        {
            return ListaAnimes[id];
        }
    }
}