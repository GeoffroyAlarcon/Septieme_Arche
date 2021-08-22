



DROP PROCEDURE IF EXISTS gestion_stock;
DELIMITER | 
CREATE PROCEDURE gestion_stock(IN inList intArray )      
BEGIN
DECLARE i, n INTEGER; 

SET n = CARDINALITY(inList); 
update articles   set quantite =quantite - 5 where id = 1  and 5 <= quantite;



END | 

DELIMITER ;


