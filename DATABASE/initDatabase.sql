

insert into compte_utilisateur (prenom,nom,email,password) Values
('Jean','Dupont','jeandupont@gmail.com', SHA1('azerty')),
('eric','Cantona','EricCantona@gmail.com', SHA1('test')),
('Zlatan','Ibrahimovic','zlatan@gmail.com', SHA1('test')),
('Carlos','Puyol','c.puyol@gmail.com', SHA1('test')
);




insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu) VALUES('livre',12.21,5,0,0);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu) VALUES('livre',40.50,5,0,0);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu) VALUES('livre',45,5,0,0);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu) VALUES('livre',45,5,0,0);

insert into livres VALUES ('2035941725','La grande histoire du 7ème art','lorem ipsum testa ','1,42 Kg','19,70 x 25,00 x 2,80 cm','Larousse','2019-05-01',384,0,1);
insert into livres VALUES ('2081266164','Tout sur le cinéma','lorem ipsum testa ','1,77 Kg','18,30 x 25,70 x 4,30 cm','Flammarion','2019-05-01',576,0,2);
insert into livres VALUES ('2702142001','Kubrick','lorem ipsum testa', '1,4200kg','18,30 x 22cm x 27cm','Calmann-Levy','2011-02-23',336,0,3);
insert into livres VALUES ('2258161428','1001 films à voir avant de mourir','lorem ipsum testa', '1,860kg','1164 X 212 mm','Omnibus','2018-10-18',960,0,4);









insert into auteurs(nom,prenom,description) Values('Delmas','Laurent',"lorem ipsum");
insert into auteurs(nom,prenom,description) Values('Kemp','Philip' ,"lorem ipsum");
insert into auteurs(nom,prenom,description) Values( 'Ciment','Michel' ,"lorem ipsum");
insert into auteurs(nom,description)values('Collectif','lorem ipsum');



insert into livre_has_auteur(isbn,auteurid) VALUES('2035941725', 1);
insert into livre_has_auteur(isbn,auteurid) VALUES('2081266164', 2);
insert into livre_has_auteur(isbn,auteurid) VALUES('2702142001', 3);
insert into livre_has_auteur(isbn,auteurid) VALUES('2258161428', 4);

insert into genreLivre(libelle)VALUES("classement de films");
insert into genreLivre(libelle)VALUES("biographie");
insert into genreLivre(libelle)VALUES("histoire du cinéma");


insert into livre_has_genreLivre(isbn,genrelivreId)values('2035941725,3');
insert into livre_has_genreLivre(isbn,genrelivreId)values('2081266164',3);
insert into livre_has_genreLivre(isbn,genrelivreId)values('2702142001',2);
insert into livre_has_genreLivre(isbn,genrelivreId)values('2258161428',1);