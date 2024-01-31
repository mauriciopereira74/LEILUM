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
    (3, 100.00, 200000.00),
    (4, 500.00, 1000000.00),
    (5, 100000.00, 50000000.00)

INSERT INTO Categoria (idCategoria, Designacao, Regra)
VALUES
    (1, 'Jewelery', 0),
    (2, 'Clothing', 1),
    (3, 'Music Instruments', 3),
    (4, 'Eletronics', 2),
    (5, 'Art', 4),
    (6, 'Buildings', 5);

INSERT INTO Utilizador (Email, Password, TipoUtilizador)
VALUES
    ('maria.silva@email.pt','Maria2024',1),
    ('joao.pereira@email.pt','Pereira123',1),
    ('ana.carvalho@email.pt','Carvalho2024',1),
    ('miguel.santos@email.pt','Santos2024',1),
    ('ines.ribeiro@email.pt','Ribeiro123',1),
    ('ricardo.costa@email.pt','Costa2024',1),
    ('lucas@gmail.pt','123',1),
    ('rafa@gmail.com','123',2),
    ('mauricio@gmail.com','123',2),
    ('jose@gmail.com', 'Jose123',2),
    ('marta@sapo.pt', 'Marta123',2),
    ('xico@outlook.com', 'Xico123',2),
    ('sofia@gmail.com','Sofia123',2),
    ('mike@gmail.com','123',0);

INSERT INTO InfoUtilizador (Contribuinte, Nome, Morada, Nacionalidade, Contacto, DataNascimento, MetodoPagamento, IBAN, FotoPerfilPath, idUtilizador)
VALUES
    (123456789,'Maria Silva','Rua das Flores, 123, Lisboa','Portuguese',912345678,'1990-05-15',2,'PT50000201231234567890154','/ProfilePictures/maria.png','maria.silva@email.pt'),
    (987654321,'João Pereira','Avenida da Liberdade, 456, Porto','Portuguese',965432189,'1985-08-20',3,'PT50003301231234567890123','/ProfilePictures/joao.png','joao.pereira@email.pt'),
    (654321987,'Ana Carvalho','Rua do Carmo, 789, Faro','Portuguese',934567890,'1992-11-03',1,'PT50001201231234567890187','/ProfilePictures/ana.png','ana.carvalho@email.pt'),
    (789012345,'Miguel Santos','Praça do Comércio, 234, Braga','Portuguese',919876543,'1988-04-25',4,'PT50002201231234567890165','/ProfilePictures/miguel.png','miguel.santos@email.pt'),
    (234567890,'Inês Ribeiro','Avenida dos Aliados, 567, Coimbra','Portuguese',925678901,'1995-09-12',5,'PT50003201231234567890189','/ProfilePictures/ines.png','ines.ribeiro@email.pt'),
    (567890123,'Ricardo Costa','Rua Sá da Bandeira, 890, Aveiro','Portuguese',911234567,'1987-07-18',6,'PT50004201231234567890134','/ProfilePictures/ricardo.png','ricardo.costa@email.pt'),
    (234597657,'Lucas Oliveira', 'Rua das Isauras, 5, Braga','Portuguese',915324678,'2002-02-20',1,'PT8654345678765476457','/ProfilePictures/lucas.png','lucas@gmail.pt'),
    (754345621,'Rafael Gomes','Rua de Baixo, 12, Braga','Portuguese',923451812,'2001-11-27',5,'PT4314467567243523511','/ProfilePictures/rafa.png','rafa@gmail.com'),
    (935828923,'Mauricio Pereira','Rua do Castelo, 26, Viana do Castelo','Portuguese',941237290,'2000-06-14',7,'PT76420005465312423452','/ProfilePictures/mauricio.png','mauricio@gmail.com'),
    (765410056,'Jose Fernandes','Rua da Andorinha, 127, Braga','Portuguese',967112380,'1996-04-12',10,'PT6546732342376978346456','/ProfilePictures/jose.png','jose@gmail.com'),
    (297402348,'Marta Ferreira','Rua da Pomba, 17, Lisboa','Portuguese',912486619,'1999-09-23',8,'PT3246867211117868783454','/ProfilePictures/marta.png','marta@sapo.pt'),
    (459725320,'Francisco Miguel','Rua da Senhora, 167, Coimbra','Portuguese',976500345,'2000-12-12',9,'PT5000756234253566575456','/ProfilePictures/xico.png','xico@outlook.com'),
    (873669811,'Sofia Leite','Rua da Sanches, 14, Braga','Portuguese',913450912,'2001-05-14',6,'PT5007579782446867788764433','/ProfilePictures/sofia.png','sofia@gmail.com'),
    (934667821,'Mike Pinto','Rua do Tempero, 5, Braga','Portuguese',945764150,'1998-06-17',4,'PT5000043545624534646254','/ProfilePictures/mike.png','mike@gmail.com');

