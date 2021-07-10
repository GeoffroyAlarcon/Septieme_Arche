
// insert users

insert into compte_utilisateur (prenom,nom,email,password) Values
('Jean','Dupont','jeandupont@gmail.com', SHA1('azerty')),
('eric','Cantona','EricCantona@gmail.com', SHA1('test')),
('Zlatan','Ibrahimovic','zlatan@gmail.com', SHA1('test')),
('Carlos','Puyol','c.puyol@gmail.com', SHA1('test')
);




// insert articles

insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu) VALUES('livre',40.50,5,0,0);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu) VALUES('livre',40.50,5,0,0);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu) VALUES('livre',40.50,5,0,0);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu) VALUES('livre',40.50,5,0,0);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu) VALUES('livre',40.50,5,0,0);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu) VALUES('livre',40.50,5,0,0);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu) VALUES('livre',40.50,5,0,0);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu) VALUES('livre',40.50,5,0,0);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu) VALUES('livre',40.50,5,0,0);
insert into articles(nom,prix_ht,quantite,nombreconsultation,nombreVendu) VALUES('livre',40.50,5,0,0);


// insert livres


insert into livres VALUES ('1234567891011','bel Ami','csdqqsdsqddqssddsqdsqdsqdsdsqdqsdssdqsdqdsqdsqdsqsddsdqsqsdsdq','200g','40 x 60','Galimard',null,200,1);




insert auteurs
insert into auteurs(nom,prenom,description) Values("Maupassant","guy","lorem ipsum");

insert livre_has_auteur

insert into livre_has_auteur(isbn,auteurid) VALUES('1234567891011', 1);