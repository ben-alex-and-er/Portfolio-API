CREATE SCHEMA IF NOT EXISTS `user`;


CREATE TABLE IF NOT EXISTS `user`.`user`(
	`id` INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `identifier` VARCHAR(750) NOT NULL
);

CREATE TABLE IF NOT EXISTS `user`.`password`(
	`id` INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `hash` VARCHAR(750) NOT NULL
);

CREATE TABLE IF NOT EXISTS `user`.`user_password`(
	`id` INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `user_id` INT UNSIGNED NOT NULL,
    `password_id` INT UNSIGNED NOT NULL,
    CONSTRAINT user_password_user_id FOREIGN KEY (`user_id`) REFERENCES `user`.`user`(`id`),
    CONSTRAINT user_password_password_id FOREIGN KEY (`password_id`) REFERENCES `user`.`password`(`id`)
);