INSERT INTO Lote (idLote, Comitente, Comprador, Avaliador, ImagPath)
VALUES
    (0,'ana.carvalho@email.pt',null,'marta@sapo.pt','/LotPictures/vestido.png'),
    (1,'ricardo.costa@email.pt',null,null,'/LotPictures/camara.png'),
    (2,'maria.silva@email.pt',null,'sofia@gmail.com','/LotPictures/mansao.png'),
    (3,'lucas@gmail.pt',null,'xico@outlook.com','/LotPictures/pintura.png'),
    (4,'joao.pereira@email.pt',null,'mauricio@gmail.com','/LotPictures/telemovel.png'),
    (5,'miguel.santos@email.pt','lucas@gmail.pt','sofia@gmail.com','/LotPictures/apartamento.png'),
    (6,'joao.pereira@email.pt',null,null,'/LotPictures/guitarra.png'),
    (7,'ines.ribeiro@email.pt','maria.silva@email.pt','jose@gmail.com','/LotPictures/anel.png'),
    (8,'miguel.santos@email.pt',null,'marta@sapo.pt','/LotPictures/casaco.png'),
    (9,'lucas@gmail.pt',null,'mauricio@gmail.com','/LotPictures/colunas.png'),
    (10,'maria.silva@email.pt',null,'jose@gmail.com','/LotPictures/colarPerolas.png'),
    (11,'ines.ribeiro@email.pt',null,'xico@outlook.com','/LotPictures/quadro.png'),
    (12,'lucas@gmail.pt',null,null,'/LotPictures/espaco.png'),
    (13,'ana.carvalho@email.pt','joao.pereira@email.pt','mauricio@gmail.com','/LotPictures/fones.png'),
    (14,'miguel.santos@email.pt',null,'rafa@gmail.com','/LotPictures/violino.png');

