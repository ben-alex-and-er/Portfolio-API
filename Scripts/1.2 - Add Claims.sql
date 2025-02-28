CREATE TABLE IF NOT EXISTS `user`.`claim_type`(
	`id` INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `type` VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE IF NOT EXISTS `user`.`claim_value`(
	`id` INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `value` VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE IF NOT EXISTS `user`.`claim`(
	`id` INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `claim_type_id` INT UNSIGNED NOT NULL,
    `claim_value_id` INT UNSIGNED NOT NULL,
    `guid` CHAR(36) UNIQUE NOT NULL,
    CONSTRAINT claim_claim_type_id FOREIGN KEY (`claim_type_id`) REFERENCES `user`.`claim_type`(`id`),
    CONSTRAINT claim_claim_value_id FOREIGN KEY (`claim_value_id`) REFERENCES `user`.`claim_value`(`id`)
);

CREATE TABLE IF NOT EXISTS `user`.`role_claim`(
	`id` INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `role_id` INT UNSIGNED NOT NULL,
    `claim_id` INT UNSIGNED NOT NULL,
    CONSTRAINT role_claim_role_id FOREIGN KEY (`role_id`) REFERENCES `user`.`role`(`id`),
    CONSTRAINT role_claim_claim_id FOREIGN KEY (`claim_id`) REFERENCES `user`.`claim`(`id`)
);