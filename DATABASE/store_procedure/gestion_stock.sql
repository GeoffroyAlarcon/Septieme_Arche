



DROP PROCEDURE IF EXISTS gestion_stock;
DELIMITER | 

 
CREATE PROCEDURE gestion_stock(IN param_clientId int)      
BEGIN

CREATE TEMPORARY TABLE  article_amount
select  pay.articleId ,  pay.quantiteCommandee, pay.clientId from state_Payment_has_article as pay where pay.clientId =  param_clientId ;


UPDATE  articles 
join article_amount on articles.id = article_amount.articleId  set
quantite = quantite- article_amount.quantiteCommandee;

INSERT INTO Commandes (clientId) VALUES (param_clientId);



SET @last_id_in_table1 = LAST_INSERT_ID();

INSERT INTO  commande_has_article(quantiteCommandee, commandeId,articleId)
SELECT   quantiteCommandee,LAST_INSERT_ID(), articleId  from article_amount;

-- restitution du numéro de la commande

select  @last_id_in_table1;
drop temporary table article_amount;


END |
DELIMITER ;

