-- MySQL Workbench Synchronization
-- Generated: 2021-05-02 19:03
-- Model: New Model
-- Version: 1.0
-- Project: SeptièmeArche
-- Author: Geoffroy

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE SCHEMA IF NOT EXISTS `septiemeArche` DEFAULT CHARACTER SET utf8 ;

CREATE TABLE IF NOT EXISTS `septiemeArche`.`compte_utilisateur` (
idcompte_utilisateur INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
  nom VARCHAR(100) NOT NULL,
  prenom VARCHAR(100) NOT NULL,
  email VARCHAR(255) UNIQUE NOT NULL,
  password VARCHAR(78) NOT NULL 
  )
ENGINE = InnoDB 
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `septièmeArche`.`administrateur` (
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



CREATE TABLE IF NOT EXISTS `septièmeArche`.`article` (
  `idarticle` INT(11) NOT NULL,
  `nom` VARCHAR(45) NULL DEFAULT NULL,
  `prix HT` FLOAT(11) NULL DEFAULT NULL,
  `URL image` VARCHAR(250) NULL DEFAULT NULL,
  `livre_id_livre` INT(11) NULL DEFAULT NULL,
  `quantite` INT(11) NULL DEFAULT NULL,
  `nombre_Consultation` INT(11) NULL DEFAULT NULL,
  `nombre_vendu` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idarticle`),
  INDEX `fk_article_livre1_idx` (`livre_id_livre` ASC),
  CONSTRAINT `fk_article_livre1`
    FOREIGN KEY (`livre_id_livre`)
    REFERENCES `septièmeArche`.`livre` (`id_livre`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `septièmeArche`.`livre` (
  `id_livre` INT(11) NOT NULL,
  `ISBN` VARCHAR(134) NULL DEFAULT NULL,
  `poids` VARCHAR(45) NULL DEFAULT NULL,
  `dimension` VARCHAR(45) NULL DEFAULT NULL,
  `editeur` VARCHAR(45) NULL DEFAULT NULL,
  `date de parution` VARCHAR(45) NULL DEFAULT NULL,
  `nombre_de_page` INT(11) NULL DEFAULT NULL,
  `nombre_de_consultation` INT(11) NULL DEFAULT NULL,
  `nombre_de_vente` INT(11) NULL DEFAULT NULL,
  `genre_idgenre` INT(11) NOT NULL,
  PRIMARY KEY (`id_livre`, `genre_idgenre`),
  INDEX `fk_livre_genre1_idx` (`genre_idgenre` ASC),
  CONSTRAINT `fk_livre_genre1`
    FOREIGN KEY (`genre_idgenre`)
    REFERENCES `septièmeArche`.`genre` (`idgenre`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `septièmeArche`.`auteur` (
  `idauteur` INT(11) NOT NULL,
  `nom` VARCHAR(45) NULL DEFAULT NULL,
  `prenom` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idauteur`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `septièmeArche`.`livre_has_auteur` (
  `livre_id_livre` INT(11) NOT NULL,
  `auteur_idauteur` INT(11) NOT NULL,
  PRIMARY KEY (`livre_id_livre`, `auteur_idauteur`),
  INDEX `fk_livre_has_auteur_auteur1_idx` (`auteur_idauteur` ASC),
  INDEX `fk_livre_has_auteur_livre1_idx` (`livre_id_livre` ASC) ,
  CONSTRAINT `fk_livre_has_auteur_livre1`
    FOREIGN KEY (`livre_id_livre`)
    REFERENCES `septièmeArche`.`livre` (`id_livre`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_livre_has_auteur_auteur1`
    FOREIGN KEY (`auteur_idauteur`)
    REFERENCES `septièmeArche`.`auteur` (`idauteur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
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

CREATE TABLE IF NOT EXISTS `septièmeArche`.`genre` (
  `idgenre` INT(11) NOT NULL,
  `nom` VARCHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`idgenre`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
