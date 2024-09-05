
create database ecommerce;
use ecommerce;


CREATE TABLE User (
    email VARCHAR(255) NOT NULL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    adress VARCHAR(255) NOT NULL,
    money FLOAT DEFAULT 1000.0,
    isAdm BOOLEAN DEFAULT FALSE
);

CREATE TABLE Purchase (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    value FLOAT DEFAULT 0.0,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    fk_user_email VARCHAR(255) NOT NULL,
    FOREIGN KEY (fk_user_email) REFERENCES User(email)
);

CREATE TABLE Product (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    price FLOAT NOT NULL,
    description TEXT NOT NULL,
    fk_user_email VARCHAR(255) NOT NULL,
    FOREIGN KEY (fk_user_email) REFERENCES User(email)
);

CREATE TABLE Product_Purchase (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    fk_product_id INT NOT NULL,
    fk_purchase_id INT NOT NULL,
    FOREIGN KEY (fk_product_id) REFERENCES Product(id),
    FOREIGN KEY (fk_purchase_id) REFERENCES Purchase(id)
);

select * from product;
