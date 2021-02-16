/*--------------------*//* Create the database *//*--------------------*/
CREATE DATABASE IF NOT EXISTS triggerDB;
USE triggerDB;

/*--------------------*//* Create the tables needed *//*--------------------*/

CREATE TABLE persons(
 id INT PRIMARY KEY AUTO_INCREMENT,
 name TEXT NOT NULL,
 age INT NOT NULL,
 date_upd DATETIME DEFAULT CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP(),
 date_add DATETIME DEFAULT CURRENT_TIMESTAMP()
);

CREATE TABLE cars (
 id INT PRIMARY KEY AUTO_INCREMENT,
 brand VARCHAR(50) NOT NULL,
 color VARCHAR(50) NOT NULL,
 license_plate CHAR(7) UNIQUE NOT NULL,
 owner_id INT,
 date_upd DATETIME DEFAULT CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP(),
 date_add DATETIME DEFAULT CURRENT_TIMESTAMP(),
 FOREIGN KEY (owner_id) REFERENCES persons(id) ON DELETE SET NULL
);


/*--------------------*//* SELECT *//*--------------------*/

INSERT INTO persons (name, age) VALUES ("John", 34);
UPDATE persons SET name = "Igor"; 

/* date_upd blev osgå opdateret fordi vi har en "ON UPDATE" som sætter date_upd til den nyeste timestamp */
/* og date_add er kun sat til at få CURRENT_TIMESTAMP når den bliver oprettet men ikke opdateret */
/* SELECT * FROM foo; */

INSERT INTO cars (brand, color, license_plate, owner_id) VALUES ("Ford Fiesta", "Red", "HG30202", 1); 
/* Nu har vi sat bil'en til at have Igor som owner */
/* Hvis vi sletter Igor så bliver bilens owner til null */

DELETE FROM persons WHERE name = "Igor";
/* Nu har bilen ingen ejer */

INSERT INTO persons (name, age) VALUES ("John", 34);
UPDATE cars SET owner_id = (SELECT id FROM persons WHERE name = "John") WHERE license_plate = "HG30202";
/* Nu har bilen fået en ny ejer som heedder John */


CREATE TRIGGER 
	new_car AFTER INSERT ON persons
FOR EACH ROW 
	INSERT INTO 
		cars 
			(brand, color, license_plate, owner_id) 
		VALUES 
			("Tesla Model 3", "White", UPPER(SUBSTRING(MD5(NEW.id), 1, 7)), NEW.id);
/* Her laver vi en trigger som gør hvis der kommer en ny person ind i databsen så får den en bil tildelt*/
/* De får en Telsa Model 3 som er hvid */
/* Den måde jeg generer bilens unikke nummerplade på er at hashe personen's id og derefter tager jeg de første 7 characters og bruger dem som nummerplade. */

INSERT INTO 
	persons (name, age) 
VALUES 
	("Jack", 20),
	("Jill", 19),
	("Paul", 34);
	

/*
*	Når der bliver insat en ny person inde i persons tabellen så får han alle biler som ikke har en ejer
* 	Og bilen bliver lavet om til en Volvor istedet for det den var før.
*/
DELIMITER //
CREATE PROCEDURE stealAllUnOwnedCars(IN PersonID INT)
BEGIN
	UPDATE cars SET owner_id = PersonID WHERE owner_id IS NULL;
END //
DELIMITER ;

DELIMITER //
CREATE TRIGGER 
	stealAllUnOwnedCars AFTER INSERT ON persons
FOR EACH ROW BEGIN 
	UPDATE cars SET brand = "Volvo" WHERE owner_id IS NULL;
	CALL stealAllUnOwnedCars(NEW.id);
END //
DELIMITER ;