INSERT INTO Artigo (idArtigo, Designacao, Caracteristicas, Descricao, ImagPath, idLote)
VALUES
    (0,'Charming Elegance','Elegant Silhouette. Minute Details. Classic style. Elegant Versatility.','With fluid lines and a silhouette that embraces femininity, the piece embodies the classic sophistication characteristic of the renowned designer.','/ItemPictures/vestido.png',0),
    (1,'Creative Power','Full-frame sensor. Sharp registration and vibrant colors. Equipped for 4K recording.','This camera represents the perfect fusion of advanced performance and portability, ideal for enthusiasts and professionals passionate about photography and videography.','/ItemPictures/camara.png',1),
    (2,'Haven of Elegance', 'Distinctive Architecture. Lush Gardens. Living History. Serene Luxury.','With its distinctive architecture and classic charm, the property is a retreat that combines luxury and history.','ItemPictures/mansao.png',2),
    (3,'Towards Eternity','Smooth lines and simplified shapes. Minimalist expression that exudes serenity.','A 30 cm high bronze sculpture, created by Ana Torres. "Elevation" portrays simplicity and harmony through fluid lines and soft shapes.','/ItemPictures/escultura.png',3),
    (4,'Golden Reflections','Remarkable size, providing an impactful visual presence. The frame complements the work, enhancing its aesthetics. Discreet presence of the artist signature, adding authenticity.','Vibrant colors, realistic textures and tranquil atmosphere. Meticulous details, from the rocks to the seagulls, reveal the artist precision.','/ItemPictures/pintura.png',3),
    (5,'Human Vision','Impressive Composition. Deep B&W tones. Focus on the Human and Environmental Condition. Visual Narrative and Documentation','An intriguing visual composition that reflects Sebastião Salgads mastery of capturing human and environmental complexity.','/ItemPictures/fotografia.png',3),
    (6,'Sublime Luxury','Plated in Gold. Details in Diamonds. Exceptional Performance. Advanced Cameras.','With its body coated in gold, every detail is accentuated by the elegant presence of diamonds.','/ItemPictures/telemovel.png',4),
    (7,'Intimate Haven','Artistic Flair. Modern Luxury. Tasteful Decor. Personal Touches.','Each corner is a testament to the iconic musician vibrant personality, with tasteful decor, exquisite furnishings, and a captivating blend of contemporary design and timeless elegance.','/ItemPictures/apartamento.png',5),
    (8,'The Pioneer','Timeless Design. Exceptional Craftsmanship. Solid Body Construction. Enduring Legacy.','This historic instrument, revered by rock stars, boasts a timeless design, exceptional craftsmanship, and a distinctive sound that has resonated through generations.','/ItemPictures/guitarra.png',6),
    (9,'The Eternal Shine','Dazzling Diamond. Delicate Assembly. Tiffany & Co. Quality Promise of Commitment','A radiant diamond, an eternal promise of love, elegance and timeless brilliance.','/ItemPictures/anel.png',7),
    (10,'monseo® Sapphire and Diamond Necklace','19.2K white gold. 18 brilliant-cut diamonds with a total weight of 0.12 ct. A blue sapphire located in the center','Exuberant piece that combines the timeless beauty of sapphires with the radiant shine of diamonds, all carefully set in a refined white gold structure.','/ItemPictures/colar.png',7),
    (11,'Platinum Hinged Bracelet','Luxury Materials. Articulated Design. Dazzling Shine. Exceptional Craftsmanship','Platinum articulated bracelet with 261 brilliant cut diamonds and 29 baguette cut emeralds.','/ItemPictures/pulseira.png',7),
    (12,'Schott Classic','Classic Design. Quality Materials. Durability.','Crafted with precision, it boasts a classic design that seamlessly blends versatility with rugged elegance.','/ItemPictures/casaco.png',8),
    (13,'Audiophile Bliss','Immersive Surround Sound. Cutting-Edge Technology. User-Friendly Controls','With cutting-edge technology and precision engineering, these speakers elevate sound quality to cinematic excellence.','/ItemPictures/colunas.png',9),
    (14,'Marine Elegance','White Gold Elegance. South Sea Brown Pearls. Timeless Appeal.','The marine inspired design captures the essence of sophistication, creating a harmonious blend of luxurious materials.','/ItemPictures/colarPerolas.png',10),
    (15,'Brushstrokes of Nature','Vibrant Color Palette. Expressive Atmosphere. Timeless Beauty.','The canvas is alive with dynamic brushstrokes, capturing the essence of the landscape in a kaleidoscope of colors.','/ItemPictures/quadro.png',11),
    (16,'Aveiro Industrial Hub','Ample Space. High Ceilings. Strategic Location. ','Boasting ample space and state-of-the-art facilities, it seamlessly combines practicality with efficiency.','/ItemPictures/espaco.png',12),
    (17,'Immersive Silence','Spatial Audio Capabilities. Sleek and Wireless Design. Long Battery Life.','These headphones offer unparalleled silence, creating a cocoon of tranquility for an uninterrupted listening journey.','/ItemPictures/fones.png',13),
    (18,'Harmony of the Past', 'Exceptional Craftsmanship. Fine Woods. Traditional Varnish. Careful Preservation.','A piece of exceptional craftsmanship. Every curve and notch tells a story of musical passion, while the notes that emanate from it carry the rich tradition and timeless beauty of classical music.','/ItemPictures/violino.png',14),
    (19,'Symphony In Notes','Melodic Elegance. Harmonic Complexity. Orchestral Balance. Dynamic Expressiveness','Refined harmonies and captivating melodies intertwine, creating a sonic tapestry that transcends time, revealing the eternity of Mozart classical music.','/ItemPictures/partitura.png',14),
    (20,'Passage to Rock','Simple and Iconic Design. Band Logo. Tangible Memory. Nostalgic Value.','With its printed simplicity, it becomes a guarded treasure, unlocking vibrant memories of a night where rock pulsed through the veins of the Portuguese audience.','/ItemPictures/bilhete.png',14);


