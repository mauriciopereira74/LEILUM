USE LEILUM;

INSERT INTO TipoUtilizador (Tipo, Role) 
VALUES 
    (0,'Administrador'),
    (1,'Cliente'),
    (2, 'Avaliador');

INSERT INTO MetodoPagamento (Metodo, Designacao) 
VALUES
    (1, 'Credit Card'),
    (2, 'Debit Card'),
    (3, 'PayPal'),
    (4, 'Bank Transfer'),
    (5, 'Cash on Delivery'),
    (6, 'Cryptocurrency'),
    (7, 'Mobile Payment'),
    (8, 'Gift Card'),
    (9, 'Google Pay'),
    (10, 'Apple Pay');


INSERT INTO Regra (idRegra, ValorMinimo, ValorMaximo)
VALUES
    (0, 50.00, 500.00),
    (1, 10.00, 150.00),
    (2, 50.00, 600.00),
    (3, 100.00, 2000000.00),
    (4, 500.00, 10000000.00),
    (5, 100000.00, 50000000.00)

INSERT INTO Categoria (idCategoria, Designacao, Regra)
VALUES
    (0, 'Jewelery', 0),
    (1, 'Clothing', 1),
    (3, 'Music Instruments', 3),
    (4, 'Eletronics', 2),
    (5, 'Art', 4),
    (6, 'Buildings', 5);
