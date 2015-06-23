/*
DUE TO BUGS IN SQL DEVELOPER EXPORTER I HAD TO MAKE CHANGES TO THIS SCRIPT:
-SET DATE LANGUAGE SO DATE FIELDS ARE CORRECTLY INSERTED
-SET DEFINE OFF TO BE SURE

FURTHERMORE A CUSTOMIZATION WAS NEEDED IN THE ACCESS TO ORACLE CONVERTER:
-LONG TEXT IN ACCESS BECOMES A NCLOB FIELD BUT THE CONTENTS OF THIS COLUMN WAS ALWAYS NULL. SO LONG TEXT FORCED TO BE VARCHAR2.

*/

--DISABLES THE PARSING OF COMMANDS TO REPLACE SUBSTITUTION VARIABLES WITH THEIR VALUES
SET DEFINE OFF;

--BELANGRIJK ZODAT ENGELSE AFKORTINGEN VAN MAANDEN GOED WORDEN HERKEND DUS 
-- MAR IS MARCH (ENGELS) EN MRT IS MAART (NEDERLANDS)
ALTER SESSION SET NLS_DATE_LANGUAGE = 'DUTCH';

--------------------------------------------------------
--  FILE CREATED - DONDERDAG-DECEMBER-18-2014   
--------------------------------------------------------
DROP TABLE "ACCOUNT" CASCADE CONSTRAINTS;
DROP TABLE "ACCOUNT_BIJDRAGE" CASCADE CONSTRAINTS;
DROP TABLE "BERICHT" CASCADE CONSTRAINTS;
DROP TABLE "BESTAND" CASCADE CONSTRAINTS;
DROP TABLE "BIJDRAGE" CASCADE CONSTRAINTS;
DROP TABLE "BIJDRAGE_BERICHT" CASCADE CONSTRAINTS;
DROP TABLE "CATEGORIE" CASCADE CONSTRAINTS;
DROP TABLE "EVENT" CASCADE CONSTRAINTS;
DROP TABLE "LOCATIE" CASCADE CONSTRAINTS;
DROP TABLE "PERSOON" CASCADE CONSTRAINTS;
DROP TABLE "PLEK" CASCADE CONSTRAINTS;
DROP TABLE "PLEK_RESERVERING" CASCADE CONSTRAINTS;
DROP TABLE "PLEK_SPECIFICATIE" CASCADE CONSTRAINTS;
DROP TABLE "POLSBANDJE" CASCADE CONSTRAINTS;
DROP TABLE "PRODUCT" CASCADE CONSTRAINTS;
DROP TABLE "PRODUCTCAT" CASCADE CONSTRAINTS;
DROP TABLE "PRODUCTEXEMPLAAR" CASCADE CONSTRAINTS;
DROP TABLE "RESERVERING" CASCADE CONSTRAINTS;
DROP TABLE "RESERVERING_POLSBANDJE" CASCADE CONSTRAINTS;
DROP TABLE "SPECIFICATIE" CASCADE CONSTRAINTS;
DROP TABLE "VERHUUR" CASCADE CONSTRAINTS;
DROP SEQUENCE "ACCOUNT_BIJDRAGE_FCSEQ";
DROP SEQUENCE "ACCOUNT_FCSEQ";
DROP SEQUENCE "BIJDRAGE_FCSEQ";
DROP SEQUENCE "EVENT_FCSEQ";
DROP SEQUENCE "LOCATIE_FCSEQ";
DROP SEQUENCE "PERSOON_FCSEQ";
DROP SEQUENCE "PLEK_FCSEQ";
DROP SEQUENCE "PLEK_RESERVERING_FCSEQ";
DROP SEQUENCE "PLEK_SPECIFICATIE_FCSEQ";
DROP SEQUENCE "POLSBANDJE_FCSEQ";
DROP SEQUENCE "PRODUCTCAT_FCSEQ";
DROP SEQUENCE "PRODUCTEXEMPLAAR_FCSEQ";
DROP SEQUENCE "PRODUCT_FCSEQ";
DROP SEQUENCE "RESERVERING_FCSEQ";
DROP SEQUENCE "RESERVERING_POLSBANDJE_FCSEQ";
DROP SEQUENCE "SPECIFICATIE_FCSEQ";
DROP SEQUENCE "VERHUUR_FCSEQ";
--------------------------------------------------------
--  DDL FOR SEQUENCE ACCOUNT_BIJDRAGE_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "ACCOUNT_BIJDRAGE_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE ACCOUNT_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "ACCOUNT_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE BIJDRAGE_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "BIJDRAGE_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE EVENT_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "EVENT_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE LOCATIE_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "LOCATIE_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE PERSOON_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "PERSOON_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE PLEK_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "PLEK_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE PLEK_RESERVERING_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "PLEK_RESERVERING_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE PLEK_SPECIFICATIE_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "PLEK_SPECIFICATIE_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE POLSBANDJE_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "POLSBANDJE_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE PRODUCTCAT_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "PRODUCTCAT_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE PRODUCTEXEMPLAAR_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "PRODUCTEXEMPLAAR_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE PRODUCT_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "PRODUCT_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE RESERVERING_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "RESERVERING_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE RESERVERING_POLSBANDJE_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "RESERVERING_POLSBANDJE_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE SPECIFICATIE_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "SPECIFICATIE_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR SEQUENCE VERHUUR_FCSEQ
--------------------------------------------------------

   CREATE SEQUENCE  "VERHUUR_FCSEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL FOR TABLE ACCOUNT
