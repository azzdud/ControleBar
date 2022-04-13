using ControleBar.ConsoleApp.Compartilhado;
using System;

namespace ControleBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public string Tipo { get; set; }

        public int Quantidade { get; set; }

        public Conta(int quantidade, string tipo)
        {
            Tipo = tipo;

            Quantidade = quantidade;
        }

        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Produtos: " + Environment.NewLine +
                Quantidade + " " + Tipo + "(s)" + Environment.NewLine;
        }       
    }
}
