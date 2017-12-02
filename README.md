## Employee Database Project
A data-driven application that uses the separation of concerns design principle using C# (Visual Studio/.NET Framework) and SQL Server to track down working hours of an employee in the system. Also, employees can be added and their details modified in the database.
### Getting Started
Software pre-requisites: Visual Studio Community 2015; MS SQL Server 2014, Knowledge of C# and SQL query language
Be sure to add a SQL Connection string to the EmployeeDAO and EmpHrsDAO, which will be unique to your local Server. Otherwise, the project will not run.

-Example: Steps to create a connection object
            1. SqlConnection conn = new SqlConnection();
            2. conn.ConnectionString = ~~@"Data Source=USER-HP\SQLEXPRESS1;Initial Catalog=ETSDB;Integrated Security=True";~~ ** **(This is where the Connection String goes)** **
            3. conn.Open();

### Testing
The code was tested with sample data manually. I will add the Unit Testing at a later time.

#### Acknowledgment
Graeme Henderson (TAFE Petersham),
Riccardo Carzaniga (TAFE Petersham and Data Analyst)
