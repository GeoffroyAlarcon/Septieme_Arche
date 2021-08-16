DROP PROCEDURE IF EXISTS afficher_livre;
DELIMITER | 
CREATE PROCEDURE afficher_livre(in p_isbn varchar(13) )      
BEGIN
declare isbn2 varchar(13);
set isbn2 =  p_isbn;

update articles  join livres on articles.id=livres.articleid  set nombreConsultation = nombreConsultation + 1 where isbn = p_isbn;
    SELECT livres.isbn,
 titre,
estnumerique,
articles.id,
 titre,
prix_ht,
editeur,
date_parution,
nombre_page,editeur,
articles.quantite, 
 dimension,
URLimage,  
GROUP_CONCAT(IFNULL(auteurs.prenom,''), '+',IFNULL(auteurs.nom,'') ORDER BY prenom ASC SEPARATOR ',') as listAuteur,
GROUP_CONCAT(genresLivre.libelle ORDER BY genresLivre.libelle ASC SEPARATOR ',') as listGenres
from livres
 inner join livre_has_auteur on livre_has_auteur.isbn = livres.isbn
left join auteurs on auteurs.id = livre_has_auteur.auteurId 
left join livre_has_genreLivre on livre_has_genreLivre.isbn = isbn2 
left join genresLivre on genreslivre.id =livre_has_genreLivre.genreLivreId 
left join articles on  articles.id = livres.articleId
  where livres.isbn = p_isbn;
END | 
 
DELIMITER ;

