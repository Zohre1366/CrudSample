using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface ITestDbContext 
    {
        DbSet<Person> Person { get; }
    }
}