/*--------------------*//* Created the gamestore *//*--------------------*/
CREATE DATABASE IF NOT EXISTS gamestore;
USE gamestore;

/*--------------------*//* Create the tables needed *//*--------------------*/
CREATE TABLE IF NOT EXISTS store_location (
	id INT PRIMARY KEY AUTO_INCREMENT,
	name VARCHAR(255) NOT NULL,
	latitude DECIMAL(10, 8) NOT NULL,
	longitude DECIMAL(11, 8) NOT NULL
);

/*--------------------*//*--------------------*//*--------------------*/
CREATE TABLE IF NOT EXISTS items (
	id INT PRIMARY KEY AUTO_INCREMENT,
	name VARCHAR(255) NOT NULL,
	description VARCHAR(255) NOT NULL,
	price INT NOT NULL,
	release_date DATETIME NOT NULL
);

/*--------------------*//*--------------------*//*--------------------*/
CREATE TABLE IF NOT EXISTS physical_items (
	id INT PRIMARY KEY AUTO_INCREMENT,
	id_location INT NOT NULL,
	id_item INT NOT NULL,
	amount INT NOT NULL,
	FOREIGN KEY (id_item) REFERENCES items(id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (id_location) REFERENCES store_location(id) ON DELETE CASCADE ON UPDATE CASCADE
);

/*--------------------*//* Insert into the tables *//*--------------------*/
INSERT INTO 
	items(name, description, price, release_date) 
VALUES
	("Gaming Computer", "A brand new computer with the best components", 11250, "2020-01-18 13:23"),
	("Laptop Computer", "Can play minecraft but not tripple a games", 4599, "2019-08-05 16:35"),
	("Desktop Computer", "A brand new computer with the best components", 7999, "2016-01-18 15:00"),
	("Work Computer", "Slow but gets the job done", 3600, "2019-01-04 08:00"),
	("Iphone X", "Good but expensive", 9999, "2020-01-18 13:23");

/*--------------------*//*--------------------*//*--------------------*/
INSERT INTO 
	store_location(name, latitude, longitude) 
VALUES
	('Viborg', 56.452027, 9.396347),
	('Skive', 56.56381, 9.04025),
	('Aalborg', 57.048820, 9.921747),
	('København', 55.676098, 12.568337);
	
/*--------------------*//*--------------------*//*--------------------*/
INSERT INTO 
	physical_items(id_location, id_item, amount)
VALUES 
	(1, 1, 10),
	(1, 5, 3),
	(2, 4, 20),
	(2, 2, 15),
	(3, 1, 30),
	(3, 5, 20),
	(3, 3, 15),
	(4, 1, 50),
	(4, 2, 50),
	(4, 3, 50),
	(4, 4, 50),
	(4, 5, 50);
	

/*--------------------*//* Add to table And update items in table *//*--------------------*/
ALTER TABLE store_location
ADD COLUMN profit INT DEFAULT 0;

UPDATE store_location SET profit = 50000 WHERE name = "Viborg";
UPDATE store_location SET profit = 20000 WHERE name = "Skive";
UPDATE store_location SET profit = 80000 WHERE name = "Aalborg";
UPDATE store_location SET profit = 100000 WHERE name = "København";


/*--------------------*//* SELECT *//*--------------------*/
/* Gets all store_locations where profit is over 50.000 */
SELECT name, profit FROM store_location WHERE profit >= 50000;

/* Gets inventory_price for all the shops */
SET sql_mode = '';
SELECT
    store_location.name,
    store_location.latitude,
    store_location.longitude,
    store_location.profit,
    SUM(items.price * physical_items.amount) AS inventory_price
FROM
    physical_items
LEFT JOIN items ON items.id = physical_items.id_item
LEFT JOIN store_location ON store_location.id = physical_items.id_location
GROUP BY physical_items.id_location




