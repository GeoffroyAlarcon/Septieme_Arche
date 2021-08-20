﻿-- MySQL Workbench Synchronization
-- Generated: 2021-05-02 19:03

CREATE SCHEMA IF NOT EXISTS `septiemeArche` DEFAULT CHARACTER SET utf8 ;
use `septiemeArche` ;

drop table if exists client_has_livraisonAdresse;
drop table IF EXISTS client_has_facturationAdresse;
DROP TABLE  IF EXISTS CLIENT;
drop table  IF EXISTS genrelivre;
drop TABLE IF EXISTS livre_has_genreLivre;
drop table  IF EXISTS livre_has_auteur;
drop table  IF EXISTS livres_numerique;
drop table  IF EXISTS auteurs;
drop table  IF EXISTS livres;
drop  table  IF EXISTS articles;
drop  table IF EXISTS genresLivre;

drop table if exists Types;
create table types (
id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
Libelle varchar(200) Not null,
description TEXT not Null,
dateUpdate datetime  DEFAULT  NOW()
)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


DROP TABLE IF EXISTS articles;
CREATE TABLE articles (
id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
  nom VARCHAR(100) NULL,
  prix_Ht FLOAT NOT NULL,
    quantite INT null,
AjoutArticledate Datetime DEFAULT  NOW(),
  URLImage VARCHAR(250) NULL,
  nombreConsultation INT null,
  nombreVendu INT null,
  typesId int not null,
  CONSTRAINT fk_typesiD FOREIGN KEY (typesId) REFERENCES types(id) ON DELETE CASCADE

)
ENGINE = InnoDB 
DEFAULT CHARACTER SET = utf8;

DROP TABLE IF EXISTS livres;
CREATE TABLE livres (
  ISBN VARCHAR(13) PRIMARY KEY NOT NULL unique,
titre varchar(250) not null,
description text not null,
poids VARCHAR(45) NULL,
  dimension VARCHAR(45) NULL,
  editeur VARCHAR(100) not NULL ,
  parutionDate  Date NULL ,
  pagesNombre int NOT NULL ,
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








DROP TABLE IF EXISTS compte_utilisateur;
CREATE TABLE compte_utilisateur (
id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
  nom VARCHAR(100) NOT NULL,
  prenom VARCHAR(100) NOT NULL,
  email VARCHAR(255) UNIQUE NOT NULL,
  password VARCHAR(78) NOT NULL 
  )
ENGINE = InnoDB 
DEFAULT CHARACTER SET = utf8;




DROP TABLE  IF EXISTS CLIENT; 
CREATE TABLE Client (
  `id` INT(11) PRIMARY KEY NOT NULL AUTO_INCREMENT,
naissanceDate date Not null,
  `compte_utilisateurId` INT NOT NULL,
 FOREIGN KEY (compte_utilisateurId) REFERENCES compte_utilisateur(id) ON DELETE CASCADE

)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


drop table if exists Adresse;
create table Adresse (
id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
CodePostal varchar(20) NOT NULL,
Voie varchar(250) NOT NULL,
VoieNumero varchar(10)  NULL,
ville varchar(150) NOT NULL ,
pays varchar (10) NOT NULL,
TelephoneNumero varchar(20) NOT NULL,
batimentType varchar(100) NOT NULL,
appartementNumero varchar(5)  NULL,
interphoneNumero varchar(20) NULL

)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


drop table if exists client_has_livraisonAdresse;
create table client_has_livraisonAdresse (
 `id` INT(11) PRIMARY KEY NOT NULL AUTO_INCREMENT,
 clientId int(11) not null,
 adresseLivraisonId int(11) not null,
  FOREIGN KEY (clientId) REFERENCES client(id) ON DELETE CASCADE,
  FOREIGN KEY (adresseLivraisonId) REFERENCES adresse(id) ON DELETE CASCADE

)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


drop table if exists client_has_facturationAdresse;
create table client_has_facturationAdresse (
 `id` INT(11) PRIMARY KEY NOT NULL AUTO_INCREMENT,
 clientId int(11) not null,
 adresseFacturationId int(11) not null,
  FOREIGN KEY (clientId) REFERENCES client(id) ON DELETE CASCADE,
  FOREIGN KEY (adresseFacturationId) REFERENCES adresse(id) ON DELETE CASCADE

)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;



