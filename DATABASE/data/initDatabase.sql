

insert into profil_utilisateur(libelle) VALUES ('client');
insert into profil_utilisateur(libelle) VALUES ('pilote des ventes');

insert into compte_utilisateur(nom,prenom,email,password, profil_utilisateuriD) VALUES ('messi','leo','leo@gmail.com','MD5(test)',1);
insert into compte_utilisateur(nom,prenom,email,password, profil_utilisateuriD) VALUES ('alarcon','geoffroy','geoffroy@septiemearche.com','MD5(azerty)',2);

insert into types(libelle,description) VALUES
('livre','livre physique'),
('livre numérique', ' livre numérique');

insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu,URLImage, typesId) VALUES('la grande histoire du 7ieme art-L.DELMAS',12.21,5,0,0,'Cinema-La-grande-histoire-du-7eme-art.jpg',1);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu,URLImage,typesId) VALUES('Tout sur le cinéma-P.Kemp',40.50,5,0,0,'Tout-sur-le-cinema.jpg',1);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu,URLImage,typesId) VALUES('Kubrick-M.Ciment',45,5,0,0,'Stanley-Kubrick.jpg',1);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu,URLImage,typesId) VALUES('1001 films à voir avant de mourir-Collectif',45,5,0,0,'1001-films-a-voir-avant-de-mourir.jpg',1);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu,URLImage,typesId) VALUES('Le Cinéma intérieur-L.Naccache Epub',22.99,null,0,0,'Le-Cinema-interieur.jpg',2);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu,URLImage,typesId) VALUES('Hitchcock-F.Truffaut',61,50,0,0,'Hitchcock.jpg',1);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu,URLImage,typesId) VALUES('Artmedia, une histoire du cinéma français',20,10,0,0,'Artmedia-une-histoire-du-cinema-francais.jpg',1);



insert into livres VALUES ('2035941725','La grande histoire du 7ème art','lorem ipsum testa ','1,42 Kg','19,70 x 25,00 x 2,80 cm','Larousse','2019-05-01',384,0,1);
insert into livres VALUES ('2081266164','Tout sur le cinéma','lorem ipsum testa ','1,77 Kg','18,30 x 25,70 x 4,30 cm','Flammarion','2019-05-01',576,0,2);
insert into livres VALUES ('2702142001','Kubrick','lorem ipsum testa', '1,4200kg','18,30 x 22cm x 27cm','Calmann-Levy','2011-02-23',336,0,3);
insert into livres VALUES ('2258161428','1001 films à voir avant de mourir','lorem ipsum testa', '1,860kg','1164 X 212 mm','Odile Jacob','2018-10-18',960,0,4);
insert into livres VALUES ('273815347X','Le Cinéma intérieur: Projection privée au coeur de la conscience','lorem ipsum testa', null,null,'Omnibus','2018-10-18',960,1,5);
insert into livres VALUES ('2070735745','Hitchcock','lorem ipsum testa', '1,8040KG',' 23cm x 29cm','Gallimard','1993-10-01',312,0,6);
insert into livres VALUES ('103291596X',' une histoire du cinéma français','lorem ipsum testa', '0,3240kg',' 13cm x 21cm','L''observatoire Eds De','2021-04-07',312,0,7);







insert into auteurs(nom,prenom,description) Values('Delmas','Laurent',"lorem ipsum");
insert into auteurs(nom,prenom,description) Values('Kemp','Philip' ,"lorem ipsum");
insert into auteurs(nom,prenom,description) Values( 'Ciment','Michel' ,"lorem ipsum");
insert into auteurs(nom,description)values('Collectif','lorem ipsum');
insert into auteurs(nom,prenom,description) Values( 'Naccache','Lionel' ,"lorem ipsum");
insert into auteurs(nom,prenom,description) Values( 'Truffaut','François' ,"lorem ipsum");
insert into auteurs(nom,prenom,description) Values( 'Besnehard','Dominique' ,"lorem ipsum");
insert into auteurs(nom,prenom,description) Values( 'Van Egmond','Nedjma' ,"lorem ipsum");




insert into livre_has_auteur(isbn,auteurid) VALUES('2035941725', 1);
insert into livre_has_auteur(isbn,auteurid) VALUES('2081266164', 2);
insert into livre_has_auteur(isbn,auteurid) VALUES('2702142001', 3);
insert into livre_has_auteur(isbn,auteurid) VALUES('2258161428', 4);
 insert into livre_has_auteur(isbn,auteurid) VALUES('273815347X', 6);
insert into livre_has_auteur(isbn,auteurid) VALUES('273815347X', 5);
insert into livre_has_auteur(isbn,auteurid) VALUES('2070735745', 6);
insert into livre_has_auteur(isbn,auteurid) VALUES('103291596X', 7);
insert into livre_has_auteur(isbn,auteurid) VALUES('103291596X',8);




insert into genresLivre(libelle)VALUES("classement de films");
insert into genresLivre(libelle)VALUES("biographie");
insert into genresLivre(libelle)VALUES("histoire du cinéma");
insert into genresLivre(libelle)VALUES("Essai");


insert into livres_numerique(isbn,format,drm)VALUES('273815347X','ePub','Adobe DRM');

insert into livre_has_genreLivre(isbn,genrelivreId)values('2035941725',3);
insert into livre_has_genreLivre(isbn,genrelivreId)values('2081266164',3);
insert into livre_has_genreLivre(isbn,genrelivreId)values('2702142001',2);
insert into livre_has_genreLivre(isbn,genrelivreId)values('2258161428',1);
insert into livre_has_genreLivre(isbn,genrelivreId)values('2070735745',2);
insert into livre_has_genreLivre(isbn,genrelivreId)values('103291596X',4);
insert into livre_has_genreLivre(isbn,genrelivreId)values('273815347X',4);

insert into  state_payment_has_article(quantiteCommandee,articleId, clientId) VALUES (4,2,1);

insert into  state_payment_has_article(quantiteCommandee,articleId, clientId) VALUES (1,3,1);