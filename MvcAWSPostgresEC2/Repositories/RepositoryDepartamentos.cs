using Microsoft.EntityFrameworkCore;
using MvcAWSPostgresEC2.Data;
using MvcAWSPostgresEC2.Models;

namespace MvcAWSPostgresEC2.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;
        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }


        public async Task<Departamento> FindDepartamentoAsync(int id)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(z => z.IdDepartamento == id);
        }

        public async Task InsertDepartamento
            (int id, string nombre, string localidad)
        {
            Departamento dept = new Departamento
            {
                IdDepartamento = id,
                Nombre = nombre,
                Localidad = localidad
            };
            this.context.Departamentos.Add(dept);
            await this.context.SaveChangesAsync();
        }


    }
}
