using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace testeVocacional
{
    public partial class frmPrincipal : Form
    {
        string RxString;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        public void atualizaListaCOMs()
        {
            int i;
            bool quantDiferente;	//flag para sinalizar que a quantidade de portas mudou

            i = 0;
            quantDiferente = false;

            //se a quantidade de portas mudou


            if (cbPortas.Items.Count == SerialPort.GetPortNames().Length)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (cbPortas.Items[i++].Equals(s) == false)
                    {
                        quantDiferente = true;
                    }
                }
            }
            else
            {
                quantDiferente = true;
            }

            //Se não foi detectado diferença
            if (quantDiferente == false)
            {
                return;                     //retorna
            }

            //limpa comboBox
            cbPortas.Items.Clear();

            //adiciona todas as COM diponíveis na lista
            foreach (string s in SerialPort.GetPortNames())
            {
                cbPortas.Items.Add(s);
            }
            //seleciona a primeira posição da lista
            if (cbPortas.Items.Count > 0)
            {
                cbPortas.SelectedIndex = 0;
                cbbaudrate.SelectedIndex = 2;

            }

        }

        private void atualizaPortas_Tick(object sender, EventArgs e)
        {
            atualizaListaCOMs();

            if (SerialPort.IsOpen)
            {
                lbstatus.Text = "CONECTADO";
                lbstatus.ForeColor = Color.LimeGreen;
                //principal.lbConect.Text = lbstatus.Text = "CONECTADO";// status da tela principal
            }
            else
            {
                lbstatus.Text = "DESCONECTADO";
                lbstatus.ForeColor = Color.Red;
                //principal.lbConect.Text = lbstatus.Text = "DESCONECTADO";// status da tela principal
            }
        }

        /* para conectar porta
        if (SerialPort.IsOpen == false)
            {
                try
                {
                    SerialPort.PortName = cbPortas.Items[cbPortas.SelectedIndex].ToString();// seta a porta de conexao com texto do combo box
                    SerialPort.BaudRate = int.Parse(cbbaudrate.Text);
                    SerialPort.Open();
                    lbstatus.Text = "CONECTADO";
                    //principal.lbConect.Text = lbstatus.Text = "CONECTADO";
                    lbstatus.ForeColor=Color.LimeGreen;
                    lbbaudrate.Text =Convert.ToString(SerialPort.BaudRate);
                    lbporta.Text = SerialPort.PortName;

                }
                catch
                {
                    return;

                }
                if (SerialPort.IsOpen)
                {
                    btConectar.Text = "Desconectar";
                    cbPortas.Enabled = false;
                    cbbaudrate.Enabled = false;
                }
            }
            else
            {

                try
                {
                    SerialPort.Close();
                    cbPortas.Enabled = true;
                    cbbaudrate.Enabled = true;
                    lbbaudrate.Text = "...";
                    lbporta.Text = "...";
                    btConectar.Text = "Conectar";
                    lbstatus.Text = "DESCONECTADO";
                   // principal.lbConect.Text = lbstatus.Text = "DESCONECTADO";
                    lbstatus.ForeColor = Color.Red;
                }
                catch
                {
                    return;
                }

            }
//-------------------------------*/

        //if (SerialPort.IsOpen == true)          //porta está aberta
               // SerialPort.Write(textBox2.Text); // enviar



        /* string texto;
        private void trataDadoRecebido(object sender, EventArgs e)
        {

           
               
                texto += RxString;
                textBox1.AppendText(RxString);
                listBox1.Items.Add(RxString);
                if (RxString == "ok")
                    MessageBox.Show("aee");

            if(RxString == "A") //pagina anterior
            {

            }
            if (RxString == "P") //proxima pagina
            {

            }
            if (RxString == "C") //cancelar
            {

            }
            
        }
         * */
        
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
            
            
        }

      

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmConfig conf = new frmConfig();
            if (conf.SerialPort.IsOpen == true)  // se porta aberta
                conf.SerialPort.Close();   
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void btConfigura_Click(object sender, EventArgs e)
        {
           
        }

        private void barraProgress_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            tabControl1.TabIndex = 2;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            RxString = SerialPort.ReadExisting();              //le o dado disponível na serial
            this.Invoke(new EventHandler(trataDadoRecebido));
        }
    }
}
