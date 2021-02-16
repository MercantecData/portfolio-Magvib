/*--------------------*//* Create the vps database *//*--------------------*/
CREATE DATABASE IF NOT EXISTS vsp;
USE vsp;

/*--------------------*//* Create the tables needed *//*--------------------*/
CREATE TABLE IF NOT EXISTS employees (
	id INT PRIMARY KEY AUTO_INCREMENT,
	emp_no INT NOT NULL UNIQUE,
	birth_date DATETIME NOT NULL,
	firstname VARCHAR(14) NOT NULL,
	lastname VARCHAR(16) NOT NULL,
	sex ENUM('M', 'F') NOT NULL,
	hire_date DATETIME NOT NULL
);

CREATE TABLE IF NOT EXISTS departments (
	id INT PRIMARY KEY AUTO_INCREMENT,
	dept_no CHAR(4) NOT NULL UNIQUE,
	dept_name VARCHAR(40) NOT NULL
);

CREATE TABLE IF NOT EXISTS dept_manager (
	id INT PRIMARY KEY AUTO_INCREMENT,
	dept_no CHAR(4) NOT NULL,
	emp_no INT NOT NULL,
	from_date DATETIME,
	to_date DATETIME,
	FOREIGN KEY (dept_no) REFERENCES departments(dept_no) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (emp_no) REFERENCES employees(emp_no) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS dept_employees (
	id INT PRIMARY KEY AUTO_INCREMENT,
	dept_no CHAR(4) NOT NULL,
	emp_no INT NOT NULL,
	from_date DATETIME,
	to_date DATETIME,
	FOREIGN KEY (dept_no) REFERENCES departments(dept_no) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (emp_no) REFERENCES employees(emp_no) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS titles (
	id INT PRIMARY KEY AUTO_INCREMENT,
	emp_no INT NOT NULL,
	title VARCHAR(50) NOT NULL,
	from_date DATETIME,
	to_date DATETIME,
	FOREIGN KEY (emp_no) REFERENCES employees(emp_no) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS salaries (
	id INT PRIMARY KEY AUTO_INCREMENT,
	emp_no INT NOT NULL,
	salary INT NOT NULL,
	from_date DATETIME,
	to_date DATETIME,
	FOREIGN KEY (emp_no) REFERENCES employees(emp_no) ON DELETE CASCADE ON UPDATE CASCADE
);


/*--------------------*//* INSERT *//*--------------------*/
INSERT INTO 
	employees(emp_no, birth_date, firstname, lastname, sex, hire_date)
VALUES
	(1, "1997-05-06", "Karl", "Jensen", "M", "2020-04-01"),
	(2, "41-07-31", "Søren", "Lauritsen", "M", "2020-05-01"),
	(3, "1940-09-15", "David", "Lassen", "M", "2020-06-01"),
	(4, "1964-07-05", "Martin", "Klausen", "M", "2020-07-01"),
	(5, "1951-08-04", "Trine", "Svendsen", "F", "2020-08-01"),
	(6, "1986-04-20", "Camilla", "Hermansen", "F", "2014-05-01");

INSERT INTO 
	departments(dept_no, dept_name)
VALUES 
	("A1", "ALPHA 1"),
	("A2", "ALPHA 2"),
	("B1", "BETA 1"),
	("B2", "BETA 2"),
	("O1", "OMEGA 1"),
	("O2", "OMEGA 2");
	
INSERT INTO 
	titles(emp_no, title, from_date, to_date)
VALUES	
	(1, "Owner", "1997-01-01", NULL),
	(2, "DEPT A1 Owner", "2000-01-01", "2030-01-01"),
	(3, "Marketing", "2010-01-01", "2025-01-01"),
	(4, "Programmer", "2010-01-01", "2025-01-01"),
	(5, "Programmer", "2010-01-01", "2025-01-01"),
	(6, "IT-SUPPORTER", "2010-01-01", "2025-01-01");

INSERT INTO
	salaries(emp_no, salary, from_date, to_date)
VALUES
	(1, 100000, "1997-01-01", NULL),
	(2, 50000, "2000-01-01", "2030-01-01"),
	(3, 25000, "2010-01-01", "2025-01-01"),
	(4, 30000, "2010-01-01", "2025-01-01"),
	(5, 30000, "2010-01-01", "2025-01-01"),
	(6, 20000, "2010-01-01", "2025-01-01");

INSERT INTO 
	dept_manager(dept_no, emp_no, from_date, to_date)
VALUES
	("A1", 2, "2000-01-01", "2030-01-01");

INSERT INTO
	dept_employees(dept_no, emp_no, from_date, to_date)
VALUES
	("A1", 3, "2010-01-01", "2025-01-01"),
	("A1", 4, "2010-01-01", "2025-01-01"),
	("A1", 5, "2010-01-01", "2025-01-01"),
	("A1", 6, "2010-01-01", "2025-01-01");


/*--------------------*//* VIEWS *//*--------------------*/

CREATE VIEW department_managers AS SELECT e.firstname, e.lastname, e.sex, dm.dept_no, d.dept_name, e.birth_date, e.hire_date FROM dept_manager dm LEFT JOIN employees e ON e.emp_no = dm.emp_no LEFT JOIN departments d ON dm.dept_no = d.dept_no;
/* select user who is in charge of department A1 */
/* SELECT * FROM `department_managers` WHERE dept_no = "A1" */

CREATE VIEW salary_list AS SELECT e.firstname, e.lastname, e.sex, s.salary, e.birth_date, e.hire_date FROM salaries s LEFT JOIN employees e ON e.emp_no = s.emp_no;
/* select ervyone who earns more then 28000 */
/* SELECT * FROM `salary_list` WHERE salary > 28000 */



/*--------------------*//* Stored PROCEDURE *//*--------------------*/
DELIMITER //
CREATE PROCEDURE getDepartmentOwner(IN departmentChar CHAR(4))
BEGIN
	SELECT 
		e.firstname, 
		e.lastname, 
		e.sex, 
		dm.dept_no, 
		d.dept_name, 
		e.birth_date, 
		e.hire_date 
	FROM dept_manager dm 
	LEFT JOIN employees e ON e.emp_no = dm.emp_no 
	LEFT JOIN departments d ON dm.dept_no = d.dept_no
	WHERE dm.dept_no = departmentChar;
END //
DELIMITER ;

/* To get the owner of an department */
/* CALL getDepartmentOwner("A1"); */

DELIMITER //
CREATE PROCEDURE setEmployeeTitle(IN employeeID INT, IN newTitle VARCHAR(50))
BEGIN
	DELETE FROM titles WHERE emp_no = employeeID;
	INSERT INTO titles(emp_no, title, from_date, to_date) VALUES (employeeID, newTitle, NOW(), NULL);
END //
DELIMITER ;

/* to change the title of an employee */
/* CALL setEmployeeTitle(1, "New Owner"); */

DELIMITER //
CREATE PROCEDURE setEmployeeSalary(IN employeeID INT, IN newSalary INT)
BEGIN
	DELETE FROM salaries WHERE emp_no = employeeID;
	INSERT INTO salaries(emp_no, salary, from_date, to_date) VALUES (employeeID, newSalary, NOW(), NULL);
END //
DELIMITER ;

/* to change the salary of an employee, if they get a raise */
/* CALL setEmployeeSalary(1, 1000000); */


DELIMITER //
CREATE PROCEDURE setEmployeeDepartment(IN employeeID INT, IN newDepartment CHAR(4))
BEGIN
	DELETE FROM salaries WHERE emp_no = employeeID;
	INSERT INTO dept_employees(dept_no, emp_no, from_date, to_date) VALUES (newDepartment, employeeID, NOW(), NULL);
END //
DELIMITER ;

/* If an employee wants to change department */
/* CALL setEmployeeDepartment(6, "A2"); */

DELIMITER //
CREATE PROCEDURE setDepartmentManager(IN employeeID INT, IN newDepartment CHAR(4))
BEGIN
	DELETE FROM dept_manager WHERE emp_no = employeeID;
	INSERT INTO dept_manager(dept_no, emp_no, from_date, to_date) VALUES (newDepartment, employeeID, NOW(), NULL);
END //
DELIMITER ;

/* If the department needs a new manager */
/* CALL setDepartmentManager(1, "A2"); */




