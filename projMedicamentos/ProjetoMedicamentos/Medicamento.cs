using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamentos
{
    class Medicamento
    {
        #region atributos

        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes;

        #endregion

        #region propriedades

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Laboratorio { get => laboratorio; set => laboratorio = value; }
        public Queue<Lote> Lotes { get => lotes; set => lotes = value; }
        #endregion

        #region construtores

        public Medicamento():this(0,"","")
        { 
            Lotes = new Queue<Lote>();
        }

        public Medicamento(int id, string nome, string laboratorio)
        {
            this.Id = id;
            this.Laboratorio = laboratorio;
            this.Nome = nome;
            Lotes = new Queue<Lote>();
        }
        #endregion

        #region metodos

        public int qtdeDisponivel()
        {
            int qtdeEstoque = 0;
            foreach (Lote lote in Lotes)
            {
                qtdeEstoque += lote.Qtde;
            }
            return qtdeEstoque;

        }

        public void comprar(Lote lote)
        {
            Lotes.Enqueue(lote);

        }

        public bool vender(int qtde)
        {
            bool podeVender = (this.qtdeDisponivel() >= qtde);
            int saldo;
            if (podeVender)
            {
                saldo = qtde;
                while (saldo > 0)
                {
                    if (this.lotes.First().Qtde > saldo)
                    {
                        this.lotes.First().Qtde -= saldo;
                        saldo = 0;
                    }
                    else if (this.lotes.First().Qtde == saldo)
                    {
                        saldo -= this.lotes.Dequeue().Qtde;
                    }
                    else
                    {
                        saldo -= this.lotes.Dequeue().Qtde;
                    }

                }
            }
            return podeVender;
        }


        public override string ToString()
        {
            return "ID:"+Id + " \nNome: " + Nome + " \nLaboratorio: " + Laboratorio + " \nQuantidade: " + qtdeDisponivel();
        }

        public override bool Equals(object obj)
        {
            return ((Medicamento)obj).Id.Equals(this.Id);
        }
        #endregion
    }
}