INSERT INTO Leilao (idLeilao, Titulo, DataFim, ValorAbertura, ValorBase, ValorMinimo, ValorAtual, Estado, Avaliador, Comitente, Lote, Categoria)
VALUES
    (0,'Dress of Collection Saint Laurent','2024-02-02 12:00:00',22.5,45,38.25,40,1,'marta@sapo.pt','ana.carvalho@email.pt',0,2),
    (1,'Nikon DSLR 4K','2024-02-05 17:45:00',0,0,0,0,2,null,'ricardo.costa@email.pt',1,4),
    (2,'Historic Colonial Mansion','2024-07-20 18:00:00',5000000,10000000,8500000,5000000,1,'sofia@gmail.com','maria.silva@email.pt',2,6),
    (3,'Art is Eternal','2024-03-17 10:00:00',5000,10000,8500,7000,1,'xico@outlook.com','lucas@gmail.pt',3,5),
    (4,'IPhone 15 Pro Max','2024-02-25 15:00:00',300,600,510,750,1,'mauricio@gmail.com','joao.pereira@email.pt',4,4),
    (5,'Apartment to Sell','2024-01-11 11:30:00',2500000,5000000,4250000,8000000,0,'sofia@gmail.com','miguel.santos@email.pt',5,6),
    (6,'Eletric Guitar','2024-03-12 14:50:00',0,0,0,0,2,null,'joao.pereira@email.pt',6,3),
    (7,'Jewerly Collection','2024-01-15 17:00:00',250,500,425,1023,0,'jose@gmail.com','ines.ribeiro@email.pt',7,1),
    (8,'Cool Jacket','2024-02-14 19:00:00',50,100,85,50,1,'marta@sapo.pt','miguel.santos@email.pt',8,2),
    (9,'Bluetooth Columns','2024-03-19 00:00:00',150,300,255,150,1,'mauricio@gmail.com','lucas@gmail.pt',9,4),
    (10,'Pearl Necklace','2024-05-01 10:00:00',250,500,425,250,1,'jose@gmail.com','maria.silva@email.pt',10,1),
    (11,'Art of Vincent van Gogh','2024-05-02 16:30:00',362500,725000,616250,400000,1,'xico@outlook.com','ines.ribeiro@email.pt',11,5),
    (12,'Modern Warehouse','2024-11-01 14:00:00',0,0,0,0,2,null,'lucas@gmail.pt',12,6),
    (13,'Bluetooth Phones','2024-01-14 14:14:00',240,480,408,500,0,'mauricio@gmail.com','ana.carvalho@email.pt',13,4),
    (14,'Violin by Renowned Luthier','2024-06-14 14:30:00',75000,150000,127500,75000,1,'rafa@gmail.com','miguel.santos@email.pt',14,3);

