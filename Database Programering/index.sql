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