using BLL.Services;
using Domain;
using SL.Domain;
using SL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    Cliente cliente = new Cliente();
                    cliente.Nombre = textBox1.Text;
                    cliente.Apellido = textBox2.Text;
                    cliente.Direccion = textBox3.Text;
                    cliente.FechaNacimiento = dateTimePicker1.Value;
                    ClienteServices.Current.insertCliente(cliente);
                }
                else
                {   
                    throw new Exception("Datos incompletos");
                }
            }
            catch (Exception ex)
            {
                Logger.Current.Store(new Log(ex.Message, System.Diagnostics.Tracing.EventLevel.Warning, System.DateTime.Now));
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Log> logs = new List<Log>();
            logs = Logger.Current.GetAll();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = logs;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("Test CriticalError");
            }
            catch (Exception ex)
            {
                Logger.Current.Store(new Log(ex.Message, System.Diagnostics.Tracing.EventLevel.Critical, System.DateTime.Now));
            }
            finally 
            { 
                listBox1.DataSource = null;
                listBox1.DataSource = SL.Services.ServicesMailNotify.Current.mails;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("Test FatalError");
            }
            catch (Exception ex)
            {
                Logger.Current.Store(new Log(ex.Message, System.Diagnostics.Tracing.EventLevel.Critical, System.DateTime.Now));
            }
            finally
            {
                listBox1.DataSource = null;
                listBox1.DataSource = SL.Services.ServicesMailNotify.Current.mails;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Log> logs = new List<Log>();
            logs = Logger.Current.GetLogsToday();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = logs;
        }
    }
}
