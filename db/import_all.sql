USE board_game_store;
SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

LOAD DATA LOCAL INFILE 'C:/csv/categories.csv'
INTO TABLE categories
CHARACTER SET utf8mb4
FIELDS TERMINATED BY ';'
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
IGNORE 1 LINES
(category_id, category_name, description);

LOAD DATA LOCAL INFILE 'C:/csv/users.csv'
INTO TABLE users
CHARACTER SET utf8mb4
FIELDS TERMINATED BY ';'
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
IGNORE 1 LINES
(user_id, full_name, login, password_hash, role, phone, registration_date);

LOAD DATA LOCAL INFILE 'C:/csv/customers.csv'
INTO TABLE customers
CHARACTER SET utf8mb4
FIELDS TERMINATED BY ';'
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
IGNORE 1 LINES
(customer_id, full_name, phone);

LOAD DATA LOCAL INFILE 'C:/csv/board_games.csv'
INTO TABLE board_games
CHARACTER SET utf8mb4
FIELDS TERMINATED BY ';'
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
IGNORE 1 LINES
(game_id, category_id, title, description, price, stock_quantity,
 min_players, max_players, age_rating, image);

LOAD DATA LOCAL INFILE 'C:/csv/orders.csv'
INTO TABLE orders
CHARACTER SET utf8mb4
FIELDS TERMINATED BY ';'
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
IGNORE 1 LINES
(order_id, customer_id, user_id, status_id, order_date, completion_date,
 discount, total_without_discount, total_with_discount, total_amount,
 shipping_address);

LOAD DATA LOCAL INFILE 'C:/csv/order_items.csv'
INTO TABLE order_items
CHARACTER SET utf8mb4
FIELDS TERMINATED BY ';'
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
IGNORE 1 LINES
(order_item_id, order_id, game_id, quantity, unit_price);

SET FOREIGN_KEY_CHECKS = 1;

SELECT 'categories'  AS t, COUNT(*) AS cnt FROM categories
UNION ALL SELECT 'users',       COUNT(*) FROM users
UNION ALL SELECT 'customers',   COUNT(*) FROM customers
UNION ALL SELECT 'statuses',    COUNT(*) FROM statuses
UNION ALL SELECT 'board_games', COUNT(*) FROM board_games
UNION ALL SELECT 'orders',      COUNT(*) FROM orders
UNION ALL SELECT 'order_items', COUNT(*) FROM order_items;