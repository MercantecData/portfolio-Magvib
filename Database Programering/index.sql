SELECT * FROM orders 
JOIN users ON users.uid = orders.uid 
JOIN products ON products.pid = orders.pid 
JOIN address ON users.aid = address.aid 
WHERE orders.uid = 11


SELECT u.username, u.full_name, u.email, p.pname, a.adress, a.zip, a.city, a.country FROM orders 
INNER JOIN users AS u ON u.uid = orders.uid 
INNER JOIN products as p ON p.pid = orders.pid 
INNER JOIN address AS a ON u.aid = a.aid 
WHERE orders.uid = 11

DELIMITER //
CREATE PROCEDURE Test(tester int(30))
BEGIN
    DELETE FROM orders WHERE orders.oid = tester;
    SELECT *  FROM users WHERE users.uid = tester;
END



SELECT employee.employee_name, employee.employee_email, employee.employee_username, title.title_name, salary.amount, department.department_name, dep_manager.employee_id
FROM department
INNER JOIN dep_employee on dep_employee.department_id = department.department_id
INNER JOIN employee on employee.employee_id = dep_employee.dep_employee_id
INNER JOIN title on title.title_id = employee.title_id
INNER JOIN salary on salary.salary_id = title.title_id
INNER JOIN dep_manager on dep_manager.dep_manager_id = department.department_id


SELECT employee.employee_name, employee.employee_email, employee.employee_username, title.title_name, salary.amount, department.department_name, 
(SELECT employee.employee_name FROM employee WHERE dep_manager.employee_id = employee.employee_id) AS dep_manager
FROM department
INNER JOIN dep_employee on dep_employee.department_id = department.department_id
INNER JOIN employee on employee.employee_id = dep_employee.dep_employee_id
INNER JOIN title on title.title_id = employee.title_id
INNER JOIN salary on salary.salary_id = title.title_id
INNER JOIN dep_manager on dep_manager.dep_manager_id = department.department_id