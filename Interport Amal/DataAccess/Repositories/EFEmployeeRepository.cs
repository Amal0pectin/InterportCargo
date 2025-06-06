using Interport_Amal.BusinessLogic.Entities;
using Interport_Amal.DataAccess.Data;
using Interport_Amal.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Interport_Amal.DataAccess.Repositories
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private readonly CargoDBContext myContext;

        public EFEmployeeRepository(CargoDBContext context)
        {
            myContext = context;
        }


        public List<Employee> GetAll() => myContext.Employees.ToList();

        public Employee GetById(int EmployeeId) => myContext.Employees.Find(EmployeeId);

        public Employee GetByEmail(string email)
        {
            return myContext.Employees.FirstOrDefault(c => c.Email == email);
        }

        public void Add(Employee employee)
        {
            myContext.Employees.Add(employee);
            myContext.SaveChanges();
        }

        public void Update(Employee employee)
        {
            myContext.Entry(employee).State = EntityState.Modified;
            myContext.SaveChanges();
        }

        public void Delete(int EmployeeId)
        {
            var employee = myContext.Employees.Find(EmployeeId);
            if (employee != null)
            {
                myContext.Employees.Remove(employee);
                myContext.SaveChanges();
            }
        }
    }
    
}
