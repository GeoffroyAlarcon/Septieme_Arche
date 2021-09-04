



DROP PROCEDURE IF EXISTS gestion_stock;
DELIMITER | 

 
CREATE PROCEDURE gestion_stock(IN param_clientId int)      
BEGIN

create Temporary TAble  article_amount
select  pay.articleId ,  pay.quantiteCommandee, pay.clientId from state_Payment_has_article as pay where pay.clientId =  param_clientId ;


UPDATE  articles 
join article_amount on articles.id = article_amount.articleId  set
quantite = quantite- article_amount.quantiteCommandee;

INSERT INTO Commandes (clientId) VALUES (param_clientId);

INSERT INTO  commande_has_article(quantiteCommandee, commandeId,articleId)
SELECT   quantiteCommandee,LAST_INSERT_ID(), articleId  from article_amount;


END |
DELIMITER ;

