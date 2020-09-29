CREATE DATABASE `gtracker-db` /*!40100 DEFAULT CHARACTER SET latin1 */;

CREATE TABLE Friend (
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(50) NOT NULL,
	phone varchar(50) NOT NULL,
	email varchar(50) NULL
)

CREATE TABLE `Friend` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `phone` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(50) COLLATE utf8_unicode_ci NOT NULL,  
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE `Game` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `dt_acquisition` datetime NOT NULL,
  `kind` int(11) NOT NULL,
  `observation` varchar(250) COLLATE utf8_unicode_ci NOT NULL,  
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE `SystemUser` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `active`tinyint NOT NULL,
  `login` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE `Loan` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `friend_id` int(11) NOT NULL,
  `dt_start` datetime NOT NULL,
  `observation` varchar(250) COLLATE utf8_unicode_ci NOT NULL,  
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_loan_friend` FOREIGN KEY (`friend_id`) REFERENCES `Friend` (`id`),
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE `LoanGame` (  
  `loan_id` int(11) NOT NULL,
  `game_id` int(11) NOT NULL,
  `loan_status` int(11) NOT NULL,
  `dt_end` datetime NULL,    
  UNIQUE KEY `index_loan_id_on_game_id` (`loan_id`,`game_id`),
  CONSTRAINT `fk_loan_lg` FOREIGN KEY (`friend_id`) REFERENCES `Friend` (`id`),
  CONSTRAINT `fk_game_lg` FOREIGN KEY (`game_id`) REFERENCES `Game` (`id`),
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

INSERT INTO `SystemUser` (`id`, `name`, `active`, `login`, `password`) VALUES (1,'ADMIN', 1, 'admin', N'10000.i0wt/ndvvw0/T/Kop2S99A==.Uv33Y1sHv+QO05qdqvbKEg3A9pGkQqhvTiB3BRf69BA=')
