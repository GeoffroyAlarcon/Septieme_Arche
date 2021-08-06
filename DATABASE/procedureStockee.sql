DROP PROCEDURE IF EXISTS afficher_livre;
DELIMITER | 
CREATE PROCEDURE afficher_livre(in p_isbn varchar(13) )      
BEGIN
declare isbn2 varchar(13);
set isbn2 =  p_isbn;
    SELECT livres.isbn,
 titre,
estnumerique,
articles.id,
 titre,
prix_ht,
date_parution,
nombre_page,editeur,
articles.quantite, 
 dimension,
URLimage,  
GROUP_CONCAT(auteurs.prenom, '+',auteurs.nom ORDER BY prenom ASC SEPARATOR ',') as listAuteurs,
GROUP_CONCAT(genreLivre.libelle ORDER BY genreLivre.libelle ASC SEPARATOR ',') as listGenres
from livres
 inner join livre_has_auteur on livre_has_auteur.isbn = livres.isbn
left join auteurs on auteurs.id = livre_has_auteur.auteurId
 
left join livre_has_genreLivre on livre_has_genreLivre.isbn = isbn2 
left join genreLivre on genrelivre.id =livre_has_genreLivre.genreLivreId 
left join articles on  articles.id = livres.articleId
  where livres.isbn = p_isbn;
END | 
 
DELIMITER ;