--------------------------------------------------------

  CREATE TABLE "ACCOUNT" 
   (	"ID" NUMBER(10,0), 
	"GEBRUIKERSNAAM" NVARCHAR2(255), 
	"EMAIL" NVARCHAR2(255) UNIQUE, 
	"ACTIVATIEHASH" NVARCHAR2(255), 
	"GEACTIVEERD" NUMBER(1,0) DEFAULT (0),
	"PASSWORD" NVARCHAR2(255),
	"ROL" NVARCHAR2(255) DEFAULT ('GEBRUIKER')
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE ACCOUNT_BIJDRAGE
--------------------------------------------------------

  CREATE TABLE "ACCOUNT_BIJDRAGE" 
   (	"ID" NUMBER(10,0), 
	"ACCOUNT_ID" NUMBER(10,0), 
	"BIJDRAGE_ID" NUMBER(10,0), 
	"LIKE" NUMBER(1,0) DEFAULT (0), 
	"ONGEWENST" NUMBER(1,0) DEFAULT (0)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE BERICHT
--------------------------------------------------------

  CREATE TABLE "BERICHT" 
   (	"BIJDRAGE_ID" NUMBER(10,0), 
	"TITEL" NVARCHAR2(255), 
	"INHOUD" VARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE BESTAND
--------------------------------------------------------

  CREATE TABLE "BESTAND" 
   (	"BIJDRAGE_ID" NUMBER(10,0), 
	"CATEGORIE_ID" NUMBER(10,0), 
	"BESTANDSLOCATIE" NVARCHAR2(255), 
	"GROOTTE" NUMBER(10,0) DEFAULT (0)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE BIJDRAGE
--------------------------------------------------------

  CREATE TABLE "BIJDRAGE" 
   (	"ID" NUMBER(10,0), 
	"ACCOUNT_ID" NUMBER(10,0), 
	"DATUM" DATE, 
	"SOORT" NVARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE BIJDRAGE_BERICHT
--------------------------------------------------------

  CREATE TABLE "BIJDRAGE_BERICHT" 
   (	"BIJDRAGE_ID" NUMBER(10,0) DEFAULT (0), 
	"BERICHT_ID" NUMBER(10,0) DEFAULT (0)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE CATEGORIE
--------------------------------------------------------

  CREATE TABLE "CATEGORIE" 
   (	"BIJDRAGE_ID" NUMBER(10,0), 
	"CATEGORIE_ID" NUMBER(10,0), 
	"NAAM" NVARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE EVENT
--------------------------------------------------------

  CREATE TABLE "EVENT" 
   (	"ID" NUMBER(10,0), 
	"LOCATIE_ID" NUMBER(10,0), 
	"NAAM" NVARCHAR2(255), 
	"DATUMSTART" DATE, 
	"DATUMEINDE" DATE, 
	"MAXBEZOEKERS" NUMBER(10,0) DEFAULT (0)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE LOCATIE
--------------------------------------------------------

  CREATE TABLE "LOCATIE" 
   (	"ID" NUMBER(10,0), 
	"NAAM" NVARCHAR2(255), 
	"STRAAT" NVARCHAR2(255), 
	"NR" NVARCHAR2(255), 
	"POSTCODE" NVARCHAR2(255), 
	"PLAATS" NVARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE PERSOON
--------------------------------------------------------

  CREATE TABLE "PERSOON" 
   (	"ID" NUMBER(10,0), 
	"VOORNAAM" NVARCHAR2(255), 
	"TUSSENVOEGSEL" NVARCHAR2(255), 
	"ACHTERNAAM" NVARCHAR2(255), 
	"STRAAT" NVARCHAR2(255), 
	"HUISNR" NVARCHAR2(255), 
	"WOONPLAATS" NVARCHAR2(255), 
	"BANKNR" NVARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE PLEK
--------------------------------------------------------

  CREATE TABLE "PLEK" 
   (	"ID" NUMBER(10,0), 
	"LOCATIE_ID" NUMBER(10,0), 
	"NUMMER" NVARCHAR2(255), 
	"CAPACITEIT" NUMBER(10,0) DEFAULT (0)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE PLEK_RESERVERING
--------------------------------------------------------

  CREATE TABLE "PLEK_RESERVERING" 
   (	"ID" NUMBER(10,0), 
	"PLEK_ID" NUMBER(10,0), 
	"RESERVERING_ID" NUMBER(10,0)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE PLEK_SPECIFICATIE
--------------------------------------------------------

  CREATE TABLE "PLEK_SPECIFICATIE" 
   (	"ID" NUMBER(10,0), 
	"SPECIFICATIE_ID" NUMBER(10,0), 
	"PLEK_ID" NUMBER(10,0), 
	"WAARDE" NVARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE POLSBANDJE
--------------------------------------------------------

  CREATE TABLE "POLSBANDJE" 
   (	"ID" NUMBER(10,0), 
	"BARCODE" NVARCHAR2(255), 
	"ACTIEF" NUMBER(1,0) DEFAULT (0)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE PRODUCT
--------------------------------------------------------

  CREATE TABLE "PRODUCT" 
   (	"ID" NUMBER(10,0), 
	"PRODUCTCAT_ID" NUMBER(10,0), 
	"MERK" NVARCHAR2(255), 
	"SERIE" NVARCHAR2(255), 
	"TYPENUMMER" NVARCHAR2(255), 
	"PRIJS" NUMBER(19,2) DEFAULT (0)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE PRODUCTCAT
--------------------------------------------------------

  CREATE TABLE "PRODUCTCAT" 
   (	"ID" NUMBER(10,0), 
	"PRODUCTCAT_ID" NUMBER(10,0), 
	"NAAM" NVARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE PRODUCTEXEMPLAAR
--------------------------------------------------------

  CREATE TABLE "PRODUCTEXEMPLAAR" 
   (	"ID" NUMBER(10,0), 
	"PRODUCT_ID" NUMBER(10,0), 
	"VOLGNUMMER" NUMBER(10,0) DEFAULT (0), 
	"BARCODE" NVARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE RESERVERING
--------------------------------------------------------

  CREATE TABLE "RESERVERING" 
   (	"ID" NUMBER(10,0), 
	"PERSOON_ID" NUMBER(10,0), 
	"DATUMSTART" DATE, 
	"DATUMEINDE" DATE, 
	"BETAALD" NUMBER(1,0) DEFAULT (0)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE RESERVERING_POLSBANDJE
--------------------------------------------------------

  CREATE TABLE "RESERVERING_POLSBANDJE" 
   (	"ID" NUMBER(10,0), 
	"RESERVERING_ID" NUMBER(10,0), 
	"POLSBANDJE_ID" NUMBER(10,0), 
	"ACCOUNT_ID" NUMBER(10,0), 
	"AANWEZIG" NUMBER(1,0) DEFAULT (0)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE SPECIFICATIE
--------------------------------------------------------

  CREATE TABLE "SPECIFICATIE" 
   (	"ID" NUMBER(10,0), 
	"NAAM" NVARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL FOR TABLE VERHUUR
--------------------------------------------------------

  CREATE TABLE "VERHUUR" 
   (	"ID" NUMBER(10,0), 
	"PRODUCTEXEMPLAAR_ID" NUMBER(10,0), 
	"RES_PB_ID" NUMBER(10,0), 
	"DATUMIN" DATE, 
	"DATUMUIT" DATE, 
	"PRIJS" NUMBER(19,2) DEFAULT (0), 
	"BETAALD" NUMBER(1,0) DEFAULT (0)
   ) ;



--------------------------------------------------------
--  DDL FOR INDEX RESERVERING_ID2
--------------------------------------------------------

  CREATE INDEX "RESERVERING_ID2" ON "PLEK_RESERVERING" ("RESERVERING_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX CATEGORIE_ID
--------------------------------------------------------

  CREATE INDEX "CATEGORIE_ID" ON "CATEGORIE" ("CATEGORIE_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY8
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY8" ON "PRODUCTCAT" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX BIJDRAGE_ID
--------------------------------------------------------

  CREATE INDEX "BIJDRAGE_ID" ON "ACCOUNT_BIJDRAGE" ("BIJDRAGE_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX POSTCODE
--------------------------------------------------------

  CREATE INDEX "POSTCODE" ON "LOCATIE" ("POSTCODE") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX ACCOUNT_ID1
--------------------------------------------------------

  CREATE INDEX "ACCOUNT_ID1" ON "BIJDRAGE" ("ACCOUNT_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX ACCOUNT_ID2
--------------------------------------------------------

  CREATE INDEX "ACCOUNT_ID2" ON "ACCOUNT_BIJDRAGE" ("ACCOUNT_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX LOCATIE_ID
--------------------------------------------------------

  CREATE INDEX "LOCATIE_ID" ON "EVENT" ("LOCATIE_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY17
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY17" ON "PRODUCT" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX GEBRUIKERSNAAM
--------------------------------------------------------

  CREATE UNIQUE INDEX "GEBRUIKERSNAAM" ON "ACCOUNT" ("GEBRUIKERSNAAM") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX BIJDRAGE_BERICHTBIJDRAGE_ID
--------------------------------------------------------

  CREATE INDEX "BIJDRAGE_BERICHTBIJDRAGE_ID" ON "BIJDRAGE_BERICHT" ("BIJDRAGE_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PLEK_RESERVERING
--------------------------------------------------------

  CREATE UNIQUE INDEX "PLEK_RESERVERING" ON "PLEK_RESERVERING" ("PLEK_ID", "RESERVERING_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY11
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY11" ON "ACCOUNT_BIJDRAGE" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PLEK_SPECIFICATIE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PLEK_SPECIFICATIE" ON "PLEK_SPECIFICATIE" ("PLEK_ID", "SPECIFICATIE_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX ACCOUNT_ID
--------------------------------------------------------

  CREATE INDEX "ACCOUNT_ID" ON "RESERVERING_POLSBANDJE" ("ACCOUNT_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY7
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY7" ON "EVENT" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX POLSBANDJE_ID
--------------------------------------------------------

  CREATE INDEX "POLSBANDJE_ID" ON "RESERVERING_POLSBANDJE" ("POLSBANDJE_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY9
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY9" ON "CATEGORIE" ("BIJDRAGE_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PLEK_ID
--------------------------------------------------------

  CREATE INDEX "PLEK_ID" ON "PLEK_RESERVERING" ("PLEK_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX LOCATIE_ID1
--------------------------------------------------------

  CREATE INDEX "LOCATIE_ID1" ON "PLEK" ("LOCATIE_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY2
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY2" ON "PERSOON" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX NAAM
--------------------------------------------------------

  CREATE UNIQUE INDEX "NAAM" ON "LOCATIE" ("NAAM") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX RESERVERING_ACCOUNT
--------------------------------------------------------

  CREATE UNIQUE INDEX "RESERVERING_ACCOUNT" ON "RESERVERING_POLSBANDJE" ("RESERVERING_ID", "ACCOUNT_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY6
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY6" ON "RESERVERING" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX NAAM1
--------------------------------------------------------

  CREATE UNIQUE INDEX "NAAM1" ON "PRODUCTCAT" ("NAAM") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY1
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY1" ON "RESERVERING_POLSBANDJE" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX RFID
--------------------------------------------------------

  CREATE UNIQUE INDEX "RFID" ON "POLSBANDJE" ("BARCODE") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX LOCATIE_NUMMER
--------------------------------------------------------

  CREATE UNIQUE INDEX "LOCATIE_NUMMER" ON "PLEK" ("LOCATIE_ID", "NUMMER") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRODUCTVERHUUR
--------------------------------------------------------

  CREATE INDEX "PRODUCTVERHUUR" ON "VERHUUR" ("PRODUCTEXEMPLAAR_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY13
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY13" ON "BIJDRAGE" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PERSOON_ID
--------------------------------------------------------

  CREATE INDEX "PERSOON_ID" ON "RESERVERING" ("PERSOON_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX NAAM_DATUMSTART
--------------------------------------------------------

  CREATE UNIQUE INDEX "NAAM_DATUMSTART" ON "EVENT" ("NAAM", "DATUMSTART") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY14
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY14" ON "LOCATIE" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY16
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY16" ON "POLSBANDJE" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRODUCTCAT_ID
--------------------------------------------------------

  CREATE INDEX "PRODUCTCAT_ID" ON "PRODUCTCAT" ("PRODUCTCAT_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX RESERVERING_POLSBANDJE
--------------------------------------------------------

  CREATE UNIQUE INDEX "RESERVERING_POLSBANDJE" ON "RESERVERING_POLSBANDJE" ("RESERVERING_ID", "POLSBANDJE_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX BERICHT_ID
--------------------------------------------------------

  CREATE INDEX "BERICHT_ID" ON "BIJDRAGE_BERICHT" ("BERICHT_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX NAAM2
--------------------------------------------------------

  CREATE UNIQUE INDEX "NAAM2" ON "SPECIFICATIE" ("NAAM") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX NUMMER
--------------------------------------------------------

  CREATE INDEX "NUMMER" ON "PLEK" ("NUMMER") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX RESERVERING_ID
--------------------------------------------------------

  CREATE INDEX "RESERVERING_ID" ON "VERHUUR" ("RES_PB_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY15
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY15" ON "VERHUUR" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX CATEGORIE_ID1
--------------------------------------------------------

  CREATE INDEX "CATEGORIE_ID1" ON "BESTAND" ("CATEGORIE_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY4
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY4" ON "BESTAND" ("BIJDRAGE_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY18
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY18" ON "PRODUCTEXEMPLAAR" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY19
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY19" ON "PLEK" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY3
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY3" ON "ACCOUNT" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PLEK_ID1
--------------------------------------------------------

  CREATE INDEX "PLEK_ID1" ON "PLEK_SPECIFICATIE" ("PLEK_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY12
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY12" ON "PLEK_RESERVERING" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX ACCOUNT_BIJDRAGE
--------------------------------------------------------

  CREATE UNIQUE INDEX "ACCOUNT_BIJDRAGE" ON "ACCOUNT_BIJDRAGE" ("ACCOUNT_ID", "BIJDRAGE_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX SPECIFICATIEPLEK_SPECIFICATIE
--------------------------------------------------------

  CREATE INDEX "SPECIFICATIEPLEK_SPECIFICATIE" ON "PLEK_SPECIFICATIE" ("SPECIFICATIE_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRODUCT_VOLGNUMMER
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRODUCT_VOLGNUMMER" ON "PRODUCTEXEMPLAAR" ("PRODUCT_ID", "VOLGNUMMER") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY10
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY10" ON "SPECIFICATIE" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY5
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY5" ON "PLEK_SPECIFICATIE" ("ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX RESERVERING_ID1
--------------------------------------------------------

  CREATE INDEX "RESERVERING_ID1" ON "RESERVERING_POLSBANDJE" ("RESERVERING_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRODUCTCAT_ID1
--------------------------------------------------------

  CREATE INDEX "PRODUCTCAT_ID1" ON "PRODUCT" ("PRODUCTCAT_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRODUCTPRODUCTEXEMPLAAR
--------------------------------------------------------

  CREATE INDEX "PRODUCTPRODUCTEXEMPLAAR" ON "PRODUCTEXEMPLAAR" ("PRODUCT_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX PRIMARYKEY
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRIMARYKEY" ON "BERICHT" ("BIJDRAGE_ID") 
  ;
--------------------------------------------------------
--  DDL FOR INDEX BARCODE
--------------------------------------------------------

  CREATE UNIQUE INDEX "BARCODE" ON "PRODUCTEXEMPLAAR" ("BARCODE") 
  ;
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE ACCOUNT_BIJDRAGE
--------------------------------------------------------

  ALTER TABLE "ACCOUNT_BIJDRAGE" ADD CONSTRAINT "PRIMARYKEY11" PRIMARY KEY ("ID");
 
  ALTER TABLE "ACCOUNT_BIJDRAGE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "ACCOUNT_BIJDRAGE" MODIFY ("ACCOUNT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ACCOUNT_BIJDRAGE" MODIFY ("BIJDRAGE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ACCOUNT_BIJDRAGE" MODIFY ("LIKE" NOT NULL ENABLE);
 
  ALTER TABLE "ACCOUNT_BIJDRAGE" MODIFY ("ONGEWENST" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE LOCATIE
--------------------------------------------------------

  ALTER TABLE "LOCATIE" ADD CONSTRAINT "PRIMARYKEY14" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "LOCATIE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "LOCATIE" MODIFY ("NAAM" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE RESERVERING
--------------------------------------------------------

  ALTER TABLE "RESERVERING" ADD CONSTRAINT "PRIMARYKEY6" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "RESERVERING" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "RESERVERING" MODIFY ("PERSOON_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RESERVERING" MODIFY ("BETAALD" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE PLEK
--------------------------------------------------------

  ALTER TABLE "PLEK" ADD CONSTRAINT "PRIMARYKEY19" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "PLEK" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "PLEK" MODIFY ("LOCATIE_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE EVENT
--------------------------------------------------------

  ALTER TABLE "EVENT" ADD CONSTRAINT "PRIMARYKEY7" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "EVENT" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "EVENT" MODIFY ("NAAM" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE PRODUCTCAT
--------------------------------------------------------

  ALTER TABLE "PRODUCTCAT" ADD CONSTRAINT "PRIMARYKEY8" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "PRODUCTCAT" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "PRODUCTCAT" MODIFY ("NAAM" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE SPECIFICATIE
--------------------------------------------------------

  ALTER TABLE "SPECIFICATIE" ADD CONSTRAINT "PRIMARYKEY10" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "SPECIFICATIE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "SPECIFICATIE" MODIFY ("NAAM" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE RESERVERING_POLSBANDJE
--------------------------------------------------------

  ALTER TABLE "RESERVERING_POLSBANDJE" ADD CONSTRAINT "PRIMARYKEY1" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "RESERVERING_POLSBANDJE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "RESERVERING_POLSBANDJE" MODIFY ("RESERVERING_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RESERVERING_POLSBANDJE" MODIFY ("POLSBANDJE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RESERVERING_POLSBANDJE" MODIFY ("ACCOUNT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RESERVERING_POLSBANDJE" MODIFY ("AANWEZIG" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE CATEGORIE
--------------------------------------------------------

  ALTER TABLE "CATEGORIE" ADD CONSTRAINT "PRIMARYKEY9" PRIMARY KEY ("BIJDRAGE_ID") ENABLE;
 
  ALTER TABLE "CATEGORIE" MODIFY ("BIJDRAGE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CATEGORIE" MODIFY ("NAAM" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE PERSOON
--------------------------------------------------------

  ALTER TABLE "PERSOON" ADD CONSTRAINT "PRIMARYKEY2" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "PERSOON" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "PERSOON" MODIFY ("VOORNAAM" NOT NULL ENABLE);
 
  ALTER TABLE "PERSOON" MODIFY ("ACHTERNAAM" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE PLEK_RESERVERING
--------------------------------------------------------

  ALTER TABLE "PLEK_RESERVERING" ADD CONSTRAINT "PRIMARYKEY12" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "PLEK_RESERVERING" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "PLEK_RESERVERING" MODIFY ("PLEK_ID" NOT NULL ENABLE);
 
  ALTER TABLE "PLEK_RESERVERING" MODIFY ("RESERVERING_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE PLEK_SPECIFICATIE
--------------------------------------------------------

  ALTER TABLE "PLEK_SPECIFICATIE" ADD CONSTRAINT "PRIMARYKEY5" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "PLEK_SPECIFICATIE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "PLEK_SPECIFICATIE" MODIFY ("SPECIFICATIE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "PLEK_SPECIFICATIE" MODIFY ("PLEK_ID" NOT NULL ENABLE);
 
  ALTER TABLE "PLEK_SPECIFICATIE" MODIFY ("WAARDE" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE ACCOUNT
--------------------------------------------------------

  ALTER TABLE "ACCOUNT" ADD CONSTRAINT "PRIMARYKEY3" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "ACCOUNT" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "ACCOUNT" MODIFY ("EMAIL" NOT NULL ENABLE);
 
  ALTER TABLE "ACCOUNT" MODIFY ("ACTIVATIEHASH" NOT NULL ENABLE);
 
  ALTER TABLE "ACCOUNT" MODIFY ("GEACTIVEERD" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE BIJDRAGE
--------------------------------------------------------

  ALTER TABLE "BIJDRAGE" ADD CONSTRAINT "PRIMARYKEY13" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "BIJDRAGE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "BIJDRAGE" MODIFY ("ACCOUNT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "BIJDRAGE" MODIFY ("SOORT" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE PRODUCT
--------------------------------------------------------

  ALTER TABLE "PRODUCT" ADD CONSTRAINT "PRIMARYKEY17" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "PRODUCT" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "PRODUCT" MODIFY ("PRODUCTCAT_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE BERICHT
--------------------------------------------------------

  ALTER TABLE "BERICHT" ADD CONSTRAINT "PRIMARYKEY" PRIMARY KEY ("BIJDRAGE_ID");
 
  ALTER TABLE "BERICHT" MODIFY ("BIJDRAGE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "BERICHT" MODIFY ("INHOUD" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE BESTAND
--------------------------------------------------------

  ALTER TABLE "BESTAND" ADD CONSTRAINT "PRIMARYKEY4" PRIMARY KEY ("BIJDRAGE_ID") ENABLE;
 
  ALTER TABLE "BESTAND" MODIFY ("BIJDRAGE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "BESTAND" MODIFY ("CATEGORIE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "BESTAND" MODIFY ("BESTANDSLOCATIE" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE VERHUUR
--------------------------------------------------------

  ALTER TABLE "VERHUUR" ADD CONSTRAINT "PRIMARYKEY15" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "VERHUUR" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "VERHUUR" MODIFY ("BETAALD" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE PRODUCTEXEMPLAAR
--------------------------------------------------------

  ALTER TABLE "PRODUCTEXEMPLAAR" ADD CONSTRAINT "PRIMARYKEY18" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "PRODUCTEXEMPLAAR" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "PRODUCTEXEMPLAAR" MODIFY ("PRODUCT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "PRODUCTEXEMPLAAR" MODIFY ("VOLGNUMMER" NOT NULL ENABLE);
--------------------------------------------------------
--  CONSTRAINTS FOR TABLE POLSBANDJE
--------------------------------------------------------

  ALTER TABLE "POLSBANDJE" ADD CONSTRAINT "PRIMARYKEY16" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "POLSBANDJE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "POLSBANDJE" MODIFY ("BARCODE" NOT NULL ENABLE);
 
  ALTER TABLE "POLSBANDJE" MODIFY ("ACTIEF" NOT NULL ENABLE);
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE ACCOUNT_BIJDRAGE
--------------------------------------------------------

  ALTER TABLE "ACCOUNT_BIJDRAGE" ADD CONSTRAINT "ACCOUNTACCOUNT_BIJDRAGE" FOREIGN KEY ("ACCOUNT_ID")
	  REFERENCES "ACCOUNT" ("ID") ENABLE;
 
  ALTER TABLE "ACCOUNT_BIJDRAGE" ADD CONSTRAINT "BIJDRAGEACCOUNT_BIJDRAGE" FOREIGN KEY ("BIJDRAGE_ID")
	  REFERENCES "BIJDRAGE" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE BERICHT
--------------------------------------------------------

  ALTER TABLE "BERICHT" ADD CONSTRAINT "BIJDRAGEBERICHT" FOREIGN KEY ("BIJDRAGE_ID")
	  REFERENCES "BIJDRAGE" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE BESTAND
--------------------------------------------------------

  ALTER TABLE "BESTAND" ADD CONSTRAINT "BIJDRAGEBESTAND" FOREIGN KEY ("BIJDRAGE_ID")
	  REFERENCES "BIJDRAGE" ("ID") ON DELETE CASCADE ENABLE;
 
  ALTER TABLE "BESTAND" ADD CONSTRAINT "CATEGORIEBESTAND" FOREIGN KEY ("CATEGORIE_ID")
	  REFERENCES "CATEGORIE" ("BIJDRAGE_ID") ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE BIJDRAGE
--------------------------------------------------------

  ALTER TABLE "BIJDRAGE" ADD CONSTRAINT "ACCOUNTBIJDRAGE" FOREIGN KEY ("ACCOUNT_ID")
	  REFERENCES "ACCOUNT" ("ID") ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE BIJDRAGE_BERICHT
--------------------------------------------------------

  ALTER TABLE "BIJDRAGE_BERICHT" ADD CONSTRAINT "BERICHTBIJDRAGE_BERICHT" FOREIGN KEY ("BERICHT_ID")
	  REFERENCES "BERICHT" ("BIJDRAGE_ID") ENABLE;
 
  ALTER TABLE "BIJDRAGE_BERICHT" ADD CONSTRAINT "BIJDRAGEBIJDRAGE_BERICHT" FOREIGN KEY ("BIJDRAGE_ID")
	  REFERENCES "BIJDRAGE" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE CATEGORIE
--------------------------------------------------------

  ALTER TABLE "CATEGORIE" ADD CONSTRAINT "BIJDRAGECATEGORIE" FOREIGN KEY ("BIJDRAGE_ID")
	  REFERENCES "BIJDRAGE" ("ID") ON DELETE CASCADE ENABLE;
 
  ALTER TABLE "CATEGORIE" ADD CONSTRAINT "CATEGORIECATEGORIE" FOREIGN KEY ("CATEGORIE_ID")
	  REFERENCES "CATEGORIE" ("BIJDRAGE_ID") ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE EVENT
--------------------------------------------------------

  ALTER TABLE "EVENT" ADD CONSTRAINT "LOCATIEEVENT" FOREIGN KEY ("LOCATIE_ID")
	  REFERENCES "LOCATIE" ("ID") ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE PLEK
--------------------------------------------------------

  ALTER TABLE "PLEK" ADD CONSTRAINT "LOCATIEPLEK" FOREIGN KEY ("LOCATIE_ID")
	  REFERENCES "LOCATIE" ("ID") ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE PLEK_RESERVERING
--------------------------------------------------------

  ALTER TABLE "PLEK_RESERVERING" ADD CONSTRAINT "PLEKPLEK_RESERVERING" FOREIGN KEY ("PLEK_ID")
	  REFERENCES "PLEK" ("ID") ENABLE;
 
  ALTER TABLE "PLEK_RESERVERING" ADD CONSTRAINT "RESERVERINGPLEK_RESERVERING" FOREIGN KEY ("RESERVERING_ID")
	  REFERENCES "RESERVERING" ("ID") ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE PLEK_SPECIFICATIE
--------------------------------------------------------

  ALTER TABLE "PLEK_SPECIFICATIE" ADD CONSTRAINT "PLEKPLEK_SPECIFICATIE" FOREIGN KEY ("PLEK_ID")
	  REFERENCES "PLEK" ("ID") ENABLE;
 
  ALTER TABLE "PLEK_SPECIFICATIE" ADD CONSTRAINT "SPECIFICATIEPLEK_SPECIFICATIE" FOREIGN KEY ("SPECIFICATIE_ID")
	  REFERENCES "SPECIFICATIE" ("ID") ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE PRODUCT
--------------------------------------------------------

  ALTER TABLE "PRODUCT" ADD CONSTRAINT "PRODUCTCATPRODUCT" FOREIGN KEY ("PRODUCTCAT_ID")
	  REFERENCES "PRODUCTCAT" ("ID") ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE PRODUCTCAT
--------------------------------------------------------

  ALTER TABLE "PRODUCTCAT" ADD CONSTRAINT "PRODUCTCATPRODUCTCAT" FOREIGN KEY ("PRODUCTCAT_ID")
	  REFERENCES "PRODUCTCAT" ("ID") ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE PRODUCTEXEMPLAAR
--------------------------------------------------------

  ALTER TABLE "PRODUCTEXEMPLAAR" ADD CONSTRAINT "PRODUCTPRODUCTEXEMPLAAR" FOREIGN KEY ("PRODUCT_ID")
	  REFERENCES "PRODUCT" ("ID") ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE RESERVERING
--------------------------------------------------------

  ALTER TABLE "RESERVERING" ADD CONSTRAINT "PERSOONRESERVERING" FOREIGN KEY ("PERSOON_ID")
	  REFERENCES "PERSOON" ("ID") ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE RESERVERING_POLSBANDJE
--------------------------------------------------------

  ALTER TABLE "RESERVERING_POLSBANDJE" ADD CONSTRAINT "ACCOUNTRESERVERING_POLSBANDJE" FOREIGN KEY ("ACCOUNT_ID")
	  REFERENCES "ACCOUNT" ("ID") ENABLE;
 
  ALTER TABLE "RESERVERING_POLSBANDJE" ADD CONSTRAINT "POLSBANDJERESERVERING_POLSBAND" FOREIGN KEY ("POLSBANDJE_ID")
	  REFERENCES "POLSBANDJE" ("ID") ENABLE;
 
  ALTER TABLE "RESERVERING_POLSBANDJE" ADD CONSTRAINT "RESERVERINGRESERVERING_POLSBAN" FOREIGN KEY ("RESERVERING_ID")
	  REFERENCES "RESERVERING" ("ID") ENABLE;
--------------------------------------------------------
--  REF CONSTRAINTS FOR TABLE VERHUUR
--------------------------------------------------------

  ALTER TABLE "VERHUUR" ADD CONSTRAINT "PRODUCTVERHUUR" FOREIGN KEY ("PRODUCTEXEMPLAAR_ID")
	  REFERENCES "PRODUCTEXEMPLAAR" ("ID") ENABLE;
 
  ALTER TABLE "VERHUUR" ADD CONSTRAINT "RESERVERING_POLSBANDJEVERHUUR" FOREIGN KEY ("RES_PB_ID")
	  REFERENCES "RESERVERING_POLSBANDJE" ("ID") ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER ACCOUNT_BIJDRAGE_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ACCOUNT_BIJDRAGE_FCTG_BI" BEFORE INSERT ON "ACCOUNT_BIJDRAGE"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT ACCOUNT_BIJDRAGE_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "ACCOUNT_BIJDRAGE_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER ACCOUNT_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "ACCOUNT_FCTG_BI" BEFORE INSERT ON "ACCOUNT"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT ACCOUNT_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "ACCOUNT_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER BIJDRAGE_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "BIJDRAGE_FCTG_BI" BEFORE INSERT ON "BIJDRAGE"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT BIJDRAGE_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "BIJDRAGE_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER EVENT_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "EVENT_FCTG_BI" BEFORE INSERT ON "EVENT"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT EVENT_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "EVENT_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER LOCATIE_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "LOCATIE_FCTG_BI" BEFORE INSERT ON "LOCATIE"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT LOCATIE_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "LOCATIE_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER PERSOON_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "PERSOON_FCTG_BI" BEFORE INSERT ON "PERSOON"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT PERSOON_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "PERSOON_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER PLEK_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "PLEK_FCTG_BI" BEFORE INSERT ON "PLEK"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT PLEK_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "PLEK_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER PLEK_RESERVERING_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "PLEK_RESERVERING_FCTG_BI" BEFORE INSERT ON "PLEK_RESERVERING"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT PLEK_RESERVERING_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "PLEK_RESERVERING_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER PLEK_SPECIFICATIE_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "PLEK_SPECIFICATIE_FCTG_BI" BEFORE INSERT ON "PLEK_SPECIFICATIE"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT PLEK_SPECIFICATIE_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "PLEK_SPECIFICATIE_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER POLSBANDJE_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "POLSBANDJE_FCTG_BI" BEFORE INSERT ON "POLSBANDJE"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT POLSBANDJE_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "POLSBANDJE_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER PRODUCTCAT_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "PRODUCTCAT_FCTG_BI" BEFORE INSERT ON "PRODUCTCAT"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT PRODUCTCAT_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "PRODUCTCAT_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER PRODUCTEXEMPLAAR_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "PRODUCTEXEMPLAAR_FCTG_BI" BEFORE INSERT ON "PRODUCTEXEMPLAAR"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT PRODUCTEXEMPLAAR_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "PRODUCTEXEMPLAAR_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER PRODUCT_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "PRODUCT_FCTG_BI" BEFORE INSERT ON "PRODUCT"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT PRODUCT_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "PRODUCT_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER RESERVERING_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "RESERVERING_FCTG_BI" BEFORE INSERT ON "RESERVERING"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT RESERVERING_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "RESERVERING_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER RESERVERING_POLSBANDJE_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "RESERVERING_POLSBANDJE_FCTG_BI" BEFORE INSERT ON "RESERVERING_POLSBANDJE"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT RESERVERING_POLSBANDJE_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "RESERVERING_POLSBANDJE_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER SPECIFICATIE_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "SPECIFICATIE_FCTG_BI" BEFORE INSERT ON "SPECIFICATIE"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT SPECIFICATIE_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "SPECIFICATIE_FCTG_BI" ENABLE;
--------------------------------------------------------
--  DDL FOR TRIGGER VERHUUR_FCTG_BI
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "VERHUUR_FCTG_BI" BEFORE INSERT ON "VERHUUR"
FOR EACH ROW
 WHEN (NEW."ID" IS NULL) BEGIN
  SELECT VERHUUR_FCSEQ.NEXTVAL INTO :NEW."ID" FROM DUAL;
END;
/
ALTER TRIGGER "VERHUUR_FCTG_BI" ENABLE;

INSERT INTO LOCATIE (ID,"NAAM","STRAAT","NR","POSTCODE","PLAATS") VALUES (LOCATIE_FCSEQ.nextval,'CAMPING DE VALKENHOF','Edisonstraat','163','5621HN','Eindhoven');
COMMIT;
INSERT INTO ACCOUNT (ID,"GEBRUIKERSNAAM","EMAIL","ACTIVATIEHASH","GEACTIVEERD","PASSWORD", "ROL") VALUES (ACCOUNT_FCSEQ.nextval,'ADMIN','ADMIN@BLA.NL','sJB7lEpWAQ','1','ADMIN','ADMIN');
COMMIT;
INSERT INTO EVENT (ID,"LOCATIE_ID","NAAM","DATUMSTART","DATUMEINDE","MAXBEZOEKERS") VALUES (EVENT_FCSEQ.nextval,'1','SME DE VALKENHOF 2014',TO_DATE('27-DEC-13 00:00:00','DD-MON-RR HH24:MI:SS'),TO_DATE('30-DEC-13 00:00:00','DD-MON-RR HH24:MI:SS'),'100');
COMMIT;
INSERT INTO PERSOON (ID,"VOORNAAM","TUSSENVOEGSEL","ACHTERNAAM","STRAAT","HUISNR","WOONPLAATS","BANKNR") VALUES (PERSOON_FCSEQ.nextval,'JAN',NULL,'PIETERSEN','RACHELSMOLEN','1','5611MA','NL91ABNA0417164300');
INSERT INTO PERSOON (ID,"VOORNAAM","TUSSENVOEGSEL","ACHTERNAAM","STRAAT","HUISNR","WOONPLAATS","BANKNR") VALUES (PERSOON_FCSEQ.nextval,'ADMIN',NULL,'ADMINSON','RACHELSMOLEN','1','5611MA','NL91ABNA0417154300');
INSERT INTO PERSOON (ID,"VOORNAAM","TUSSENVOEGSEL","ACHTERNAAM","STRAAT","HUISNR","WOONPLAATS","BANKNR") VALUES (PERSOON_FCSEQ.nextval,'THOM','VAN','POPPEL','WETERINGSTRAAT','46','5555KN','NL91ABNA04171543010');
INSERT INTO PERSOON (ID,"VOORNAAM","TUSSENVOEGSEL","ACHTERNAAM","STRAAT","HUISNR","WOONPLAATS","BANKNR") VALUES (PERSOON_FCSEQ.nextval,'BERRY',NULL,'VERSCHUEREN','SLALAAN','8947Y','5617AA','NL91RABO04171543010');
INSERT INTO PERSOON (ID,"VOORNAAM","TUSSENVOEGSEL","ACHTERNAAM","STRAAT","HUISNR","WOONPLAATS","BANKNR") VALUES (PERSOON_FCSEQ.nextval,'RUUD',NULL,'SCHROEN','BLOEDLAPSTRAAT','1','5083PA','NL91ABNA04171543019');
INSERT INTO PERSOON (ID,"VOORNAAM","TUSSENVOEGSEL","ACHTERNAAM","STRAAT","HUISNR","WOONPLAATS","BANKNR") VALUES (PERSOON_FCSEQ.nextval,'SANDER',NULL,'KOCH','PANTOFFELWEG','12','5083AP','NL91ABNA09871543019');
INSERT INTO PERSOON (ID,"VOORNAAM","TUSSENVOEGSEL","ACHTERNAAM","STRAAT","HUISNR","WOONPLAATS","BANKNR") VALUES (PERSOON_FCSEQ.nextval,'JONNE','VAN','DREVEN','PIERKADE','43','9999ZZ','NL91RABO19871543019');
INSERT INTO PERSOON (ID,"VOORNAAM","TUSSENVOEGSEL","ACHTERNAAM","STRAAT","HUISNR","WOONPLAATS","BANKNR") VALUES (PERSOON_FCSEQ.nextval,'JEROEN',NULL,'PULLICH','SCHEMERHOF','90','0909OI','NL91ABNA09871543019');
COMMIT;
INSERT INTO PLEK (ID,"LOCATIE_ID","NUMMER","CAPACITEIT") VALUES (PLEK_FCSEQ.nextval,'1','1','5');
INSERT INTO PLEK (ID,"LOCATIE_ID","NUMMER","CAPACITEIT") VALUES (PLEK_FCSEQ.nextval,'1','2','5');
INSERT INTO PLEK (ID,"LOCATIE_ID","NUMMER","CAPACITEIT") VALUES (PLEK_FCSEQ.nextval,'1','3','5');
INSERT INTO PLEK (ID,"LOCATIE_ID","NUMMER","CAPACITEIT") VALUES (PLEK_FCSEQ.nextval,'1','4','5');
INSERT INTO PLEK (ID,"LOCATIE_ID","NUMMER","CAPACITEIT") VALUES (PLEK_FCSEQ.nextval,'1','5','5');
COMMIT;
INSERT INTO SPECIFICATIE (ID,"NAAM") VALUES (SPECIFICATIE_FCSEQ.nextval,'AFMETING');
INSERT INTO SPECIFICATIE (ID,"NAAM") VALUES (SPECIFICATIE_FCSEQ.nextval,'COMFORTPLEK');
INSERT INTO SPECIFICATIE (ID,"NAAM") VALUES (SPECIFICATIE_FCSEQ.nextval,'COORDINAAT X');
INSERT INTO SPECIFICATIE (ID,"NAAM") VALUES (SPECIFICATIE_FCSEQ.nextval,'COORDINAAT Y');
INSERT INTO SPECIFICATIE (ID,"NAAM") VALUES (SPECIFICATIE_FCSEQ.nextval,'HANDICAP GESCHIKT');
INSERT INTO SPECIFICATIE (ID,"NAAM") VALUES (SPECIFICATIE_FCSEQ.nextval,'KRAAN BESCHIKBAAR');
COMMIT;
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'2','1','JA');
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'2','2','JA');
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'3','3','JA');
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'4','1','30');
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'4','2','30');
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'4','3','30');
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'5','1','JA');
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'5','2','JA');
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'5','3','NEE');
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'6','1','100');
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'1','1','100');
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'6','2','200');
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'1','2','150');
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'6','3','200');
INSERT INTO PLEK_SPECIFICATIE ("ID","SPECIFICATIE_ID","PLEK_ID","WAARDE") VALUES (PLEK_SPECIFICATIE_FCSEQ.nextval,'1','3','200');
COMMIT;
INSERT INTO PRODUCTCAT (ID,"PRODUCTCAT_ID","NAAM") VALUES (PRODUCTCAT_FCSEQ.nextval,NULL,'MUIS (USB)');
INSERT INTO PRODUCTCAT (ID,"PRODUCTCAT_ID","NAAM") VALUES (PRODUCTCAT_FCSEQ.nextval,NULL,'WIRELESS N ROUTER');
INSERT INTO PRODUCTCAT (ID,"PRODUCTCAT_ID","NAAM") VALUES (PRODUCTCAT_FCSEQ.nextval,NULL,'TABLETS');
COMMIT;
INSERT INTO PRODUCT (ID,"PRODUCTCAT_ID","MERK","SERIE","TYPENUMMER","PRIJS") VALUES (PRODUCT_FCSEQ.nextval,'1','SAMSUNG','NEXUS 10','1000','10');
INSERT INTO PRODUCT (ID,"PRODUCTCAT_ID","MERK","SERIE","TYPENUMMER","PRIJS") VALUES (PRODUCT_FCSEQ.nextval,'2','LOGITECH','MOUSE MX REVOLUTION LASER CORDLESS','1001','2');
INSERT INTO PRODUCT (ID,"PRODUCTCAT_ID","MERK","SERIE","TYPENUMMER","PRIJS") VALUES (PRODUCT_FCSEQ.nextval,'3','ASUS','RT-N66U','1002','4');
COMMIT;
INSERT INTO PRODUCTEXEMPLAAR (ID,"PRODUCT_ID","VOLGNUMMER","BARCODE") VALUES (PRODUCTEXEMPLAAR_FCSEQ.nextval,'1','1','1000.001');
INSERT INTO PRODUCTEXEMPLAAR (ID,"PRODUCT_ID","VOLGNUMMER","BARCODE") VALUES (PRODUCTEXEMPLAAR_FCSEQ.nextval,'1','2','1000.002');
INSERT INTO PRODUCTEXEMPLAAR (ID,"PRODUCT_ID","VOLGNUMMER","BARCODE") VALUES (PRODUCTEXEMPLAAR_FCSEQ.nextval,'1','3','1000.003');
INSERT INTO PRODUCTEXEMPLAAR (ID,"PRODUCT_ID","VOLGNUMMER","BARCODE") VALUES (PRODUCTEXEMPLAAR_FCSEQ.nextval,'2','1','1001.001');
INSERT INTO PRODUCTEXEMPLAAR (ID,"PRODUCT_ID","VOLGNUMMER","BARCODE") VALUES (PRODUCTEXEMPLAAR_FCSEQ.nextval,'2','2','1001.002');
INSERT INTO PRODUCTEXEMPLAAR (ID,"PRODUCT_ID","VOLGNUMMER","BARCODE") VALUES (PRODUCTEXEMPLAAR_FCSEQ.nextval,'3','1','1002.001');
COMMIT;
--------------------------------------------------------
--  PROCEDURE VOOR HET VERWIJDEREN VAN RESERVERINGEN EN DE CHILD TABLES
--------------------------------------------------------
CREATE OR REPLACE PROCEDURE verwijderReservering(
  reserveringID NUMBER
)
AS
  isReservation NUMBER(10);
  ex_custom EXCEPTION;
  PRAGMA EXCEPTION_INIT( ex_custom, -20001 );
BEGIN

  SELECT COUNT(*) INTO isReservation FROM dual WHERE EXISTS(SELECT ID FROM Reservering WHERE ID = reserveringID);
  IF isReservation = 0 THEN
    RAISE_APPLICATION_ERROR(-20001,'Reservering bestaat niet!');
  END IF;
  
  DELETE FROM Verhuur WHERE RES_PB_ID IN (SELECT ID FROM Reservering_Polsbandje WHERE Reservering_ID = reserveringID);
  DELETE FROM Reservering_Polsbandje WHERE Reservering_ID = reserveringID;
  DELETE FROM Plek_Reservering WHERE Reservering_ID = reserveringID;
  DELETE FROM Reservering WHERE ID = reserveringID; 
  DELETE FROM Persoon WHERE ID IN (SELECT p.ID FROM Persoon p, Reservering r WHERE p.ID = r.Persoon_ID AND r.ID = reserveringID);
  
END verwijderReservering;
/
--DELETE ALL UNACTIVATED ACCOUNTS, THIS IS USED ON THE SCHEDULED JOB
CREATE OR REPLACE PROCEDURE DELETEUNACTIVE
IS
BEGIN
DELETE FROM ACCOUNT WHERE GEACTIVEERD = 0;
END;
/
EXEC DBMS_SCHEDULER.DROP_JOB('Delete_Not_Activated_Accounts');
COMMIT;
/
--JOB TO RUN EVERY SPECIFIED AMOUNT OF MINUTES
BEGIN
DBMS_SCHEDULER.CREATE_JOB (
   job_name             => 'Delete_Not_Activated_Accounts', 
   job_type             => 'STORED_PROCEDURE',
   job_action           => 'DELETEUNACTIVE',
   start_date		=>  systimestamp,
   repeat_interval      => 'FREQ=MINUTELY;INTERVAL=30',
   enabled		=>  true,
   auto_drop		=>  false,
   comments             => 'Deletes all the accounts that are not activated within 3 minutes');
END;
/
--THE PROCEDURE TO CREATE A RESERVATING AND A PERSOON AND A PLEK_RESERVERING
CREATE OR REPLACE PROCEDURE InschrijvingPlaatsen
(
P_VOORNAAM IN VARCHAR2,
P_TUSSENVOEGSEL IN VARCHAR2 DEFAULT NULL,
P_ACHTERNAAM IN VARCHAR2,
P_STRAAT IN VARCHAR2,
P_HUISNUMMER IN VARCHAR2,
P_WOONPLAATS IN VARCHAR2,
P_BANKNR IN VARCHAR2,
P_DATUMSTART IN VARCHAR2,
P_DATUMEINDE IN VARCHAR2,
P_PLEKID IN NUMBER,
OP_RESERVERINGID OUT NUMBER
)
IS
V_VOORNAAM VARCHAR2(255);
V_ACHTERNAAM VARCHAR2(255);
V_TUSSENVOEGSEL VARCHAR2(255);
V_STRAAT VARCHAR2(255);
V_HUISNUMMER VARCHAR2(255);
V_WOONPLAATS VARCHAR2(255);
V_BANKNR VARCHAR2(255);
V_DATUMSTART DATE;
V_DATUMEINDE DATE;
V_COUNTER NUMBER(20);
V_EXISTS NUMBER(20);
BEGIN
V_BANKNR := UPPER(P_BANKNR);
V_VOORNAAM := INITCAP(P_VOORNAAM);
V_ACHTERNAAM := INITCAP(P_ACHTERNAAM);
V_TUSSENVOEGSEL := LOWER(P_TUSSENVOEGSEL);
V_STRAAT := INITCAP(P_STRAAT);
V_WOONPLAATS := INITCAP(P_WOONPLAATS);
V_HUISNUMMER := LOWER(P_HUISNUMMER);
V_DATUMSTART := TO_DATE(P_DATUMSTART, 'DD/MM/YY');
V_DATUMEINDE := TO_DATE(P_DATUMEINDE, 'DD/MM/YY');
INSERT INTO PERSOON VALUES (PERSOON_FCSEQ.NEXTVAL,V_VOORNAAM,V_TUSSENVOEGSEL,V_ACHTERNAAM,V_STRAAT,V_HUISNUMMER,V_WOONPLAATS,V_BANKNR) RETURNING ID INTO V_COUNTER;
COMMIT;
INSERT INTO RESERVERING VALUES(RESERVERING_FCSEQ.NEXTVAL, V_COUNTER, V_DATUMSTART, V_DATUMEINDE, 0) RETURNING ID INTO V_COUNTER;
OP_RESERVERINGID := V_COUNTER;
COMMIT;
SELECT COUNT(ID) INTO V_EXISTS FROM PLEK WHERE ID = P_PLEKID;
IF V_EXISTS > 0
THEN
DBMS_OUTPUT.PUT_LINE(V_COUNTER || ' -- ' || P_PLEKID);
INSERT INTO PLEK_RESERVERING VALUES (PLEK_FCSEQ.NEXTVAL,P_PLEKID,V_COUNTER);
COMMIT;
ELSIF V_EXISTS = 0
THEN
RAISE_APPLICATION_ERROR(-20001,'PLEK ID DOES NOT EXIST: '||P_PLEKID);
END IF;
EXCEPTION
WHEN NO_DATA_FOUND THEN
RAISE_APPLICATION_ERROR(-20002,'NO DATA FOUND EXCEPTION');
END;

--select RUN_COUNT,LAST_START_DATE,NEXT_RUN_DATE from DBA_SCHEDULER_JOBS WHERE JOB_NAME = 'DELETE_NOT_ACTIVATED_ACCOUNTS';