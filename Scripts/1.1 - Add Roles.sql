CREATE TABLE IF NOT EXISTS `user`.`role`(
	`id` INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `role` VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE IF NOT EXISTS `user`.`user_role`(
	`id` INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `user_id` INT UNSIGNED NOT NULL,
    `role_id` INT UNSIGNED NOT NULL,
    CONSTRAINT user_role_user_id FOREIGN KEY (`user_id`) REFERENCES `user`.`user`(`id`),
    CONSTRAINT user_role_role_id FOREIGN KEY (`role_id`) REFERENCES `user`.`role`(`id`)
);