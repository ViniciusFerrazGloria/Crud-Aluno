using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class Turma
    {
        /*id turma
        id modalidade
        nomeprofessor
        horario
        diasemana
        XnaSemana
        NdeAlunos(add +1 a cada castro até atingir a QuantidadeMaxDeParticipantes da modalidade)*/

        private string idTurma;
        private string idModalidade;
        private string nomeProfessor;
        private string horarios;
        private string diaSemana;
        private string XnaSemana;
        private string NdeAlunos;

        public Turma(string idTurma, string idModalidade, string nomeProfessor, string horarios, string diaSemana, string XnaSemana, string NdeAlunos)
        {
            DAO_Conexao.getConexao("143.106.241.3", "cl19258", "cl19258", "cl*13032003");
            setIdTurma(idTurma);
            setIdModalidade(idModalidade);
            setNomeProfessor(nomeProfessor);
            setHorarios(horarios);
            setDiaSemana(diaSemana);
            setXnaSemana(XnaSemana);
            setNdeAlunos(NdeAlunos);

        }

        /////////////////////////////////
        private void setIdTurma(string idTurma)
        {
            this.idTurma = idTurma;
        }

        private string getIdTurma()
        {
            return this.idTurma;
        }

        /////////////////////////////////

        private void setIdModalidade(string idModalidade)
        {
            this.idModalidade = idModalidade;
        }

        private string getIdModalidade()
        {
            return this.idModalidade;
        }
        /////////////////////////////////

        private void setNomeProfessor(string nomeProfessor)
        {
            this.nomeProfessor = nomeProfessor;
        }

        private string getNomeProfessor()
        {
            return this.nomeProfessor;
        }

        /////////////////////////////////

        private void setHorarios(string horarios)
        {
            this.horarios = horarios;
        }

        private string gethorarios()
        {
            return this.horarios;
        }

        /////////////////////////////////

        private void setDiaSemana(string diaSemana)
        {
            this.diaSemana = diaSemana;
        }

        private string getdiaSemana()
        {
            return this.diaSemana;
        }

        /////////////////////////////////

        private void setXnaSemana(string XnaSemana)
        {
            this.XnaSemana = XnaSemana;
        }

        private string getXnaSemana()
        {
            return this.XnaSemana;
        }

        /////////////////////////////////

        private void setNdeAlunos(string NdeAlunos)
        {
            this.NdeAlunos = NdeAlunos;
        }

        private string getNdeAlunos()
        {
            return this.NdeAlunos;
        }

        /////////////////////////////////
        

    }
}
