using demoemployee.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demoemployee.Models.Shared;

namespace demoemployee.ViewModels
{
    public class EmployeeViewModel
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();


            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spShowEmployees", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(reader["Id"]);
                        employee.Name = reader["Name"].ToString();
                        employee.ProfileImage = reader["ProfileImage"].ToString();
                        employee.Gender = reader["Gender"].ToString();
                        employee.Salary = Convert.ToInt32(reader["Salary"]);
                        employee.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        employee.Notes = reader["Notes"].ToString();
                        employee.Department = reader["Department"].ToString();

                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }

        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spUpdateEmployee", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", employee.Id);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Note", employee.Notes);
                    cmd.Parameters.AddWithValue("@departList", employee.Department);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Create
        public void AddEmployee(Employee employee)
        {
            using(SqlConnection conn=new SqlConnection(AppSettings.ConnectionString()))
            {
                using (SqlCommand cmd=new SqlCommand("spInsertEmployee", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Note", employee.Notes);
                    cmd.Parameters.AddWithValue("@departList", employee.Department);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Read
        public Employee GetEmployeeByEmployeeId(int Id)
        {
            Employee employee = new Employee();

            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spGetEmployeeByEmployeeId", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();

                    employee.Id = Convert.ToInt32(reader["Id"]);
                    employee.Name = reader["Name"].ToString();
                    employee.ProfileImage = reader["ProfileImage"].ToString();
                    employee.Gender = reader["Gender"].ToString();
                    employee.Salary = Convert.ToInt32(reader["Salary"]);
                    employee.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    employee.Notes = reader["Notes"].ToString();
                    employee.Department = reader["Department"].ToString();
                }
            }


            return employee;
         }

        public void DeleteEmployee(int Id)
        {
            Employee employee = new Employee();

            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spDeleteEmployeeById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", Id);

                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
