﻿CREATE DATABASE PASSAGENS

CREATE TABLE VOOS (
EMPRESA VARCHAR (10),
COMPANHIA_DE_VOO VARCHAR (255),
PRECO_TOTAL VARCHAR (10),
TAXA_DE_EMBARQUE VARCHAR (10),
TAXA_DE_SERVICO VARCHAR (10),
TEMPO_DE_VOO_IDA INT,
TEMPO_DE_VOO_VOLTA INT,
DATA_HORA_DE_IDA DATETIME,
DATA_HORA_DE_VOLTA DATETIME
)