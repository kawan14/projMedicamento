using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamentos
{
    class Lote
    {
        #region atributos

        private int id;
        private int qtde;
        private DateTime vencimento;

        #endregion

        #region propriedades

        public int Id { get => id; set => id = value; }
        public int Qtde { get => qtde; set => qtde = value; }
        public DateTime Vencimento { get => vencimento; set => vencimento = value; }

        #endregion

        #region construtores

        public Lote():this(0,0,new DateTime()) { }

        public Lote(int id,int qtde,DateTime vencimento)
        {
            this.Id = id;
            this.Qtde = qtde;
            this.Vencimento = vencimento;
        }

        #endregion

        #region metodos
        public override string ToString()
        {
            return this.Id.ToString() + " " +
                this.Qtde.ToString() + " " +
                this.Vencimento.ToShortDateString();
        }
        #endregion

    }
}
