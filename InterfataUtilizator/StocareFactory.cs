using NivelAccesDate;
using System;
using System.Collections.Generic;
using System.Configuration;
using LibrarieModele;

namespace InterfataUtilizator
{
    /// <summary>
    /// Factory Design Pattern
    /// </summary>
    public class StocareFactory
    {
        public IStocareFactory GetTipStocare(Type tipEntitate)
        {
            var formatSalvare = ConfigurationManager.AppSettings["FormatSalvare"];
            if (formatSalvare != null)
            {
                switch (formatSalvare)
                {
                    default:
                    case "BazaDateOracle":
                        if (tipEntitate == typeof(Employee))
                        {
                            return new EmployeesAdministrator();
                        }
                        if (tipEntitate == typeof(Role))
                        {
                            return new RolesAdministrator();
                        }
                        if (tipEntitate == typeof(Project))
                        {
                            return new ProjectsAdministrator();
                        }
                        if (tipEntitate == typeof(EmployeeInProject))
                        {
                            return new EmployeesInProjectsAdministrator();
                        }

                        break;

                    case "BIN":
                        //instantiere clase care realizeaza salvarea in fisier binar
                        break;
                }
            }
            return null;
        }
    }
}