INSERT INTO Licitacao (idLicitacao, Valor, Licitador, Leilao)
VALUES
    (0,3000000,'lucas@gmail.pt',5),
    (1,270,'miguel.santos@email.pt',7),
    (2,260,'ricardo.costa@email.pt',13),
    (3,3250000,'ricardo.costa@email.pt',5),
    (4,3600000,'ana.carvalho@email.pt',5),
    (5,300,'ines.ribeiro@email.pt',13),
    (6,400,'joao.pereira@email.pt',7),
    (7,4000000,'ricardo.costa@email.pt',5),
    (8,360,'joao.pereira@email.pt',13),
    (9,600,'lucas@gmail.pt',7),
    (10,930,'ana.carvalho@email.pt',7),
    (11,6000000,'ines.ribeiro@email.pt',5),
    (12,440,'maria.silva@email.pt',13),
    (13,8000000,'lucas@gmail.pt',5),
    (14,1023,'maria.silva@email.pt',7),
    (15,500,'joao.pereira@email.pt',13),
    (16,40,'ines.ribeiro@email.pt',0),
    (17,750,'lucas@gmail.pt',4),
    (18,400000,'miguel.santos@email.pt',11),
    (19,7000,'ricardo.costa@email.pt',3);


INSERT INTO Avaliador (Avaliador,Categoria)
VALUES
    ('rafa@gmail.com',3),
    ('mauricio@gmail.com',4),
    ('jose@gmail.com',1),
    ('marta@sapo.pt',2),
    ('xico@outlook.com',5),
    ('sofia@gmail.com',6);

