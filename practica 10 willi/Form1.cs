using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica_10_willi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BttnGuardar_Click(object sender, EventArgs e)
        {
            clienteBindingSource.EndEdit();

            
            Cliente cliente = clienteBindingSource.Current as Cliente;

            if (cliente != null)
            {
                
                ClienteValidar validator = new ClienteValidar();
                ValidationResult results = validator.Validate(cliente);

                
                if (!results.IsValid)
                {
                    foreach (ValidationFailure failure in results.Errors)
                    {
                        MessageBox.Show(failure.ErrorMessage, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return; 
                }

               
                MessageBox.Show("Se guardaron correctamente los datos", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No hay ningún cliente seleccionado o activo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            
        

        private void Form1_Load(object sender, EventArgs e)
        {
            clienteBindingSource.DataSource = new Cliente();
        }
    }
}
