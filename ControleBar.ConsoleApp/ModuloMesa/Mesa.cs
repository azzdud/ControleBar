using ControleBar.ConsoleApp.Compartilhado;
using System;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public string Numero { get; set; }

        public Mesa(string numero)
        {
            Numero = numero;
        }

        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Número da mesa: " + Numero + Environment.NewLine;
        }       
    }
}
