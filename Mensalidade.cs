using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class Mensalidade
    {
        private int id_Aluno;
        private string Valor;
        private string Mes;
        private string Pago;


        public Mensalidade(int id_Aluno, string Valor, string Mes, string Pago)
        {
            DAO_Conexao.getConexao("143.106.241.3", "cl19258", "cl19258", "cl*13032003");
            setId_Aluno(id_Aluno);
            setValor(Valor);
            setMes(Mes);
            setPago(Pago);



        }

        public Mensalidade()
        {

        }

        /////////////////////////////////
        public void setId_Aluno(int id_Aluno)
        {
            this.id_Aluno = id_Aluno;
        }

        public int getId_Aluno()
        {
            return this.id_Aluno;
        }

        /////////////////////////////////
        public void setValor(string Valor)
        {
            this.Valor = Valor;
        }

        public string getValor()
        {
            return this.Valor;
        }

        /////////////////////////////////
        public void setMes(string Mes)
        {
            this.Mes = Mes;
        }

        public string getMes()
        {
            return this.Mes;
        }

        /////////////////////////////////
        public void setPago(string Pago)
        {
            this.Pago = Pago;
        }

        public string getPago()
        {
            return this.Pago;
        }

        
    }


}
