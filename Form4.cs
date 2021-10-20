using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Insira todos os dados");
            }
            else
            {
                string idTurma = textBox1.Text;
                string idModalidade = textBox2.Text;
                string nomeProfessor = textBox3.Text;
                string diaSemana = textBox5.Text;
                string horarios = textBox4.Text;
                string nDeAlunos = textBox7.Text;
                string xNaSemana = textBox6.Text;
                bool cadastrou = false;
                Turma t = new Turma(idTurma, idModalidade, nomeProfessor, diaSemana, horarios, nDeAlunos, xNaSemana);

                if (t.Validaid(idTurma)==false)
                {
                    if(t.ValidaMaxP(idModalidade,nDeAlunos)==false)
                    {
                        cadastrou = t.cadastraTurma();
                    }
                    else
                    {
                        MessageBox.Show("Turma maior que numero maximo de pessoas na modalidade");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Id ja existe");
                }

                if (cadastrou)
                {
                    MessageBox.Show("Cadastro efetuado com sucesso");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
                else
                {
                    MessageBox.Show("Falha no Cadastro");
                }
            }

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String turma = textBox8.Text;
            if (Turma.ConsultaIDTurma(turma) == true)
            {
                groupBox1.Visible = true;
                label8.Visible = false;
            }
            else
            {
                label8.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string status;
            Turma T = new Turma();
            if (radioButton1.Checked == true)
            {
                status = "1";
            }
            else
            {
                status = "0";
            }
            T.setIdTurma(textBox8.Text);
            T.setAtivo(status);
            T.alteraStatus();
            groupBox1.Visible = false;
            textBox8.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string IDTurma = textBox9.Text;
            if (Turma.ConsultaIDTurma(IDTurma) == true)
            {

                Turma T = new Turma();
                Turma.ConsultaTurma(T, IDTurma);
                
                label22.Visible = true;
                label23.Visible = true;
                label24.Visible = true;
                label25.Visible = true;
                label26.Visible = true;
                label27.Visible = true;
                label28.Visible = true;
                label29.Visible = true;
                label21.Visible = false;
                label22.Text = T.getIdTurma();
                label23.Text = T.getIdModalidade();
                label24.Text = T.getNomeProfessor();
                label25.Text = T.getDiaSemana();
                label26.Text = T.gethorarios();
                label27.Text = T.getNdeAlunos();
                label28.Text = T.getXnaSemana();
                label29.Text = T.getAtivo();
            }
            else
            {
                label21.Visible = true;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label25.Visible = false;
                label26.Visible = false;
                label27.Visible = false;
                label28.Visible = false;
                label29.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String turma = textBox12.Text;
            if (Turma.ConsultaIDTurma(turma) == true)
            {
                groupBox2.Visible = true;
                label20.Visible = false;
                textBox10.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
            }
            else
            {
                label20.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Turma T = new Turma();
            if(T.Validaid(textBox16.Text)==false)
            {
                if(T.ValidaMaxP(T.PegaModalidade(textBox12.Text), textBox16.Text)==false)
                {
                    label20.Visible = false;
                    label20.Text = "ID não Existe!!";
                    T.insereDadosUpdate(textBox12.Text, textBox10.Text, textBox14.Text, textBox13.Text, textBox16.Text, textBox15.Text);
                    T.alteraDados();
                    groupBox2.Visible = false;
                    textBox12.Text = "";
                }
                else
                {
                    label20.Visible = true;
                    label20.Text = "O novo numero de pessoas na Turma não cabe na quantidade maxima de pessoas da modalidade!!";
                }
                
                
            }
            else
            {
                label20.Text = "ID não Existe!!";
                label20.Visible = true;              
            }
            

            
        }
    }
}
