

DROP PROCEDURE IF EXISTS afficher_livre_digital;
DELIMITER | 
CREATE PROCEDURE afficher_livre_digital(in p_isbn varchar(13) )      
BEGIN
declare isbn2 varchar(13);
declare isbn3 varchar(13);
set isbn2 =  p_isbn;
set isbn3 =  p_isbn;

CREATE TEMPORARY TABLE auteurs_copie -- on créer une table temporaire pour récupérer la liste des auteurs en fonction du isbn de la procédure stockée
 SELECt GROUP_CONCAT(IFNULL(auteurs.prenom,''), '+',IFNULL(auteurs.nom,'') ORDER BY auteurs.nom ASC SEPARATOR ',') as listAuteur
   from auteurs
   join livre_has_auteur on livre_has_auteur.auteurId= auteurs.id
   where livre_has_auteur.isbn = p_isbn;
 

CREATE TEMPORARY TABLE genreslivre_copie -- on créer une table temporaire pour récupérer la liste des genres de livre en fonction du isbn de la procédure stockée
select GROUP_CONCAT(genreslivre.libelle ORDER BY  genreslivre.libelle ASC SEPARATOR ',') as listGenres
from genresLivre
  join  livre_has_genreLivre on genreslivre.id =livre_has_genreLivre.genreLivreId 
  where livre_has_genreLivre.isbn = p_isbn;




update articles  join livres on articles.id=livres.articleid  set nombreConsultation = nombreConsultation + 1 where isbn = p_isbn;
    SELECT livres.isbn,
articles.nom as articleNom,
 livres.titre,
 livres.description,
estnumerique,
articles.id,
 titre,
prix_ht,
editeur,
parutionDate,
pagesNombre,
editeur,
articles.quantite, 
 dimension,
URLimage,  
livres_numerique.format as formatDigital,
 listAuteur,
listGenres
from livres
 
left join livres_numerique on livres_numerique.isbn = isbn3 
left join articles on  articles.id = livres.articleId
CROSS  join   genreslivre_copie
  CROSS  join   auteurs_copie
  where livres.isbn = p_isbn;

  -- on supprime les tables temporaires

  drop table  genreslivre_copie;
 drop table  auteurs_copie;
END | 

DELIMITER ;

