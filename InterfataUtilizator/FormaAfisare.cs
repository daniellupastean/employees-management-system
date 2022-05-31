using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using NivelAccesDate;
using LibrarieModele;

namespace InterfataUtilizator
{
    public partial class FormaAfisare : Form
    {
        private const int PRIMA_COLOANA = 0;
        private const bool SUCCES = true;

        //initializare obiecte utilizate pentru salvarea datelor in baza de date (sau alte medii de stocare...daca exista implementare corespunzatoare)
        IStocareCompanii stocareCompanii = (IStocareCompanii)new StocareFactory().GetTipStocare(typeof(Companie));
        IStocareMasini stocareMasini = (IStocareMasini)new StocareFactory().GetTipStocare(typeof(Masina));

        public FormaAfisare()
        {
            InitializeComponent();
            if (stocareMasini == null || stocareCompanii == null)
            {
                MessageBox.Show("Eroare la initializare");
            }
        }

        #region handlere ale evenimentelor formei
        private void FormaAfisare_Load(object sender, EventArgs e)
        {
            AfiseazaCatalog();
            IncarcaCompanii();
        }
        private void FormaAfisare_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion


        #region handlere ale evenimentelor controalelor de pe forma (butoane, dataGrid)

        /// <summary>
        /// afiseaza informatiile despre masina selectata in controale ce permit editarea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridMasini_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridEmployees.CurrentCell.RowIndex;
            string idMasina = dataGridEmployees[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Masina m = stocareMasini.GetMasina(Int32.Parse(idMasina));

                //incarcarea datelor in controalele de pe forma
                if (m != null)
                {
                    lblIdMasina.Text = m.IdMasina.ToString();
                    txtFirstName.Text = m.DataFabricatie.ToShortDateString();
                    cmbRoles.SelectedItem = new ComboItem(m.Companie.Nume, m.IdCompanie);
                    txtEmail.Text = m.Model;
                    txtBirthDate.Text = m.Pret.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            groupBoxEditare.Visible = true;
        }

        /// <summary>
        /// Actualizeaza inregistrarea afisata spre editare din tabelul masini_DEV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizeaza_Click(object sender, EventArgs e)
        {
            try
            {
                var masina = new Masina(
                    Convert.ToDateTime(txtFirstName.Text),
                    ((ComboItem)cmbRoles.SelectedItem).Value,
                    txtEmail.Text,
                    decimal.Parse(txtBirthDate.Text),
                    Int32.Parse(lblIdMasina.Text));

                var rezultat = stocareMasini.UpdateMasina(masina);
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Masina actualizata");
                    AfiseazaCatalog();
                }
                else
                {
                    MessageBox.Show("Eroare la actualizare masina");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void btnAfiseazaFormaAdaugare_Click(object sender, EventArgs e)
        {
            FormaAdaugare f = new FormaAdaugare();
            f.Show();
            this.Hide();
        }

        #endregion

        #region metode helper

        /// <summary>
        /// Afiseaza companiile din tabelul companii_DEV in controlul de tip combobox
        /// </summary>
        private void IncarcaCompanii()
        {
            try
            {
                //se elimina itemii deja adaugati
                cmbRoles.Items.Clear();

                var companii = stocareCompanii.GetCompanii();
                if (companii != null && companii.Any())
                {
                    foreach (var companie in companii)
                    {
                        cmbRoles.Items.Add(new ComboItem(companie.Nume, (Int32)companie.IdCompanie));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// afiseaza informatiile complete despre masini 
        /// </summary>
        private void AfiseazaCatalog()
        {
            try
            {
                var masini = stocareMasini.GetMasini();
                if (masini != null && masini.Any())
                {
                    dataGridEmployees.DataSource = masini.Select(m=> new { m.IdMasina, m.Model, m.Companie.Nume, m.DataFabricatie, m.Pret }).ToList() ;

                    dataGridEmployees.Columns["IdMasina"].Visible = false;
                    dataGridEmployees.Columns["Nume"].HeaderText = "Companie";
                    dataGridEmployees.Columns["DataFabricatie"].HeaderText = "Data fabricatie";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        private void groupBoxEditare_Enter(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBirthDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHireDate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
