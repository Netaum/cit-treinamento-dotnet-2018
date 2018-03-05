CREATE TABLE tb_tipo_pedido (
	cd_tipo_pedido INT PRIMARY KEY,
	ds_tipo_pedido VARCHAR(50)
)

INSERT INTO tb_tipo_pedido (cd_tipo_pedido, ds_tipo_pedido) VALUES (1, 'INTERNO')
INSERT INTO tb_tipo_pedido (cd_tipo_pedido, ds_tipo_pedido) VALUES (2, 'EXTERNO')

CREATE TABLE tb_pedido (
	cd_pedido INT PRIMARY KEY IDENTITY,
	nr_numero_pedido VARCHAR(10),
	ds_pedido VARCHAR(50),
	cd_tipo_pedido INT FOREIGN KEY REFERENCES tb_tipo_pedido (cd_tipo_pedido),
	dt_pedido DATETIME,
	in_desligado bit
)