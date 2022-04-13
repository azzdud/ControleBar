using ControleBar.ConsoleApp.Compartilhado;
//using ControleBar.ConsoleApp.ModuloPedido;
using System;
using System.Collections.Generic;

namespace ControleBar.ConsoleApp.ModuloConta
{
    public class TelaCadastroConta : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Conta> _repositorioConta;
        private readonly Notificador _notificador;
        /*private readonly IRepositorio<Pedido> repositorioPedido;
        private readonly TelaCadastroPedido telaCadastroPedido;*/

        public TelaCadastroConta(IRepositorio<Conta> repositorioConta, Notificador notificador)
            : base("Abrindo uma Conta")
        {
            _repositorioConta = repositorioConta;
            _notificador = notificador;
        }

        public void Inserir()
        {
            MostrarTitulo("Abrindo uma Conta");

            Conta novaConta = ObterConta();

            _repositorioConta.Inserir(novaConta);

            _notificador.ApresentarMensagem("Conta aberta com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Pedidos");

            bool temRegistrosCadastrados = VisualizarRegistros("Pesquisando");

            if (temRegistrosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhuma conta aberta para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroGenero = ObterNumeroRegistro();

            Conta contaAtualizada = ObterConta();

            bool conseguiuEditar = _repositorioConta.Editar(numeroGenero, contaAtualizada);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Conta editada com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Conta");

            bool temContasRegistradas = VisualizarRegistros("Pesquisando");

            if (temContasRegistradas == false)
            {
                _notificador.ApresentarMensagem("Nenhuma conta cadastrada para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroConta = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioConta.Excluir(numeroConta);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Conta excluída com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Contas Abertas");

            List<Conta> contas = _repositorioConta.SelecionarTodos();

            if (contas.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhuma conta disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Conta conta in contas)
                Console.WriteLine(conta.ToString());

            Console.ReadLine();

            return true;
        }

        private Conta ObterConta()
        {
            Console.Write("Digite o ID da mesa: ");
            string id = Console.ReadLine();

            Console.Write("Digite o pedido: ");
            string pedido = Console.ReadLine();
            Console.Write("Digite a quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            return new Conta(quantidade, pedido);
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID da conta que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioConta.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("o ID da conta não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
    }
}