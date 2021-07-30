-- MySQL Workbench Synchronization
-- Generated: 2021-05-02 19:03
-- Model: New Model
-- Version: 1.0
-- Project: SeptièmeArche
-- Author: Geoffroy

CREATE SCHEMA IF NOT EXISTS `septiemeArche` DEFAULT CHARACTER SET utf8 ;
drop genrelivre;
drop table livre_has_genreLivre;
drop table livre_has_auteur;
drop table livres_numerique;
drop table auteurs;
drop table livres;
drop table articles;
drop table genresLivre;



DROP TABLE IF EXISTS compte_utilisateur;
CREATE TABLE`septiemeArche`.`compte_utilisateur` (
idcompte_utilisateur INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
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
  quantite INT not null,
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


drop TABLE if EXITS livres_numerique;
CREATE TABLE livres_numerique(
ISBN varchar(13) PRIMARY KEY unique,
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
FOREIGN KEY (genreLivreId) REFERENCES genreLivre(id) ON DELETE CASCADE
)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;








drop table if exists adminstrateurc

CREATE TABLE `septièmeArche`.`administrateur` (
  `idadmnistrateur` INT(11) NOT NULL,
  `privilège` INT(11) NULL DEFAULT NULL,
  `nom` VARCHAR(45) NULL DEFAULT NULL,
  `prenom` VARCHAR(45) NULL DEFAULT NULL,
  `compte_utilisateur_idcompte_utilisateur` INT(11) NOT NULL,
  PRIMARY KEY (`idadmnistrateur`),
  INDEX `fk_administrateur_compte_utilisateur1_idx` (`compte_utilisateur_idcompte_utilisateur` ASC),
  CONSTRAINT `fk_administrateur_compte_utilisateur1`
    FOREIGN KEY (`compte_utilisateur_idcompte_utilisateur`)
    REFERENCES `septièmeArche`.`compte_utilisateur` (`idcompte_utilisateur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;












CREATE TABLE IF NOT EXISTS `septièmeArche`.`Client` (
  `idClient` INT(11) NOT NULL,
  `nom` VARCHAR(45) NULL DEFAULT NULL,
  `prenom` VARCHAR(45) NULL DEFAULT NULL,
  `compte_utilisateur_idcompte_utilisateur` INT(11) NOT NULL,
  PRIMARY KEY (`idClient`),
  UNIQUE INDEX `idClient_UNIQUE` (`idClient` ASC) VISIBLE,
  INDEX `fk_Client_compte_utilisateur1_idx` (`compte_utilisateur_idcompte_utilisateur` ASC) VISIBLE,
  CONSTRAINT `fk_Client_compte_utilisateur1`
    FOREIGN KEY (`compte_utilisateur_idcompte_utilisateur`)
    REFERENCES `septièmeArche`.`compte_utilisateur` (`idcompte_utilisateur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `septièmeArche`.`adresse de facturation` (
  `idadresse_de_facturation` INT(11) NOT NULL,
  `pays` VARCHAR(45) NULL DEFAULT NULL,
  `voie` VARCHAR(45) NULL DEFAULT NULL,
  `numéro_adresse` VARCHAR(45) NULL DEFAULT NULL,
  `code_postal` VARCHAR(45) NULL DEFAULT NULL,
  `numéro_d_appartement` VARCHAR(45) NULL DEFAULT NULL,
  `batiment` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idadresse_de_facturation`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `septièmeArche`.`adresse de livraison` (
  `idadresse_de_livraison` INT(11) NOT NULL,
  `pays` VARCHAR(45) NULL DEFAULT NULL,
  `voie` VARCHAR(45) NULL DEFAULT NULL,
  `numéro_adresse` VARCHAR(45) NULL DEFAULT NULL,
  `code_postal` VARCHAR(45) NULL DEFAULT NULL,
  `numéro_appartement` VARCHAR(45) NULL DEFAULT NULL,
  `batiment` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idadresse_de_livraison`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `septièmeArche`.`commande` (
  `idcommande` INT(11) NOT NULL,
  `date` DATE NULL DEFAULT NULL,
  `prix_total` FLOAT(11) NULL DEFAULT NULL,
  `Client_idClient` INT(11) NOT NULL,
  PRIMARY KEY (`idcommande`),
  INDEX `fk_commande_Client1_idx` (`Client_idClient` ASC),
  CONSTRAINT `fk_commande_Client1`
    FOREIGN KEY (`Client_idClient`)
    REFERENCES `septièmeArche`.`Client` (`idClient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `septièmeArche`.`article_has_commande` (
  `article_idarticle` INT(11) NOT NULL,
  `commande_idcommande` INT(11) NOT NULL,
  `quantite_commandee` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`article_idarticle`, `commande_idcommande`),
  INDEX `fk_article_has_commande_commande1_idx` (`commande_idcommande` ASC) VISIBLE,
  INDEX `fk_article_has_commande_article1_idx` (`article_idarticle` ASC) VISIBLE,
  CONSTRAINT `fk_article_has_commande_article1`
    FOREIGN KEY (`article_idarticle`)
    REFERENCES `septièmeArche`.`article` (`idarticle`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_article_has_commande_commande1`
    FOREIGN KEY (`commande_idcommande`)
    REFERENCES `septièmeArche`.`commande` (`idcommande`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `septièmeArche`.`facture` (
  `idfacture` INT(11) NOT NULL,
  `commande_idcommande` INT(11) NOT NULL,
  PRIMARY KEY (`idfacture`),
  INDEX `fk_facture_commande1_idx` (`commande_idcommande` ASC) VISIBLE,
  CONSTRAINT `fk_facture_commande1`
    FOREIGN KEY (`commande_idcommande`)
    REFERENCES `septièmeArche`.`commande` (`idcommande`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

