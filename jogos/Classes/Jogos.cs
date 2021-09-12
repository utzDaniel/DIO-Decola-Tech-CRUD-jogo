using System;
namespace jogos
{
    public class Jogos : EntidadeBase
    {

		private Categorias Categorias { get; set; }
		private string Nome { get; set; }
		private string Descricao { get; set; }
        private Classificacao Classificacao { get; set; }
		private float Preco { get; set; }
        private bool Excluido {get; set;}

		public Jogos(int id, Categorias Categorias, string nome, Classificacao Classificacao, string descricao, float preco)
		{
			this.Id = id;
			this.Categorias = Categorias;
			this.Nome = nome;
            this.Classificacao = Classificacao;
			this.Descricao = descricao;
            this.Preco = preco;
            this.Excluido = false;
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Categorias: " + this.Categorias + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Classificação: " + this.Classificacao + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "R$ " + this.Preco + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string getNome()
		{
			return this.Nome;
		}

		public int getId()
		{
			return this.Id;
		}
		public float getPreco()
		{
			return this.Preco;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}