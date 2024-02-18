-- Cria a database
create database SGC;

--
-- Estrutura da tabela Usuario
--
DROP TABLE IF EXISTS sgc.Usuario;
create table sgc.Usuario (
login varchar(20),
senha varchar(14)
);

--
-- Popula a tabela com dados
--
insert into sgc.Usuario values ('teste', '123');