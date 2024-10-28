-- Drop existing database and create a new one
DROP DATABASE IF EXISTS food_db;
CREATE DATABASE food_db;
USE food_db;

-- Create categories table


-- Create foods table with categoryId as a foreign key
CREATE TABLE `foods` (
   `Id` INT NOT NULL AUTO_INCREMENT,
   `Name` VARCHAR(100) NOT NULL,
   `Description` VARCHAR(255) DEFAULT NULL,
   `Price` DECIMAL(10,2) NOT NULL,
   `ImageUrl` VARCHAR(255) DEFAULT NULL,
   `category` varchar(255),
   PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Create users table
CREATE TABLE `users` (
   `id` INT NOT NULL AUTO_INCREMENT,
   `username` VARCHAR(255) DEFAULT NULL,
   `password` VARCHAR(255) DEFAULT NULL,
   `email` VARCHAR(255) DEFAULT NULL,
   PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



-- Insert data into foods table with categoryId
INSERT INTO `foods` (Name, Description, Price, ImageUrl, Category) VALUES 
('Pizza', 'Delicious cheese pizza with fresh toppings', 12.99, 'https://upload.wikimedia.org/wikipedia/commons/b/bb/Pizza_Vi%E1%BB%87t_Nam_%C4%91%E1%BA%BF_d%C3%A0y%2C_x%C3%BAc_x%C3%ADch_%28SNaT_2018%29_%287%29.jpg', 'FastFood'),
('Burger', 'Juicy beef burger with lettuce and tomato', 9.99, 'https://t2.gstatic.com/licensed-image?q=tbn:ANd9GcRRto3IlY56MlAIOAvXHvPEVxBDVzG1uz1zULEBYdJ-I4Aa-xOyPEVvv7fmIjLnxaOz', 'FastFood'),
('Sushi', 'Fresh sushi rolls with a variety of fillings', 15.99, 'https://sushiworld.com.vn/wp-content/uploads/2023/11/c.jpg', 'MainDish'),
('Ice Cream', 'Creamy vanilla ice cream with chocolate sauce', 4.99, 'https://cdn.britannica.com/50/80550-050-5D392AC7/Scoops-kinds-ice-cream.jpg', 'Dessert');

-- Insert data into users table
INSERT INTO `users` (username, email, password) VALUES 
('Khoa', 'khoa@gmail.com', '1234');

-- Select data to verify insertions

SELECT * FROM foods;
SELECT * FROM users;
