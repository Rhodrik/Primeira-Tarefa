﻿/* Migration Script AddBrandTable.sql */
-- brand_db definition

-- Drop table

-- DROP TABLE brand_db;

CREATE TABLE new_brand_table 
(
	id int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY,
	description varchar(30) NOT NULL,
	status bool NOT NULL,
	mainprovidername varchar(150) NULL,
	since timestamp NULL,
	CONSTRAINT brand_db_pk PRIMARY KEY (id)
);