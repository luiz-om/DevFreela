using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, string description, int idCliente,
            int idFreelancer, string clientName, string freelancerName, decimal totalCost,
            List<ProjectComment> comments)
        {
            this.id = id;
            Title = title;
            Description = description;
            IdCliente = idCliente;
            IdFreelancer = idFreelancer;
            ClientName = clientName;
            FreelancerName = freelancerName;
            TotalCost = totalCost;
            Comments = comments.Select(c => c.Content).ToList();
        }

        public int id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdCliente { get; private set; }
        public int IdFreelancer { get; private set; }
        public string ClientName { get; private set; }
        public string FreelancerName { get; set; }
        public decimal TotalCost { get; private set; }
        public List<string> Comments { get; private set; }


        public static ProjectViewModel FromEntity(Project project)
        => new ProjectViewModel(project.Id, project.Title,project.Description, project.IdClient, project.IdFreelancer,
         project.Client.FullName,project.Freelancer.FullName, project.TotalCost, project.Comments );

    }
}