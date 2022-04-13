using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloProduto;
using System;

namespace ControleBar.ConsoleApp.ModuloPedido
{
    public class Pedido : EntidadeBase
    {
        public string Tipo { get; }
        public string Nome { get; set; }
        public decimal Quantidade { get; set; }

        public Pedido(string tipo)
        {
            Tipo = Tipo;
        }

        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Tipo do produto: " + Tipo + Environment.NewLine +
                "Nome do produto: " + Nome + Environment.NewLine +
                "Quantidade: " + Quantidade + Environment.NewLine;
        }       
    }
}
