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
        IEmployeesStorage storeEmployees = (IEmployeesStorage)new StocareFactory().GetTipStocare(typeof(Employee));
        IRolesStorage storeRoles = (IRolesStorage)new StocareFactory().GetTipStocare(typeof(Role));
        IProjectsStorage storeProjects = (IProjectsStorage)new StocareFactory().GetTipStocare(typeof(Project));
        IEmployeesInProjectsStorage storeEmployeesInProjects = (IEmployeesInProjectsStorage)new StocareFactory().GetTipStocare(typeof(EmployeeInProject));

        public FormaAfisare()
        {
            InitializeComponent();
            if (storeEmployees == null || storeEmployeesInProjects == null || storeProjects == null || storeRoles == null)
            {
                MessageBox.Show("Initialization error");
            }

            pnlHome.BringToFront();
        }
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
        private void LoadRolesInProjects()
        {
            try
            {
                //se elimina itemii deja adaugati
                cmbRoleInProjects.Items.Clear();

                var roles = storeRoles.GetRoles();
                if (roles != null && roles.Any())
                {
                    foreach (var role in roles)
                    {
                        cmbRoleInProjects.Items.Add(new ComboItem(role.Title, (Int32)role.RoleId));
                    }
                }
                cmbRoleInProjects.SelectedIndex = cmbRoleInProjects.Items.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
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
        private void ShowEmployeesInProjects()
        {
            try
            {
                var employees = storeEmployees.GetEmployees();

                if (employees != null && employees.Any())
                {
                    dgvEmployeesP.DataSource = employees.Select(e => new { e.EmployeeId, e.FirstName, e.LastName, e.Email, e.BirthDate, e.HireDate, e.Role.Title }).ToList();
                    dgvEmployeesP.Columns["EmployeeId"].Visible = false;
                    dgvEmployeesP.Columns["Email"].Visible = false;
                    dgvEmployeesP.Columns["BirthDate"].Visible = false;
                    dgvEmployeesP.Columns["HireDate"].Visible = false;
                    dgvEmployeesP.Columns["Title"].Visible = false;
                    //dataGridEmployees.Columns["Title"].HeaderText = "Role";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void ShowRoles()
        {
            try
            {
                var roles = storeRoles.GetRoles();

                if (roles != null && roles.Any())
                {
                    dataGridViewRoles.DataSource = roles.Select(e => new { e.RoleId, e.Title }).ToList();
                    dataGridViewRoles.Columns["RoleId"].Visible = false;
                    dataGridViewRoles.Columns["Title"].HeaderText = "Role";
                    // dataGridEmployees.Columns["DataFabricatie"].HeaderText = "Data fabricatie";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }        
        private void ShowProjects()
        {
            try
            {
                var projects = storeProjects.GetProjects();

                if (projects != null && projects.Any())
                {
                    dgvProjectsP.DataSource = projects.Select(e => new { e.ProjectId, e.Title, e.Finished }).ToList();
                    dgvProjectsP.Columns["ProjectId"].Visible = false;
                   // dgvProjectsP.Columns["Title"].HeaderText = "Role";
                   // dataGridEmployees.Columns["DataFabricatie"].HeaderText = "Data fabricatie";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlHome.BringToFront();
            PopulateHomePage();
        }
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            pnlEmployees.BringToFront();
            ShowEmployees();
            LoadRoles();
        }
        private void btnProjects_Click(object sender, EventArgs e)
        {
            ShowProjects();
            ShowEmployeesInProjects();
            LoadRolesInProjects();
            dbvEmployeesP.DataSource = null;
            pnlProjects.BringToFront();
        }
        private void btnRoles_Click(object sender, EventArgs e)
        {
            ShowRoles();
            pnlRoles.BringToFront();
        }
        private void dataGridEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridEmployees.CurrentCell.RowIndex;
            string employeeId = dataGridEmployees[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Employee emp = storeEmployees.GetEmployee(Int32.Parse(employeeId));
                LoadEmployeesOfAProject2();
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
                // number of employees
                int employees_no = storeEmployees.GetEmployeesNumber();
                lblEmployeesNo.Text = employees_no.ToString();
                if (employees_no == 1) lblEmployeesText.Text = "employee";
                else lblEmployeesText.Text = "employees";

                // number of projects
                int projects_no = storeProjects.GetProjectsNumber();
                lblProjectsNo.Text = projects_no.ToString();
                if (projects_no == 1) lblProjectsText.Text = "project";
                else lblProjectsText.Text = "projects";

                // celebrated employee
                string celebratedEmployee = storeEmployees.GetCelebratedEmployee();
                lblCelebratedName.Text = celebratedEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                var employee = new Employee(
                       txtFirstName.Text,
                       txtLastName.Text,
                       txtEmail.Text,
                       Convert.ToDateTime(txtBirthDate.Text),
                       Convert.ToDateTime(txtHireDate.Text),
                       ((ComboItem)cmbRoles.SelectedItem).Value);

                var result = storeEmployees.AddEmployee(employee);

                if (result == SUCCES)
                {
                    MessageBox.Show("Added employee");
                    ShowEmployees();
                }
                else
                {
                    MessageBox.Show("Error when adding the employee");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }
        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                int currentRowIndex = dataGridEmployees.CurrentCell.RowIndex;
                int employeeId = int.Parse(dataGridEmployees[PRIMA_COLOANA, currentRowIndex].Value.ToString());

                var result = storeEmployees.DeleteEmployee(employeeId);

                if (result == SUCCES)
                {
                    MessageBox.Show("Deleted employee");
                    ShowEmployees();
                }
                else
                {
                    MessageBox.Show("Error when deleting the employee");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }
        private void dataGridViewRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridViewRoles.CurrentCell.RowIndex;
            string roleId = dataGridViewRoles[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Role r = storeRoles.GetRole(Int32.Parse(roleId));

                //incarcarea datelor in controalele de pe forma
                if (r != null)
                {
                    txtRoleTitle.Text = r.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btnAddNewRole_Click(object sender, EventArgs e)
        {
            try
            {
                var role = new Role( txtRoleTitle.Text );

                var result = storeRoles.AddRole(role);

                if (result == SUCCES)
                {
                    //MessageBox.Show("Role added");
                    ShowRoles();
                    txtRoleTitle.Text = "";
                }
                else
                {
                    MessageBox.Show("Error when adding the role");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }
        private void btnUpdateRole_Click(object sender, EventArgs e)
        {
            try
            {
                int currentRowIndex = dataGridViewRoles.CurrentCell.RowIndex;
                int roleId = int.Parse(dataGridViewRoles[PRIMA_COLOANA, currentRowIndex].Value.ToString());
                var role = new Role( txtRoleTitle.Text, roleId );


                var result = storeRoles.UpdateRole(role);

                if (result == SUCCES)
                {
                    //MessageBox.Show("Updated role");
                    ShowRoles();
                    txtRoleTitle.Text = "";
                }
                else
                {
                    MessageBox.Show("Error when updating the role");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }
        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            try
            {
                int currentRowIndex = dataGridViewRoles.CurrentCell.RowIndex;
                int roleId = int.Parse(dataGridViewRoles[PRIMA_COLOANA, currentRowIndex].Value.ToString());

                var result = storeRoles.DeleteRole(roleId);

                if (result == SUCCES)
                {
                    MessageBox.Show("Deleted role");
                    ShowRoles();
                    txtRoleTitle.Text = "";
                }
                else
                {
                    MessageBox.Show("Error when deleting the employee");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }
        private void dgvProjectsP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dgvProjectsP.CurrentCell.RowIndex;
            int projectId = Int32.Parse(dgvProjectsP[PRIMA_COLOANA, currentRowIndex].Value.ToString());

            try
            {
                Project p = storeProjects.GetProject(projectId);

                //incarcarea datelor in controalele de pe forma
                if (p != null)
                {
                    txtTitle.Text = p.Title;
                    if (p.Finished) rbtnYes.Checked = true;
                    else rbtnNo.Checked = true;
                    LoadEmployeesOfAProject();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btnAddNewProject_Click(object sender, EventArgs e)
        {
            try
            {
                bool finished = rbtnYes.Checked;
                var project = new Project(txtTitle.Text, rbtnYes.Checked);

                var result = storeProjects.AddProject(project);

                if (result == SUCCES)
                {
                    //MessageBox.Show("Project added");
                    ShowProjects();
                    txtTitle.Text = "";
                }
                else
                {
                    MessageBox.Show("Error when adding the project");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }
        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            try
            {
                int currentRowIndex = dgvProjectsP.CurrentCell.RowIndex;
                int projectId = int.Parse(dgvProjectsP[PRIMA_COLOANA, currentRowIndex].Value.ToString());

                var result = storeProjects.DeleteProject(projectId);

                if (result == SUCCES)
                {
                    MessageBox.Show("Project deleted");
                    ShowProjects();
                    txtTitle.Text = "";
                }
                else
                {
                    MessageBox.Show("Error when deleting the project");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }
        private void btnUpdateProject_Click(object sender, EventArgs e)
        {
            try
            {
                int currentRowIndex = dgvProjectsP.CurrentCell.RowIndex;
                int projectId = int.Parse(dgvProjectsP[PRIMA_COLOANA, currentRowIndex].Value.ToString());
                var project = new Project(txtTitle.Text, rbtnYes.Checked, projectId);
                var result = storeProjects.UpdateProject(project);

                if (result == SUCCES)
                {
                    //MessageBox.Show("Updated project");
                    ShowProjects();
                    txtTitle.Text = "";
                }
                else
                {
                    MessageBox.Show("Error when updating the project");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }
        private void btnAddEtoP_Click(object sender, EventArgs e)
        {
            try
            {
                int currentRowIndexProjects = dgvProjectsP.CurrentCell.RowIndex;
                int currentRowIndexEmployees = dgvEmployeesP.CurrentCell.RowIndex;
                int projectId = int.Parse(dgvProjectsP[PRIMA_COLOANA, currentRowIndexProjects].Value.ToString());
                int employeeId = int.Parse(dgvEmployeesP[PRIMA_COLOANA, currentRowIndexEmployees].Value.ToString());
                int roleId = ((ComboItem)cmbRoleInProjects.SelectedItem).Value;
                var employeeInProject = new EmployeeInProject(employeeId, projectId, roleId, DateTime.Now, DateTime.Now, true);
                var result = storeEmployeesInProjects.AddEmployeeInProject(employeeInProject);

                if (result == SUCCES)
                {
                    MessageBox.Show("Employee added to project");
                    // ShowProjects();
                    // txtTitle.Text = "";
                    LoadEmployeesOfAProject();
                }
                else
                {
                    MessageBox.Show("Error when adding the employee to the project");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }
        private void LoadEmployeesOfAProject()
        {
            int currentRowIndex = dgvProjectsP.CurrentCell.RowIndex;
            int projectId = Int32.Parse(dgvProjectsP[PRIMA_COLOANA, currentRowIndex].Value.ToString());
            var employeesInProject = storeEmployeesInProjects.GetEmployeesInProject(projectId);
            dbvEmployeesP.DataSource = null;

            if (employeesInProject != null && employeesInProject.Any())
            {

                dbvEmployeesP.DataSource = employeesInProject.Select(einp => new { einp.Id, einp.Employee.EmployeeId, einp.Employee.FirstName, einp.Employee.LastName, Role = einp.Role.Title }).ToList();
                dbvEmployeesP.Columns["Id"].Visible = false;
                dbvEmployeesP.Columns["EmployeeId"].Visible = false;
                // dbvEmployeesP.Columns["DataFabricatie"].HeaderText = "Data fabricatie";
            }
        }
        private void LoadEmployeesOfAProject2()
        {
            int currentRowIndex = dataGridEmployees.CurrentCell.RowIndex;
            int employeeId = Int32.Parse(dataGridEmployees[PRIMA_COLOANA, currentRowIndex].Value.ToString());
            var employeesInProject = storeEmployeesInProjects.GetProjectsOfEmployee(employeeId);
            dataGridViewProjects.DataSource = null;

            if (employeesInProject != null && employeesInProject.Any())
            {
                dataGridViewProjects.DataSource = employeesInProject.Select(einp => new { einp.Id, einp.Project.ProjectId, einp.Project.Title, Role = einp.Role.Title }).ToList();
                dataGridViewProjects.Columns["Id"].Visible = false;
                dataGridViewProjects.Columns["ProjectId"].Visible = false;
            }
        }

        private void btnUnasignEmployee_Click(object sender, EventArgs e)
        {
            // to be continued
            try
            {
                int currentRowIndex = dbvEmployeesP.CurrentCell.RowIndex;
                int employeeInProjectId = int.Parse(dbvEmployeesP[PRIMA_COLOANA, currentRowIndex].Value.ToString());

                var result = storeEmployeesInProjects.DeleteEmployeeFromProject(employeeInProjectId);

                if (result == SUCCES)
                {
                    MessageBox.Show("Deleted employee from project");
                    LoadEmployeesOfAProject();
                    txtRoleTitle.Text = "";
                }
                else
                {
                    MessageBox.Show("Error when deleting the employee from project");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }

        private void btnUnassignEmployee_Click(object sender, EventArgs e)
        {
            // to be continued
            try
            {
                int currentRowIndex = dataGridViewProjects.CurrentCell.RowIndex;
                int employeeInProjectId = int.Parse(dataGridViewProjects[PRIMA_COLOANA, currentRowIndex].Value.ToString());

                var result = storeEmployeesInProjects.DeleteEmployeeFromProject(employeeInProjectId);

                if (result == SUCCES)
                {
                    MessageBox.Show("Deleted employee from project");
                    LoadEmployeesOfAProject2();
                    txtRoleTitle.Text = "";
                }
                else
                {
                    MessageBox.Show("Error when deleting the employee from project");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }
    }
}
