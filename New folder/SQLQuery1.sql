CREATE TABLE Customers 
(
	Customerid char(5) not null,
	CompanyName varchar(40) not null,
	ContactName Char(30) null,
	[Address] varchar(60) null,
	City Char(15) null,
	Phone Char(24) null,
	Fax Char(24) null
)
CREATE TABLE Orders
(
 OrderId integer not null,
 customerId char(5) not null,
 Orderdate datetime null,
 Shippeddate datetime null,
 Freight money null,
 Shipname varchar(40) null,
 Shipaddres varchar(60) null,
 Quantity integer null
)

Alter table  dbo.Orders
Add shipregion integer null


Alter table dbo.Orders
Alter column shipregion Char(8) null

Alter table dbo.Orders
Drop column shipregion 

Insert into dbo.Orders
values ( 10, 'ord01', getdate(), getdate(), 100.0, 'Windstar', 'Ocean' ,1)

Alter table dbo.Orders
Add Constraint Df_OrderDate Default GetDate() for Orderdate

Exec sp_rename 'dbo.Customers.City','Town','COLUMN'

CREATE TABLE Department
(
	Dept_no Char(10) not null,
	Dept_name Char(10) not null,
	location CHAR(50) not null
)

Insert INTO dbo.Department values('d1','Res','Dallas');
Insert INTO dbo.Department values('d2','Ac','Seattle');
Insert INTO dbo.Department values('d3','Ma','Dallas');




CREATE TABLE Employee
(
	emp_no Integer not null,
	emp_fname char(50) not null,
	emp_lname char(50) not null,
	Dept_no Char(10) not null
)

Insert INTO dbo.Employee values('25348','Matthew','Smith','d3');
Insert INTO dbo.Employee values('10102','Ann','Jones','d3');
Insert INTO dbo.Employee values('18316','John','Barrimore','d1');
Insert INTO dbo.Employee values('29346','James','James','d2');

CREATE TABLE Project
(
	project_no Char(10) not null,
	project_name char(50) not null,
	Budget Varchar(50) not null
)

Insert INTO dbo.Project values('p1','Apollo','120000');
Insert INTO dbo.Project values('p2','Gemini','95000');
Insert INTO dbo.Project values('p3','Mercury','18560');

CREATE TABLE Work_on
(
	emp_no Integer not null,
	project_no char(10) not null,
	Job Varchar(50) null,
	enter_date date not null
)

Insert INTO dbo.Work_on values('10102','p1','Analyst','1997.10.1')
Insert INTO dbo.Work_on values('10102','p3','manager','1999.1.1')
Insert INTO dbo.Work_on values('25348','p2','Clerk','1998.2.1')
Insert INTO dbo.Work_on values('518316','p2',NULL,'1998.6.1')
Insert INTO dbo.Work_on values('29346','p2',NULL,'1997.12.1')
Insert INTO dbo.Work_on values('52581','p3','Analyst','1998.10.1')
Insert INTO dbo.Work_on values('59031','p1','Manager','1998.4.1')
Insert INTO dbo.Work_on values('28556','p1',NULL,'1998.8.1')
Insert INTO dbo.Work_on values('28559','p2','Clerk','1992.2.1')
Insert INTO dbo.Work_on values('9031','p3','Clerk','1997.11.1')
Insert INTO dbo.Work_on values('29346','p1','Clerk','1998.1.4')

----------------

Select * from dbo.work_on

Select Emp_no from  dbo.Work_on Where Job = 'Clerk'

select emp_no from dbo.work_on where project_no = 'p2'
UNION 
SELECT emp_no FROM dbo.Work_on Where emp_no > 10000

select emp_no from dbo.work_on where DATEPART(yyyy,enter_date) != '1998'

select emp_no from dbo.work_on where project_no = 'p1' and (Job ='Analyst' OR JOB = 'manager')

select enter_date from dbo.work_on where project_no = 'p2' and Job is null

select emp_no,emp_lname from dbo.Employee where emp_fname like ('%t%') and emp_fname like ('%s%')

select emp_no,emp_lname from dbo.Employee where (emp_lname like ('_o%') or emp_lname like ('_a%')) AND emp_lname like ('%es')

select emp_no from dbo.Employee E INNER JOIN dbo.Department D ON E.Dept_no = D.Dept_no
where D.location = 'Seattle'

select emp_fname,emp_lname from dbo.Employee E INNER JOIN dbo.Work_on W ON E.emp_no = W.emp_no where W.enter_date = '04-01-1997'

select location From Department group by location
select Max(emp_no) From dbo.Employee 

Select job from Dbo.work_on where emp_no in (select emp_no FROM dbo.Work_on group by emp_no having count(job) >= 2)

Select e.emp_no from Dbo.work_on W inner join dbo.Employee E ON W.emp_no = E.emp_no where job = 'Clerk' or Dept_no = 'd3'