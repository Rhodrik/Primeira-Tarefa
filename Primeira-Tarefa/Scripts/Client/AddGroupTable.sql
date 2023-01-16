/* Migration Script 221029113238_AddGroupTable.sql */
CREATE TABLE new_group_table (
	id int NOT NULL GENERATED ALWAYS AS IDENTITY,
	description varchar(30) NOT NULL,
	status bool NOT NULL,
	use_subgroup bool NOT NULL,
	CONSTRAINT pro_grupo_pk PRIMARY KEY (id)
);
