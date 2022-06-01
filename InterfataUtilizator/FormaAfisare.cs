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
        IEmployeesStorage storeEmployees = (IEmployeesStorage)new StocareFactory().GetTipStocare(typeof(Employee));
        IRolesStorage storeRoles = (IRolesStorage)new StocareFactory().GetTipStocare(typeof(Role));

        public FormaAfisare()
        {
            InitializeComponent();
            if (storeEmployees == null || stocareCompanii == null)
            {
                MessageBox.Show("Eroare la initializare");
            }

            pnlHome.BringToFront();
        }

        #region handlere ale evenimentelor formei
        private void FormaAfisare_Load(object sender, EventArgs e)
        {
            ShowEmployees();
            LoadRoles();
            PopulateHomePage();
        }
        private void FormaAfisare_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion


        #region handlere ale evenimentelor controalelor de pe forma (butoane, dataGrid)


        private void btnAfiseazaFormaAdaugare_Click(object sender, EventArgs e)
        {
            FormaAdaugare f = new FormaAdaugare();
            f.Show();
            this.Hide();
            pnlEmployees.BringToFront();
        }

        #endregion

        #region metode helper

        /// <summary>
        /// Afiseaza rolurile din tabelul roles_ems_lup in controlul de tip combobox
        /// </summary>

        private void LoadRoles()
        {
            try
            {
                //se elimina itemii deja adaugati
                cmbRoles.Items.Clear();

                var roles = storeRoles.GetRoles();
                if (roles != null && roles.Any())
                {
                    foreach (var role in roles)
                    {
                        cmbRoles.Items.Add(new ComboItem(role.Title, (Int32)role.RoleId));
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
        private void ShowEmployees()
        {
            try
            {
                var employees = storeEmployees.GetEmployees();

                if (employees != null && employees.Any())
                {
                    dataGridEmployees.DataSource = employees.Select(e=> new { e.EmployeeId, e.FirstName, e.LastName, e.Email, e.BirthDate, e.HireDate, e.Role.Title }).ToList() ;
                    dataGridEmployees.Columns["EmployeeId"].Visible = false;
                    dataGridEmployees.Columns["Title"].HeaderText = "Role";
                    // dataGridEmployees.Columns["DataFabricatie"].HeaderText = "Data fabricatie";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlHome.BringToFront();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            pnlEmployees.BringToFront(); 
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {
            pnlProjects.BringToFront();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            pnlRoles.BringToFront();
        }

        private void dataGridEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridEmployees.CurrentCell.RowIndex;
            string employeeId = dataGridEmployees[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Employee emp = storeEmployees.GetEmployee(Int32.Parse(employeeId));

                //incarcarea datelor in controalele de pe forma
                if (emp != null)
                {
                    txtFirstName.Text = emp.FirstName;
                    txtLastName.Text = emp.LastName;
                    cmbRoles.SelectedItem = new ComboItem(emp.Role.Title, emp.RoleId);
                    txtEmail.Text = emp.Email;
                    txtBirthDate.Text = emp.BirthDate.ToShortDateString();
                    txtHireDate.Text = emp.HireDate.ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int currentRowIndex = dataGridEmployees.CurrentCell.RowIndex;
                string employeeId = dataGridEmployees[PRIMA_COLOANA, currentRowIndex].Value.ToString();
                var employee = new Employee(
                       txtFirstName.Text,
                       txtLastName.Text,
                       txtEmail.Text,
                       Convert.ToDateTime(txtBirthDate.Text),
                       Convert.ToDateTime(txtHireDate.Text),
                       ((ComboItem)cmbRoles.SelectedItem).Value,
                       Int32.Parse(employeeId));

                var result = storeEmployees.UpdateEmployee(employee);
                Console.WriteLine(employee.EmployeeId);
                Console.WriteLine(employee.FirstName);
                Console.WriteLine(employee.LastName);
                Console.WriteLine(employee.Email);
                Console.WriteLine(employee.BirthDate);
                Console.WriteLine(employee.HireDate);
                Console.WriteLine(employee.RoleId);

                if (result == SUCCES)
                {
                    MessageBox.Show("Updated employee");
                    ShowEmployees();
                }
                else
                {
                    MessageBox.Show("Error when updating the employee");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }

        private void PopulateHomePage()
        {
            try
            {
                int employees_no = storeEmployees.GetEmployeesNumber();

                lblEmployeesNo.Text = employees_no.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
