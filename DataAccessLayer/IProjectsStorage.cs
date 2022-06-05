using LibrarieModele;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IProjectsStorage: IStocareFactory
    {
        List<Project> GetProjects();
        Project GetProject(int id);
        bool AddProject(Project p);
        bool UpdateProject(Project p);
        int GetProjectsNumber();
        bool DeleteProject(int id);
    }
}
