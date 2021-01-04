# Computer Teknologi

## Connection Problem
If it cant connect to a database it asks you for the new database information and will automatically setup the tables.<br>
![10](https://github.com/MercantecData/portfolio-Magvib/blob/master/Computer%20Teknologi/pic/10.png)
![11](https://github.com/MercantecData/portfolio-Magvib/blob/master/Computer%20Teknologi/pic/11.png)

## Start Menu
Here we have the main menu.<br>
![1](https://github.com/MercantecData/portfolio-Magvib/blob/master/Computer%20Teknologi/pic/1.png)

## Create User
Here we have the create user function, it checks if the username is allready taken and if the password match.<br>
![2](https://github.com/MercantecData/portfolio-Magvib/blob/master/Computer%20Teknologi/pic/2.png)

## User List
Here we have a list og all the users to login with.<br>
![3](https://github.com/MercantecData/portfolio-Magvib/blob/master/Computer%20Teknologi/pic/3.png)

## Login
Here we have the login screen where you have to type in the password for the user.<br>
![4](https://github.com/MercantecData/portfolio-Magvib/blob/master/Computer%20Teknologi/pic/4.png)

## Ebay Menu
When you are logged in you com to this menu where you can create delete, buy, sell products.<br>
![5](https://github.com/MercantecData/portfolio-Magvib/blob/master/Computer%20Teknologi/pic/5.png)

## Buy Product
Here is a list over all the products that isn't sold.<br>
![6](https://github.com/MercantecData/portfolio-Magvib/blob/master/Computer%20Teknologi/pic/6.png)

## Sell Product
Here you can create a product.<br>
![7](https://github.com/MercantecData/portfolio-Magvib/blob/master/Computer%20Teknologi/pic/7.png)

## Delete Product
Here you can delete a product but your user have to be the creator for the product to delete it.<br>
![8](https://github.com/MercantecData/portfolio-Magvib/blob/master/Computer%20Teknologi/pic/8.png)

## Bought Products
Here you can see all the products you have bought.<br>
![9](https://github.com/MercantecData/portfolio-Magvib/blob/master/Computer%20Teknologi/pic/9.png)

## Users table
`id` | name | password
--- | --- | ---
`1` | Mads | password1234
`2` | Guest | 123456

## Products table
`id` | name | price
--- | --- | ---
`1` | Coca Cola | 10
`2` | Scone | 6

## Orders table
`id` | `seller_id` | `product_id` | `buyer_id`
--- | --- | --- | ---
`1` | `1` | `2` | `null`
`2` | `2` | `1` | `1`

## Database Code
Here is the code for the database
```mysql
CREATE DATABASE IF NOT EXISTS csharp;

CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE IF NOT EXISTS `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `price` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE IF NOT EXISTS `orders` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `seller_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `buyer_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `seller_id` (`seller_id`),
  KEY `product_id` (`product_id`),
  KEY `buyer_id` (`buyer_id`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`seller_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `orders_ibfk_3` FOREIGN KEY (`buyer_id`) REFERENCES `users` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
);
```
