namespace AnimesdoTioFe
{
    public class Animes : BaseModels
    {
        private OpcoesDeAnime Opcoes {get; set;}
        private string Titulo {get; set;}
        private string Descriçao {get; set;}
        private int Ano {get; set;}
        private bool Excluido {get; set;}

        public Animes (int id, OpcoesDeAnime Opcoes, string titulo, string descricao, int ano)
        {
            this.Opcoes = Opcoes;
            this.Id = id;
            this.Titulo = titulo;
            this.Descriçao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "Episodio:" + this.Opcoes + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descriçao + Environment.NewLine;
            retorno += "Ano de Lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

         public bool retornaExcluido()
		{
			return this.Excluido;
		}

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}