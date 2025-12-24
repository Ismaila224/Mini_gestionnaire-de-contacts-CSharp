using Mini_gestionnaire_de_contacts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_gestionnaire_de_list
{
    public partial class frmContact : Form
    {
        public frmContact()
        {
            InitializeComponent();
        }

    

        List<Contact> contacts = new List<Contact>();

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (txtNom.Text !="" && txtTelephone.Text!="" && txtEmail.Text != "")
            {
                Contact c = new Contact();
                c.Nom = txtNom.Text;
                c.Telephone = txtTelephone.Text;
                c.Email = txtEmail.Text;
                contacts.Add(c);
                txtNom.Clear();
                txtTelephone.Clear();
                txtEmail.Clear();
                txtNom.Focus();
                dgvContact.DataSource = null;
                dgvContact.DataSource = contacts;
            }
            else {                
                MessageBox.Show("Veuillez remplir tous les champs."); 
            }

        }



        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (dgvContact.CurrentRow== null)
            {
                MessageBox.Show("Veuillez sélectionner un contact dans la liste.");
               
            }
            else {
                Contact c = dgvContact.CurrentRow.DataBoundItem as Contact;
                txtNom.Text = c.Nom;
                txtTelephone.Text = c.Telephone;
                txtEmail.Text = c.Email;

            }
        }

        private void btnSuprimer_Click(object sender, EventArgs e)
        {
            if (dgvContact.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un contact dans la liste.");

            }
            else
            {
                Contact c = dgvContact.CurrentRow.DataBoundItem as Contact;
                contacts.Remove(c);
                dgvContact.DataSource = null;
                dgvContact.DataSource = contacts;
                txtNom.Clear();
                txtTelephone.Clear();
                txtEmail.Clear();
                txtNom.Focus();
            }
        }

        private void btnModifier_Click_1(object sender, EventArgs e)
        {
            if (dgvContact.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un contact dans la liste.");

            }
            else
            {
                if (txtNom.Text != "" && txtTelephone.Text != "" && txtEmail.Text != "")
                {
                    Contact c = dgvContact.CurrentRow.DataBoundItem as Contact;
                    c.Nom = txtNom.Text;
                    c.Telephone = txtTelephone.Text;
                    c.Email = txtEmail.Text;
                    dgvContact.DataSource = null;
                    dgvContact.DataSource = contacts;
                    txtNom.Clear();
                    txtTelephone.Clear();
                    txtEmail.Clear();
                    txtNom.Focus();
                }
                else
                {
                    MessageBox.Show("Veuillez remplir tous les champs.");
                }
                
            }

        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            var recherche = txtRecherche.Text.ToLower();
            var resultat = contacts.Where(c => c.Nom.ToLower().Contains(recherche) || c.Telephone.ToLower().Contains(recherche) || c.Email.ToLower().Contains(recherche)).ToList();
            dgvContact.DataSource = null;
            dgvContact.DataSource = resultat;

        }
    }
}
