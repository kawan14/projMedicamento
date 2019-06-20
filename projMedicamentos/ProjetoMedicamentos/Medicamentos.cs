using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamentos
{
    class Medicamentos
    {
        #region atributos

        private List<Medicamento> listaMedicamentos;

        #endregion

        #region propriedades

        public List<Medicamento> ListaMedicamentos { get => listaMedicamentos; set => listaMedicamentos = value; }
        #endregion

        #region construtores

        public Medicamentos()
        {
            ListaMedicamentos = new List<Medicamento>();
        }
        #endregion

        #region metodos

        public bool adicionar(Medicamento medicamento)
        {
            ListaMedicamentos.Add(medicamento);
            return true;
        }

        public bool deletar(Medicamento medicamento)
        {
            if (medicamento.qtdeDisponivel() == 0)
            {
                ListaMedicamentos.Remove(medicamento);
                return true;
            }
            return false;
        }

        public Medicamento pesquisar(Medicamento medicamento)
        {
            foreach (Medicamento medicamentoPesquisado in this.ListaMedicamentos)
            {
                if (medicamentoPesquisado.Id.Equals(medicamento.Id))
                    return medicamentoPesquisado;
            }
            return new Medicamento();

        }
        #endregion
    }
}
