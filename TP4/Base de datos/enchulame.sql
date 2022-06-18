go 
create database enchulame_db
go 
use enchulame_db

--Creo tabla clientes
create table clientes(
nombre varchar(50) not null,
apellido varchar(50) not null,
dni varchar(50) not null,
fechaReserva date not null,
mail varchar(50) not null,
idReserva int identity not null,
esEstudiante bit not null
)

--Insert clientes
insert into clientes (nombre, apellido, dni, fechaReserva, mail, esEstudiante) values
('Quentin', 'Tarantino', '16428576', '2022/06/20', 'mememaker@hotmail.com', 0),
('Steven', 'Spielberg', '13528465', '2022/06/22', 'phonehome@yahoo.com', 0),
('Francis', 'Ford Coppola', '13845752', '2022/06/17', 'apocallypsis@now.com', 0),
('Christopher', 'Nolan', '24586135', '2022/07/01', 'inception@gmail.com', 0),
('Malena', 'Gomez', '39751252', '2022/08/15', 'malegomez@gmail.com', 1),
('Lucrecia', 'Martel', '27548632', '2022/06/22', 'lucre@hotmail.com', 0),
('Luis', 'Puenzo', '27659878', '2022/07/15', 'puenzo@gmail.com', 0),
('Billy', 'Wilder', '12453852', '2022/07/04', 'elbilly@gmail.com', 0),
('Giuseppe', 'Tornatore', '10253242', '2022/07/05', 'giusseppe@hotmail.com', 0),
('Pedro', 'Montenegro', '41232528', '2022/06/28', 'montenegro@gmail.com', 1),
('Valentina', 'Olmedo', '40128695', '2022/06/28', 'valeolmedo@gmail.com', 1),
('Ridley', 'Scott', '19542386', '2022/07/12', 'scott@gmail.com', 0),
('Sergio', 'Leone', '18452763', '2022/07/16', 'buenomalofeo@gmail.com', 0),
('Martin', 'Scorsese', '15243956', '2022/08/12', 'nylover@gmail.com', 0),
('Trinidad', 'Labbate', '43252943', '2022/07/18', 'trini_labbate@gmail.com', 1),
('Agustina', 'Lopez', '41852753', '2022/06/19', 'agus2002@gmail.com', 1),
('David', 'Lynch', '15286475', '2022/07/24', 'elephantman@hotmail.com', 0),
('Roman', 'Polanski', '27458396', '2022/06/23', 'roman@gmail.com', 0),
('Eugenia', 'Etchandy', '43582166', '2022/07/16', 'euge04@gmail.com', 1),
('Hayao', 'Miyazaki', '21525648', '2022/07/13', 'totoro@gmail.com', 0),
('Daniel', 'Hendler', '19852365', '2022/06/27', 'candidato@gmail.com', 0),
('Gus', 'Van Sant', '19582365', '2022/06/28', 'elephant@hotmail.com', 0),
('Akira', 'Kurosawa', '18542385', '2022/06/20', 'akira@yahoo.com', 0),
('Robert', 'Zemeckis', '14528659', '2022/07/26', 'btf@hotmail.com', 0),
('James', 'Cameron', '21542396', '2022/08/02', 'james_cameron@gmail.com', 0),
('George', 'Lucas', '18546285', '2022/07/09', 'lucasfilms@disney.com', 0),
('David', 'Fincher', '17562856', '2022/07/05', 'seven@gmail.com', 0),
('Hermanas', 'Wachowski', '18452753', '2022/06/24', 'wachowski@gmail.com', 0),
('Stanley', 'Kubrick', '18542396', '2022/08/14', 'clockwork@orange.com', 0),
('Woody', 'Allen', '12585258', '2022/07/18', 'nylover2@gmail.com', 0),
('Israel Adrian', 'Caetano', '25846325', '2022/07/18', 'pizzabirrafaso@gmail.com', 0),
('Zoe', 'Gonzalez', '43251926', '2022/06/18', 'elcentrodeestudiantes@ceadig.com', 1),
('Pilar', 'Gamboa', '40581265', '2022/07/20', 'piligamboa@gmail.com', 1),
('Albertina', 'Carri', '28452753', '2022/07/23', 'albertinacarri@gmail.com', 0),
('Pablo', 'Trapero', '24586321', '2022/06/23', 'carancho@gmail.com', 0),
('Sofia', 'Coppola', '32658953', '2022/06/29', 'coppolla@now.com', 0),
('Bruno', 'Stagnaro', '27548556', '2022/06/30', 'historiasminimas@hotmail.com', 0),
('Isabel', 'Coixet', '19852645', '2022/07/31', 'isaco@hotmail.com', 0),
('Eliana', 'Ferrer', '41582346', '2022/07/06', 'ferrereliana@gmail.com', 1),
('Agnes', 'Varda', '10252368', '2022/07/17', 'agnes@hotmail.com', 0),
('Patty', 'Jenkins', '28546395', '2022/08/18', 'wonderwoman@diemarveldie.com', 0),
('Mariano', 'Llinas', '19852345', '2022/07/12', 'laflor@gmail.com', 0),
('Diego', 'Lerman', '29856324', '2022/06/23', 'diegote@yahoo.com', 0),
('Damian', 'Szifron', '21546853', '2022/07/26', 'relatos@yahoo.com', 0),
('Manuel', 'Bunge', '41253751', '2022/06/25', 'manubunge@gmail.com', 1),
('Bruno', 'Borsani', '42583215', '2022/06/19', 'brunobor@gmail.com', 1),
('Darren', 'Aronofsky', '25142685', '2022/07/17', 'requiem@pi.com', 0),
('Daniel', 'Burman', '22459837', '2022/08/06', 'burman@gmail.com', 0),
('Camila', 'Hocsman', '35452656', '2022/07/17', 'camihoc@gmail.com', 1),
('Augusto', 'Rios', '43025734', '2022/07/12', 'studentlife@gmail.com', 1);

--Consultas para leer datos
select * from clientes
select mail from clientes group by mail