INSERT INTO Notificacao (idUtilizador, MensagemNotificacao, DataNotificacao)
VALUES
    ('ana.carvalho@email.pt','You Created the Auction with Title:Dress of Collection Saint Laurent(Auction #0)','2023-11-23 12:30:00'),
    ('ricardo.costa@email.pt','You Created the Auction with Title:Nikon DSLR 4K(Auction #1),','2023-11-24 15:35:00'),
    ('maria.silva@email.pt','You Created the Auction with Title:Historic Colonial Mansion(Auction #2),','2023-11-25 10:45:00'),
    ('ana.carvalho@email.pt','Your Auction Titled: Dress of Collection Saint Laurent(Auction #0), was APPROVED.','2023-11-25 14:30:00'),
    ('maria.silva@email.pt','Your Auction Titled: Nikon DSLR 4K(Auction #1), was APPROVED.','2023-11-25 16:00:00'),
    ('lucas@gmail.pt','You Created the Auction with Title:Art is Eternal(Auction #3,),','2023-11-27 21:32:11'),
    ('joao.pereira@email.pt','You Created the Auction with Title:IPhone 15 Pro Max(Auction #4),','2023-11-27 22:55:12'),
    ('miguel.santos@email.pt','You Created the Auction with Title:Apartment to Sell(Auction #5),','2023-11-28 11:56:21'),
    ('lucas@gmail.pt','Your Auction Titled: Art is Eternal(Auction #3), was APPROVED.','2023-11-29 11:30:00'),
    ('joao.pereira@email.pt','Your Auction Titled: IPhone 15 Pro Max(Auction #4), was APPROVED.','2023-11-29 14:20:00'),
    ('miguel.santos@email.pt','Your Auction Titled: Apartment to Sell(Auction #5), was APPROVED.','2023-11-29 17:30:00'),
    ('lucas@gmail.pt','You Bid the Auction #5','2023-12-02 12:30:00'),
    ('joao.pereira@email.pt','You Created the Auction with Title:Eletric Guitar(Auction #6),','2023-12-06 14:30:00'),
    ('ines.ribeiro@email.pt','You Created the Auction with Title:Jewerly Collection(Auction #7),','2023-12-07 16:35:43'),
    ('miguel.santos@email.pt','You Created the Auction with Title:Cool Jacket(Auction #8),','2023-12-07 20:40:45'),
    ('lucas@gmail.pt','You Created the Auction with Title:Bluetooth Columns(Auction #9),','2023-12-07 23:55:00'),
    ('ines.ribeiro@email.pt','Your Auction Titled: Jewerly Collection(Auction #7), was APPROVED.','2023-12-08 11:45:00'),
    ('miguel.santos@email.pt','Your Auction Titled: Cool Jacket(Auction #8), was APPROVED.','2023-12-08 15:30:50'),
    ('lucas@gmail.pt','Your Auction Titled: Bluetooth Columns(Auction #9), was APPROVED.','2023-12-08 18:20:25'),
    ('miguel.santos@email.pt','You Bid the Auction #7','2023-12-10 09:45:30'),
    ('maria.silva@email.pt','You Created the Auction with Title:Pearl Necklace(Auction #10),','2023-12-10 13:20:20'),
    ('maria.silva@email.pt','Your Auction Titled: Pearl Necklace(Auction #10), was APPROVED.','2023-12-10 17:00:00'),
    ('ines.ribeiro@email.pt','You Created the Auction with Title:Art of Vincent van Gogh(Auction #11),','2023-12-13 18:59:00'),
    ('lucas@gmail.pt','You Created the Auction with Title:Modern Warehouse(Auction #12),','2023-12-13 21:30:05'),
    ('ana.carvalho@email.pt','You Created the Auction with Title:Bluetooth Phones(Auction #13),','2023-12-13 22:45:45'),
    ('ines.ribeiro@email.pt','Your Auction Titled: Art of Vincent van Gogh(Auction #11), was APPROVED.','2023-12-14 12:00:00'),
    ('ana.carvalho@email.pt','Your Auction Titled: Bluetooth Phones(Auction #13), was APPROVED.','2023-12-14 16:45:00'),
    ('ricardo.costa@email.pt','You Bid the Auction #7','2023-12-20 19:10:14'),
    ('ricardo.costa@email.pt','You Bid the Auction #5','2023-12-22 14:30:00'),
    ('ana.carvalho@email.pt','You Bid the Auction #5','2023-12-26 17:54:00'),
    ('ines.ribeiro@email.pt','You Bid the Auction #13','2023-12-27 13:32:00'),
    ('joao.pereira@email.pt','You Bid the Auction #7','2023-12-28 18:45:45'),
    ('ricardo.costa@email.pt','You Bid the Auction #5','2023-12-30 08:35:34'),
    ('joao.pereira@email.pt','You Bid the Auction #13','2023-12-30 12:38:12'),
    ('miguel.santos@email.pt','You Created the Auction with Title:Violin by Renowned Luthier(Auction #14,),','2024-01-02 10:45:00'),
    ('miguel.santos@email.pt','Your Auction Titled: Violin by Renowned Luthier(Auction #14,), was APPROVED.','2024-01-02 15:30:00'),
    ('lucas@gmail.pt','You Bid the Auction #7','2024-01-04 06:45:50'),
    ('ana.carvalho@email.pt','You Bid the Auction #7','2024-01-05 10:01:46'),
    ('ines.ribeiro@email.pt','You Bid the Auction #5','2024-01-07 15:30:21'),
    ('maria.silva@email.pt','You Bid the Auction #13','2024-01-07 19:10:35'),
    ('lucas@gmail.pt','You Bid the Auction #5','2024-01-08 16:17:18'),
    ('maria.silva@email.pt','You Bid the Auction #7','2024-01-10 12:35:32'),
    ('joao.pereira@email.pt','You Bid the Auction #13','2024-01-10 14:34:00'),
    ('lucas@gmail.pt','You Win the Auction with Title:Apartment to Sell(Auction #5,),','2024-01-11 11:30:00'),
    ('joao.pereira@email.pt','You Win the Auction with Title:Bluetooth Phones(Auction #13,),','2024-01-14 14:14:00'),
    ('maria.silva@email.pt','You Win the Auction with Title:Jewerly Collection(Auction #7,),','2024-01-15 17:00:00'),
    ('ines.ribeiro@email.pt','You Bid the Auction #0','2024-01-17 13:45:30'),
    ('lucas@gmail.pt','You Bid the Auction #4','2024-01-19 19:25:20'),
    ('miguel.santos@email.pt','You Bid the Auction #11','2024-01-24 23:13:14'),
    ('ricardo.costa@email.pt','You Bid the Auction #3','2024-01-28 15:00:01');