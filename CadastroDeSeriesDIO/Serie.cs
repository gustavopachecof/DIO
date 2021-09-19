using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroDeSeriesDIO
{
    public class Serie : EntidadeBase { 
        private Genero genero { get; set; }
        private string titulo { get; set; }
        private string descricao { get; set; }
        private int ano { get; set; }
        private bool excluido { get; set;}

        public Serie(int id, Genero genero, string titulo, string descricao, int ano) {
            this.Id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.genero + Environment.NewLine;
            retorno += "Título: " + this.titulo + Environment.NewLine;
            retorno += "Descrição: " + this.descricao + Environment.NewLine;
            retorno += "Ano de inicio: " + this.ano + Environment.NewLine;
            return retorno;

        }

        public string RetornaTitulo() {
            return this.titulo;

        }
        public int RetornaId() {
            return this.Id;
        }
        
        public bool RetornaExcluido()
        {
            return this.excluido;

        }
        public void Excluir()
        {

            this.excluido = true;
        }


    }

}
