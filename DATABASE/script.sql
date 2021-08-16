-- MySQL Workbench Synchronization
-- Generated: 2021-05-02 19:03
-- Model: New Model
-- Version: 1.0
-- Project: SeptièmeArche
-- Author: Geoffroy

CREATE SCHEMA IF NOT EXISTS `septiemeArche` DEFAULT CHARACTER SET utf8 ;
use `septiemeArche` ;
DROP TABLE  IF EXISTS CLIENT;
drop table  IF EXISTS genrelivre;
drop TABLE IF EXISTS livre_has_genreLivre;
drop table  IF EXISTS livre_has_auteur;
drop table  IF EXISTS livres_numerique;
drop table  IF EXISTS auteurs;
drop table  IF EXISTS livres;
drop  table  IF EXISTS articles;
drop  table IF EXISTS genresLivre;



DROP TABLE IF EXISTS compte_utilisateur;
CREATE TABLE`septiemeArche`.`compte_utilisateur` (
id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
  nom VARCHAR(100) NOT NULL,
  prenom VARCHAR(100) NOT NULL,
  email VARCHAR(255) UNIQUE NOT NULL,
  password VARCHAR(78) NOT NULL 
  )
ENGINE = InnoDB 
DEFAULT CHARACTER SET = utf8;


DROP TABLE IF EXISTS articles;
CREATE TABLE articles (
id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
  nom VARCHAR(100) NULL,
  prix_ht FLOAT NOT NULL,
dateAjoutArticle Datetime DEFAULT  NOW(),
  URLImage VARCHAR(250) NULL,
  quantite INT null,
  nombreConsultation INT null,
  nombreVendu INT null
)
ENGINE = InnoDB 
DEFAULT CHARACTER SET = utf8;

DROP TABLE IF EXISTS livres;
CREATE TABLE livres (
  ISBN VARCHAR(13) PRIMARY KEY NOT NULL unique,
titre varchar(250) not null,
resume text not null,
poids VARCHAR(45) NULL,
  dimension VARCHAR(45) NULL,
  editeur VARCHAR(100) not NULL ,
  date_parution  Date NULL ,
  nombre_page INT NOT NULL ,
estNumerique tinyint not null default 0,
ArticleID int NOT NULL,
 CONSTRAINT fk_livres_articles FOREIGN KEY (ArticleID) REFERENCES articles(id) ON DELETE CASCADE

)ENGINE = InnoDB 
DEFAULT CHARACTER SET = utf8;


drop TABLE if EXISTS livres_numerique;
CREATE TABLE livres_numerique(
id int PRIMARY KEY NOT NULL AUTO_INCREMENT,
ISBN varchar(13) not null,
DRM varchar(100) not null,
format varchar(200) not null,
FOREIGN KEY (ISBN) REFERENCES livres(ISBN) ON DELETE CASCADE
)
ENGINE = InnoDB 
DEFAULT CHARACTER SET = utf8;


DROP TABLE IF EXISTS  auteurs;
CREATE TABLE auteurs(
 id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
  nom VARCHAR(45) NULL,
  prenom VARCHAR(45) NULL,
  description VARCHAR(1000) null
)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


DROP TABLE IF EXISTS livre_has_auteur;
CREATE TABLE livre_has_auteur (
id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
  ISBN VARCHAR(13) NOT NULL,
  auteurId INT NOT NULL,
FOREIGN KEY ( ISBN) REFERENCES livres(ISBN) ON DELETE CASCADE,
FOREIGN KEY ( auteurId) REFERENCES auteurs(id) ON DELETE CASCADE
)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

DROP TABLE IF EXISTS  genresLivre;
CREATE TABLE genresLivre(
 id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
  libelle VARCHAR(250) NULL
)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;



DROP TABLE IF EXISTS livre_has_genreLivre;
CREATE TABLE livre_has_genreLivre (
id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
  ISBN VARCHAR(13) NOT NULL,
  genreLivreId  int NOT NULL,
FOREIGN KEY (ISBN) REFERENCES livres(ISBN) ON DELETE CASCADE,
FOREIGN KEY (genreLivreId) REFERENCES genresLivre(id) ON DELETE CASCADE
)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;





DROP TABLE  IF EXISTS CLIENT; 
CREATE TABLE Client (
  `idClient` INT(11) PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NULL DEFAULT NULL,	
  `prenom` VARCHAR(45) NULL DEFAULT NULL,
  `compte_utilisateurId` INT NOT NULL,
 FOREIGN KEY (compte_utilisateurId) REFERENCES compte_utilisateur(id) ON DELETE CASCADE

)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;



