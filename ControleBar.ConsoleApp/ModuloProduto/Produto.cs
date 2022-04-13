using ControleBar.ConsoleApp.Compartilhado;
using System;

namespace ControleBar.ConsoleApp.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public Produto(string tipo, string nome, decimal quantidade, decimal preco)
        {
            Tipo = tipo;
            Nome = nome;
            Quantidade = quantidade;
            PrecoUnitario = preco;
        }

        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                   "Tipo do produto: " + Tipo + Environment.NewLine +
                   "Nome do produto: " + Nome + Environment.NewLine +
                   "Quantidade: " + Quantidade + Environment.NewLine +
                   "Preço unitário: R$" + PrecoUnitario + Environment.NewLine;
        }
    }
}