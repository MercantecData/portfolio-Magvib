# Database Programering

## Opgave 1
Here is a picture of the entity relationship diagram.
![](https://github.com/MercantecData/portfolio-Magvib/blob/master/Database%20Programering/Opgave%201/Mercantec.png)
<br>Here is the Users table
![](https://github.com/MercantecData/portfolio-Magvib/blob/master/Database%20Programering/Opgave%201/Users.png)



Here is the code of the view i made 
```mysql
CREATE VIEW Magvib AS
SELECT u.username, u.full_name, u.email, p.pname, a.adress, a.zip, a.city, a.country FROM orders 
INNER JOIN users AS u ON u.uid = orders.uid 
INNER JOIN products as p ON p.pid = orders.pid 
INNER JOIN address AS a ON u.aid = a.aid 
WHERE orders.uid = 11
```
And here is the view
![](https://github.com/MercantecData/portfolio-Magvib/blob/master/Database%20Programering/Opgave%201/View.png)

## Stored Procedure
Here is a procedure that deletes an order from the order database via a parameter
```mysql
DELIMITER //
CREATE PROCEDURE Test(tester int(30))
BEGIN
    DELETE FROM orders WHERE orders.oid = tester;
END
```



## Opgave 2
Here is a picture of the entity relationship diagram.
![](https://github.com/MercantecData/portfolio-Magvib/blob/master/Database%20Programering/Opgave%202/Business.png)


Here is the view i made to see all the employees in a certan department
![](https://github.com/MercantecData/portfolio-Magvib/blob/master/Database%20Programering/Opgave%202/View.png)
And here is the code
```mysql
SELECT employee.employee_name, employee.employee_email, employee.employee_username, title.title_name, salary.amount, department.department_name, 
(SELECT employee.employee_name FROM employee WHERE dep_manager.employee_id = employee.employee_id) AS dep_manager
FROM department
INNER JOIN dep_employee on dep_employee.department_id = department.department_id
INNER JOIN employee on employee.employee_id = dep_employee.dep_employee_id
INNER JOIN title on title.title_id = employee.title_id
INNER JOIN salary on salary.salary_id = title.title_id
INNER JOIN dep_manager on dep_manager.dep_manager_id = department.department_id
```