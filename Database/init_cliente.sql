CREATE TABLE cliente (
    id_cliente INTEGER GENERATED ALWAYS AS IDENTITY,
    nome VARCHAR(100) NOT NULL,
    cpf VARCHAR(11) NOT NULL,
    email VARCHAR(150) NOT NULL,
    telefone VARCHAR(15),
    data_nascimento DATE,
    ativo BOOLEAN NOT NULL DEFAULT TRUE,

    -- CONSTRAINT permite criar uma restrição e atribuir um nome a ela.
    -- Esse nome facilita a identificação da regra e de possíveis erros.

    -- PRIMARY KEY (Chave Primária)
    -- Define id_cliente como identificador único de cada registro.
    -- Não permite valores duplicados nem valores NULL.
    CONSTRAINT pk_cliente PRIMARY KEY (id_cliente),

    -- UNIQUE (Valor Único)
    -- Impede que dois clientes sejam cadastrados com o mesmo CPF.
    -- Cada CPF deverá aparecer apenas uma vez na tabela.
    CONSTRAINT uq_cliente_cpf UNIQUE (cpf),

    -- UNIQUE (Valor Único)
    -- Impede o cadastro de clientes com o mesmo endereço de e-mail.
    CONSTRAINT uq_cliente_email UNIQUE (email)
);

INSERT INTO cliente
(nome, cpf, email, telefone, data_nascimento, ativo)
VALUES
('Lucas Ferreira', '12345678901', 'lucas@email.com', '16999990001', '2005-03-15', TRUE),

('Mariana Costa', '23456789012', 'mariana@email.com', '16999990002', '2004-07-22', TRUE),

('Pedro Almeida', '34567890123', 'pedro@email.com', '16999990003', '2003-11-08', TRUE),

('Ana Oliveira', '45678901234', 'ana@email.com', '16999990004', '2005-01-30', TRUE),

('Gabriel Santos', '56789012345', 'gabriel@email.com', '16999990005', '2002-09-12', FALSE);

SELECT * FROM cliente;