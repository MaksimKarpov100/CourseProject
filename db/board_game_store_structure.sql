DROP DATABASE IF EXISTS board_game_store;
CREATE DATABASE board_game_store
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;
USE board_game_store;

CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    login VARCHAR(32) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    role ENUM('Администратор','Товаровед','Продавец') NOT NULL,
    phone VARCHAR(20),
    registration_date DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE customers (
    customer_id INT AUTO_INCREMENT PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    phone VARCHAR(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE categories (
    category_id INT AUTO_INCREMENT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL UNIQUE,
    description TEXT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE statuses (
    status_id INT AUTO_INCREMENT PRIMARY KEY,
    status_name VARCHAR(50) NOT NULL UNIQUE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE board_games (
    game_id INT AUTO_INCREMENT PRIMARY KEY,
    category_id INT,
    title VARCHAR(200) NOT NULL,
    description TEXT,
    price DECIMAL(10,2) NOT NULL CHECK (price >= 0 AND price <= 10000),
    stock_quantity INT NOT NULL DEFAULT 0 CHECK (stock_quantity >= 0 AND stock_quantity <= 1000),
    min_players INT,
    max_players INT,
    age_rating VARCHAR(10),
    image VARCHAR(255),
    CONSTRAINT fk_game_category FOREIGN KEY (category_id)
        REFERENCES categories(category_id) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE orders (
    order_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    user_id INT NOT NULL,
    status_id INT NOT NULL,
    order_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    completion_date DATETIME NULL,
    discount DECIMAL(5,2) DEFAULT 0.00 CHECK (discount BETWEEN 0 AND 100),
    total_without_discount DECIMAL(10,2) DEFAULT 0.00,
    total_with_discount DECIMAL(10,2) DEFAULT 0.00,
    total_amount DECIMAL(10,2) DEFAULT 0.00,
    shipping_address VARCHAR(255),
    CONSTRAINT fk_order_customer FOREIGN KEY (customer_id)
        REFERENCES customers(customer_id) ON DELETE RESTRICT,
    CONSTRAINT fk_order_user FOREIGN KEY (user_id)
        REFERENCES users(user_id) ON DELETE RESTRICT,
    CONSTRAINT fk_order_status FOREIGN KEY (status_id)
        REFERENCES statuses(status_id) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE order_items (
    order_item_id INT AUTO_INCREMENT PRIMARY KEY,
    order_id INT NOT NULL,
    game_id INT NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    unit_price DECIMAL(10,2) NOT NULL CHECK (unit_price >= 0),
    CONSTRAINT fk_item_order FOREIGN KEY (order_id)
        REFERENCES orders(order_id) ON DELETE CASCADE,
    CONSTRAINT fk_item_game FOREIGN KEY (game_id)
        REFERENCES board_games(game_id) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO statuses (status_name) VALUES
('Новый'), ('Не готов'), ('Готов'), ('Отменён');