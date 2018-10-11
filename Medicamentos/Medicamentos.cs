using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Medicamento
{
    public class Medicamentos
    {
        List<Medicamento> listaMedicamentos = new List<Medicamento>();
        
        private List<Medicamento> meusMedicamentos;

        public Medicamentos()
        {
            this.meusMedicamentos = new List<Medicamento>();
        }

        internal List<Medicamento> MeusMedicamentos
        {
            get
            {
                return meusMedicamentos;
            }

       
        }
       
        public void adicionar(Medicamento medicamento)
        {
            
            this.MeusMedicamentos.Add(medicamento);
        }

        public bool deletar(Medicamento medicamento)
        {
            if (medicamento.qtdeDisponivel() == 0)
            {
                this.MeusMedicamentos.Remove(medicamento);
                return true;
            }
            else{
                return false;
            }            
        }

        public Medicamento pesquisar(Medicamento medicamento)
        {
            foreach (Medicamento medicamentoPesquisado in this.MeusMedicamentos)
                if (medicamentoPesquisado.Id.Equals(medicamento.Id))
                    return medicamentoPesquisado;
            return new Medicamento();
        }

    }
}
