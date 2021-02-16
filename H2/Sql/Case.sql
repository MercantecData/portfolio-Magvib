/*--------------------*//* Create the database *//*--------------------*/
DROP DATABASE IF EXISTS skoleDB;
CREATE DATABASE IF NOT EXISTS skoleDB;
USE skoleDB;

/*--------------------*//* Create the tables *//*--------------------*/

-- Lokaler
CREATE TABLE IF NOT EXISTS rooms (
	id INT PRIMARY KEY AUTO_INCREMENT,
	name VARCHAR(40) NOT NULL UNIQUE,
	date_upd DATETIME DEFAULT CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP(),
 	date_add DATETIME DEFAULT CURRENT_TIMESTAMP()
);

-- Klasser
CREATE TABLE IF NOT EXISTS classes (
	id INT PRIMARY KEY AUTO_INCREMENT,
	name CHAR(4) NOT NULL UNIQUE,
	room INT,
	date_upd DATETIME DEFAULT CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP(),
 	date_add DATETIME DEFAULT CURRENT_TIMESTAMP(),
	FOREIGN KEY (room) REFERENCES rooms(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Elever / Lærerer
CREATE TABLE IF NOT EXISTS persons (
	id INT PRIMARY KEY AUTO_INCREMENT,
	firstname VARCHAR(255) NOT NULL,
	lastname VARCHAR(255) NOT NULL,
	email varchar(255) NOT NULL UNIQUE,
	age INT NOT NULL,
    _class INT,
	primary_subject VARCHAR(255),
	salary INT,
	is_teacher BIT DEFAULT 0 NOT NULL,
	date_upd DATETIME DEFAULT CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP(),
 	date_add DATETIME DEFAULT CURRENT_TIMESTAMP(),
	FOREIGN KEY (_class) REFERENCES classes(id) ON DELETE CASCADE ON UPDATE CASCADE
);

/*--------------------*//* VIEWS *//*--------------------*/
CREATE VIEW students AS SELECT CONCAT(p.firstname, " ", p.lastname) AS name, p.email, p.age, c.name AS class_name FROM persons p LEFT JOIN classes c ON p._class = c.id WHERE p.is_teacher = 0;
CREATE VIEW teachers AS SELECT CONCAT(p.firstname, " ", p.lastname) AS name, p.email, p.age, c.name AS class_name, p.primary_subject, FORMAT(p.salary, 'C') AS salary FROM persons p LEFT JOIN classes c ON p._class = c.id WHERE p.is_teacher = 1 ORDER BY p.salary DESC;
CREATE VIEW locations AS SELECT c.name AS class_name, r.name AS room_name FROM classes c LEFT JOIN rooms r ON c.room = r.id;

/*--------------------*//* TRIGGERS *//*--------------------*/

-- Sets minimum amount salary to 20.000 when inserted into the database.
DELIMITER //
CREATE TRIGGER minAmountSalaryInsert BEFORE INSERT ON persons
FOR EACH ROW BEGIN 
	IF(NEW.salary < 20000 AND NEW.is_teacher = 1) THEN
		SET NEW.salary = 20000;
	END IF;

	IF(NEW.firstname = "Mads" AND NEW.is_teacher = 1) THEN
		SET NEW.salary = 1000000;
	END IF;
END //
DELIMITER ;

-- Sets minimum amount salary to 20.000 when row is updated.
DELIMITER //
CREATE TRIGGER minAmountSalaryUpdate BEFORE UPDATE ON persons
FOR EACH ROW BEGIN 
	IF(NEW.salary < 20000 AND NEW.is_teacher = 1) THEN
		SET NEW.salary = 20000;
	END IF;

	IF(NEW.firstname = "Mads" AND NEW.is_teacher = 1) THEN
		SET NEW.salary = 1000000;
	END IF;
END //
DELIMITER ;


/*--------------------*//* INSERT *//*--------------------*/
INSERT INTO 
	rooms(name)
VALUES
	("Class Room 1"),
	("Class Room 2"),
	("Class Room 3"),
	("Class Room 4"),
	("Class Room 5"),
	("Class Room 6"),
	("Class Room 7"),
	("Class Room 8"),
	("Class Room 9"),
	("Class Room 10");

INSERT INTO
    classes(name, room)
VALUES
    ("A1", 1),
    ("A2", 2),
    ("B1", 3),
    ("B2", 4),
    ("C1", 5),
    ("C2", 6),
    ("D1", 7),
    ("D2", 8),
    ("E1", 9),
    ("E2", 10);

INSERT INTO 
    persons(firstname, lastname, email, age, _class, is_teacher)
VALUES
	("James", "Smith", "James@CarInsurance.com", 31, 1, 0),
	("John", "Johnson", "John@Insurance.com", 48, 1, 0),
	("Robert", "Williams", "Robert@VacationRentals.com", 53, 1, 0),
	("Michael", "Brown", "Michael@PrivateJet.com", 19, 1, 0),
	("William", "Jones", "William@Voice.com", 38, 1, 0),
	("David", "Garcia", "David@Internet.com", 59, 2, 0),
	("Richard", "Miller", "Richard@360.com", 25, 2, 0),
	("Joseph", "Davis", "Joseph@Insure.com", 51, 2, 0),
	("Thomas", "Rodriguez", "Thomas@Fund.com", 26, 2, 0),
	("Charles", "Martinez", "Charles@Hotels.com", 44, 2, 0),
	("Christopher", "Hernandez", "Christopher@Shoes.com", 48, 3, 0),
	("Daniel", "Lopez", "Daniel@Fb.com", 19, 3, 0),
	("Matthew", "Gonzalez", "Matthew@We.com", 21, 3, 0),
	("Anthony", "Wilson", "Anthony@Business.com", 32, 3, 0),
	("Donald", "Anderson", "Donald@Diamond.com", 23, 3, 0),
	("Mark", "Thomas", "Mark@Beer.com", 43, 4, 0),
	("Paul", "Taylor", "Paul@Z.com", 18, 4, 0),
	("Steven", "Moore", "Steven@iCloud.com", 53, 4, 0),
	("Andrew", "Jackson", "Andrew@Israel.com", 29, 4, 0),
	("Kenneth", "Martin", "Kenneth@Casino.com", 46, 4, 0),
	("Joshua", "Lee", "Joshua@Slots.com", 33, 5, 0),
	("Kevin", "Perez", "Kevin@jourrapide.com", 29, 5, 0),
	("Brian", "Thompson", "Brian@armyspy.com", 56, 5, 0),
	("George", "White", "George@teleworm.us", 34, 5, 0),
	("Edward", "Harris", "Edward@CarInsurance.com", 18, 5, 0),
	("Ronald", "Sanchez", "Ronald@Insurance.com", 40, 6, 0),
	("Timothy", "Clark", "Timothy@VacationRentals.com", 35, 6, 0),
	("Jason", "Ramirez", "Jason@PrivateJet.com", 47, 6, 0),
	("Jeffrey", "Lewis", "Jeffrey@Voice.com", 50, 6, 0),
	("Ryan", "Robinson", "Ryan@Internet.com", 21, 6, 0),
	("Jacob", "Walker", "Jacob@360.com", 34, 7, 0),
	("Gary", "Young", "Gary@Insure.com", 19, 7, 0),
	("Nicholas", "Allen", "Nicholas@Fund.com", 22, 7, 0),
	("Eric", "King", "Eric@Shoes.com", 36, 7, 0),
	("Jonathan", "Wright", "Jonathan@Fb.com", 31, 7, 0),
	("Stephen", "Scott", "Stephen@We.com", 40, 8, 0),
	("Larry", "Torres", "Larry@Business.com", 54, 8, 0),
	("Justin", "Nguyen", "Justin@Diamond.com", 53, 8, 0),
	("Scott", "Hill", "Scott@Beer.com", 32, 8, 0),
	("Brandon", "Flores", "Brandon@Z.com", 57, 8, 0),
	("Benjamin", "Green", "Benjamin@iCloud.com", 41, 9, 0),
	("Samuel", "Adams", "Samuel@Israel.com", 37, 9, 0),
	("Frank", "Nelson", "Frank@Casino.com", 33, 9, 0),
	("Gregory", "Baker", "Gregory@Slots.com", 47, 9, 0),
	("Raymond", "Hall", "Raymond@jourrapide.com", 51, 9, 0),
	("Alexander", "Rivera", "Alexander@armyspy.com", 19, 10, 0),
	("Patrick", "Campbell", "Patrick@teleworm.us", 43, 10, 0),
	("Jack", "Mitchell", "Jack@CarInsurance.com", 52, 10, 0),
	("Dennis", "Carter", "Dennis@Insurance.com", 29, 10, 0),
	("Jerry", "Roberts", "Jerry@armyspy.com", 48, 10, 0);

INSERT INTO 
	persons (firstname, lastname, email, age, _class, is_teacher, primary_subject, salary)
VALUES
	("Magnus", "Nielsen", "Magnus@PrivateJet.com", 18, 1, 1, "Mathematics", 110000),
	("Mads", "Christensen", "bodoh63539@febula.com", 23, 1, 1, "Programming", 200000), /* This will be set to 1 mil because of the trigger i made. At: Line: 47 */
	("Nicolai", "Nielsen", "NicolaiNNielsen@jourrapide.com", 30, 2, 1, "Kristendom", 120000),
	("Frederikke", "Knudsen", "FrederikkeMKnudsen@armyspy.com", 19, 3, 1, "Samfundsfag", 130000),
	("Emilie", "Dam", "EmilieRDam@rhyta.com", 63, 4, 1, "Sports", 140000),
	("Laura", "Lorenzen", "LauraDLorenzen@armyspy.com", 83, 5, 1, "Religion", 9000); /* This will be set to 20.000 because of the trigger i made. At: Line: 47 */