﻿--USE MASTER
--DROP DATABASE PROJEKTV9;
--GO
CREATE DATABASE PROJEKTV9;
GO
USE PROJEKTV9;

--CREATING TABLES
--SLOWNIKI
CREATE TABLE MIASTA (ID_MIASTA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA VARCHAR(50) NOT NULL);
CREATE TABLE LOKALIZACJA (ID_LOKALIZACJI INT IDENTITY(1,1) PRIMARY KEY NOT NULL, SEKTOR VARCHAR(30), ALEJKA VARCHAR(30), REAGAL VARCHAR(30), POZIOM VARCHAR(30), KOSZ VARCHAR(30))
CREATE TABLE STATUS_ZAMOWIENIA (ID_STATUS_ZAMOWIENIA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA VARCHAR(30))
CREATE TABLE DOSTAWCY (ID_DOSTAWCY INT IDENTITY(1,1) PRIMARY KEY NOT NULL, MARKA VARCHAR(30), MODEL VARCHAR(30), NUMER_REJESTRACYJNY VARCHAR(7), STAWKA MONEY, NOSNOSC VARCHAR(10), GABARYTY VARCHAR(20))
CREATE TABLE PODATEK (ID_PODATEK INT IDENTITY(1,1) PRIMARY KEY NOT NULL, STAWKA FLOAT NOT NULL, DATA DATE NOT NULL);
CREATE TABLE WALUTY (ID_WALUTY INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA CHAR(30) NOT NULL, KURS_DO_PLN FLOAT(24) DEFAULT 1 NOT NULL, DATA_KURS DATE NOT NULL);
CREATE TABLE SZKOLENIA (ID_SZKOLENIA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA_SZKOLENIA VARCHAR(50) NOT NULL, OPIS_SZKOLENIA VARCHAR NULL, DATA_START DATE NOT NULL, DATA_KONIEC DATE NOT NULL);
CREATE TABLE WOLNE (ID_WOLNE INT IDENTITY(1,1) PRIMARY KEY NOT NULL, SYMBOL CHAR(10) NOT NULL, NAZWA VARCHAR(30) NOT NULL);
CREATE TABLE PRODUKT (ID_PRODUKTU INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA_PRODUKTU VARCHAR(30) NOT NULL, OPIS NVARCHAR(50) NOT NULL)
CREATE TABLE STATUS_ZLECENIA (ID_STATUSU_ZLECENIA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, ETAP VARCHAR(30))
CREATE TABLE OKRES (ID_OKRES INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA VARCHAR(50) NOT NULL);
CREATE TABLE FIRMY (ID_FIRMY INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA_FIRMY VARCHAR(30), ADRES_EMAIL VARCHAR(30), NR_TELEFONU VARCHAR(12), NIP VARCHAR(10))
CREATE TABLE PROJEKT (ID_PROJEKTU INT IDENTITY(1,1) PRIMARY KEY NOT NULL,CZY_ISTNIEJE BIT NOT NULL,KOSZT MONEY NOT NULL,CZAS_REALIZACJI DATE NOT NULL)
CREATE TABLE NARZEDZIA (ID_NARZEDZIA INT IDENTITY(1,1) PRIMARY KEY NOT NULL,NAZWA NVARCHAR(50) NOT NULL,MODEL NVARCHAR(50) NOT NULL,NR_EWIDENCYJNY NVARCHAR(20) NOT NULL,KOSZT_ZA_H MONEY NOT NULL)
CREATE TABLE SLOWNIK_PROCES_TECHNOLOGICZNY(ID_SLOWNIK_PROCES_TECHNOLOGICZNY INT IDENTITY(1,1) PRIMARY KEY NOT NULL,NAZWA_PROCESU NVARCHAR(50) NOT NULL)
CREATE TABLE PARAMETRY (ID_PARAMETR INT IDENTITY(1,1) PRIMARY KEY NOT NULL,NAZWA NVARCHAR(50) NOT NULL,JEDNOSTKA_MIARY NVARCHAR(50) NOT NULL)
CREATE TABLE MODELE_MASZYN (ID_MODEL_MASZYNY INT IDENTITY(1,1) PRIMARY KEY NOT NULL,MODEL NVARCHAR(50) NOT NULL,MARKA NVARCHAR(50) NOT NULL,TYP_MASZYNY NVARCHAR(50) NOT NULL,PRĘDKOŚĆ INT NOT NULL,POSUW INT NOT NULL,KOSZT_ZA_H MONEY NOT NULL)
CREATE TABLE MATERIAL (ID_MATERIALU INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA VARCHAR(30) NOT NULL, PELNA_NAZWA_MATERIALU VARCHAR(30) NOT NULL, OZNACZENIE_SUROWCA VARCHAR(15))
CREATE TABLE STANOWISKO (ID_STANOWISKO INT IDENTITY(1,1) PRIMARY KEY NOT NULL , NAZWA CHAR(30) NOT NULL);

--TABELE
CREATE TABLE ZLECENIA (ID_ZLECENIA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, DATA_ZLECENIA VARCHAR(8), DATA_REALIZACJI VARCHAR(8), ID_FIRMY INT FOREIGN KEY REFERENCES FIRMY(ID_FIRMY), ID_STATUS_ZLECENIA INT FOREIGN KEY REFERENCES STATUS_ZLECENIA(ID_STATUSU_ZLECENIA))
CREATE TABLE MASZYNY (ID_MASZYNY INT IDENTITY(1,1) PRIMARY KEY NOT NULL,ID_MODEL_MASZYNY INT FOREIGN KEY REFERENCES MODELE_MASZYN(ID_MODEL_MASZYNY),NR_EWIDENCYJNY NVARCHAR(20) NOT NULL)
CREATE TABLE ADRESY (ID_ADRESU INT IDENTITY(1,1) PRIMARY KEY NOT NULL, ULICA VARCHAR(30), NR_BUDYNKU VARCHAR(10), NR_LOKALU VARCHAR(10), KOD_POCZTOWY VARCHAR(5), ID_MIASTA INT FOREIGN KEY REFERENCES MIASTA(ID_MIASTA), KRAJ VARCHAR(15))
CREATE TABLE ADRESY_PRACOWNICY (ID_ADRESU INT IDENTITY(1,1) PRIMARY KEY NOT NULL, ULICA VARCHAR(30), NR_BUDYNKU VARCHAR(10), NR_LOKALU VARCHAR(10), KOD_POCZTOWY VARCHAR(5), ID_MIASTA INT FOREIGN KEY REFERENCES MIASTA(ID_MIASTA), KRAJ VARCHAR(15))
CREATE TABLE PRACOWNICY (ID_PRACOWNIK INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWISKO VARCHAR(30) NOT NULL, IMIE VARCHAR(30) NOT NULL, TELEFON VARCHAR(12) NULL, ID_ADRESU INT FOREIGN KEY REFERENCES ADRESY(ID_ADRESU),PESEL NVARCHAR(11) NOT NULL  )
CREATE TABLE PRACOWNICY_ADRESY_PRACOWNICY (ID_PRACOWNIK INT  FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK) NOT NULL, ID_ADRESU INT FOREIGN KEY REFERENCES ADRESY_PRACOWNICY(ID_ADRESU))
CREATE TABLE STANOWISKO_PRACOWNICY (ID_PRACOWNIK INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK) NOT NULL, ID_STANOWISKO INT FOREIGN KEY REFERENCES STANOWISKO(ID_STANOWISKO) NOT NULL, DATA_START DATE NOT NULL, DATA_KONIEC DATE NULL);
CREATE TABLE WOLNE_PRACOWNICY (ID_WOLNE INT FOREIGN KEY REFERENCES WOLNE(ID_WOLNE) NOT NULL, ID_PRACOWNIK INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK) NOT NULL, DATA_START DATE NOT NULL, DATA_KONIEC DATE NOT NULL);
CREATE TABLE STAWKA (ID_STAWKA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, WARTOSC MONEY NOT NULL, ID_OKRES INT FOREIGN KEY REFERENCES OKRES(ID_OKRES) NOT NULL);
CREATE TABLE STAWKA_PRACOWNICY (ID_PRACOWNIK INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK) NOT NULL, ID_STAWKA INT FOREIGN KEY REFERENCES STAWKA(ID_STAWKA)NOT NULL, DATA_START DATE NOT NULL, DATA_KONIEC DATE NULL); 
CREATE TABLE SZKOLENIE_PRACOWNICY (ID_PRACOWNIK INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK) NOT NULL, ID_SZKOLENIA INT FOREIGN KEY REFERENCES SZKOLENIA(ID_SZKOLENIA) NOT NULL);
CREATE TABLE REALIZACJA_PRODUKCJA(ID_REALIZACJA_PRODUKCJA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, ID_ZLECENIA INT FOREIGN KEY REFERENCES ZLECENIA(ID_ZLECENIA), DATA_DZIEN DATE NOT NULL, LICZBA_SZTUK INT NOT NULL)
CREATE TABLE ZESPOL_MASZYN(ID_REALIZACJA_PRODUKCJA INT FOREIGN KEY REFERENCES REALIZACJA_PRODUKCJA(ID_REALIZACJA_PRODUKCJA), ID_MASZYNY INT FOREIGN KEY REFERENCES MASZYNY(ID_MASZYNY))
CREATE TABLE ZESPOL_LUDZI(ID_REALIZACJA_PRODUKCJA INT FOREIGN KEY REFERENCES REALIZACJA_PRODUKCJA(ID_REALIZACJA_PRODUKCJA), ID_PRACOWNIK INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK))
CREATE TABLE ZESPOL_NARZEDZI(ID_REALIZACJA_PRODUKCJA INT FOREIGN KEY REFERENCES REALIZACJA_PRODUKCJA(ID_REALIZACJA_PRODUKCJA), ID_NARZEDZIA INT FOREIGN KEY REFERENCES NARZEDZIA(ID_NARZEDZIA))
CREATE TABLE ZESPOL_MATERIAL(ID_REALIZACJA_PRODUKCJA INT FOREIGN KEY REFERENCES REALIZACJA_PRODUKCJA(ID_REALIZACJA_PRODUKCJA), ID_MATERIALU INT FOREIGN KEY REFERENCES MATERIAL(ID_MATERIALU))
CREATE TABLE DOSTAWA (ID_DOSTAWY INT IDENTITY(1,1) PRIMARY KEY NOT NULL, ID_PRACOWNIKA INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK), ID_ADRESU INT FOREIGN KEY REFERENCES ADRESY(ID_ADRESU), ID_POJAZDU INT FOREIGN KEY REFERENCES DOSTAWCY(ID_DOSTAWCY), DŁUGOŚĆ_TRASY INT)
CREATE TABLE DOST_PROD (ID_PRODUKTU INT FOREIGN KEY REFERENCES PRODUKT(ID_PRODUKTU), ID_DOSTAWY INT FOREIGN KEY REFERENCES DOSTAWA(ID_DOSTAWY), ILOSC INT)
CREATE TABLE ZLEC_DOST (ID_ZLECENIA INT FOREIGN KEY REFERENCES ZLECENIA(ID_ZLECENIA), ID_DOSTAWY INT FOREIGN KEY REFERENCES DOSTAWA(ID_DOSTAWY), ILOŚĆ INT)
CREATE TABLE FAKTURY (ID_FAKTURY INT IDENTITY(1,1) PRIMARY KEY NOT NULL, ID_ZLECENIA INT FOREIGN KEY REFERENCES ZLECENIA(ID_ZLECENIA), ID_PRACOWNIKA INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK), DATA_WYSTAWIENIA VARCHAR(8))
CREATE TABLE FIRMA_ADRES (ID_FIRMY INT FOREIGN KEY REFERENCES FIRMY(ID_FIRMY), ID_ADRESU INT FOREIGN KEY REFERENCES ADRESY(ID_ADRESU))  
CREATE TABLE STANMAG_MAT (ID_LOKALIZACJI INT FOREIGN KEY REFERENCES LOKALIZACJA(ID_LOKALIZACJI), ID_MATERIALU INT FOREIGN KEY REFERENCES MATERIAL(ID_MATERIALU),ILOSC INT, DATA_WPISU VARCHAR(8))
CREATE TABLE STANMAG_PROD (ID_LOKALIZACJI INT FOREIGN KEY REFERENCES LOKALIZACJA(ID_LOKALIZACJI), ID_PRODUKTU INT FOREIGN KEY REFERENCES PRODUKT(ID_PRODUKTU),ILOSC INT, DATA_WPISU VARCHAR(8))
CREATE TABLE ZAMOWIENIA (ID_ZAMOWIENIA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, DATA_ZAMOWIENIA VARCHAR(30), DATA_REALIZACJI VARCHAR(8), ID_FIRMY INT FOREIGN KEY REFERENCES FIRMY(ID_FIRMY), ID_STATUSU_ZAM INT FOREIGN KEY REFERENCES STATUS_ZAMOWIENIA(ID_STATUS_ZAMOWIENIA)) 
CREATE TABLE ZAM_MAT (ID_ZAMOWIENIA INT FOREIGN KEY REFERENCES ZAMOWIENIA(ID_ZAMOWIENIA), ID_MATERIALU INT FOREIGN KEY REFERENCES MATERIAL(ID_MATERIALU), ILOSC INT)
CREATE TABLE ZLEC_PROD (ID_ZLECENIA INT FOREIGN KEY REFERENCES ZLECENIA(ID_ZLECENIA), ID_PRODUKTU INT FOREIGN KEY REFERENCES PRODUKT(ID_PRODUKTU), ILOSC INT NOT NULL)
CREATE TABLE PARAMETRY_MASZYNY (ID_PARAMETR INT FOREIGN KEY REFERENCES PARAMETRY(ID_PARAMETR),ID_MODEL_MASZYNY INT FOREIGN KEY REFERENCES MODELE_MASZYN(ID_MODEL_MASZYNY),WARTOŚĆ INT NOT NULL)
CREATE TABLE PROCES (ID_PROCESU INT IDENTITY(1,1) PRIMARY KEY NOT NULL,ID_SLOWNIK_PROCES_TECHNOLOGICZNY INT FOREIGN KEY REFERENCES SLOWNIK_PROCES_TECHNOLOGICZNY(ID_SLOWNIK_PROCES_TECHNOLOGICZNY),ID_MASZYNY INT FOREIGN KEY REFERENCES MASZYNY(ID_MASZYNY),NAZWA_PROCESU NVARCHAR(50) NOT NULL,CZAS_TRWANIA INT )
CREATE TABLE PROCES_NARZEDZIA (ID_NARZEDZIA INT FOREIGN KEY REFERENCES NARZEDZIA(ID_NARZEDZIA),ID_PROCESU INT FOREIGN KEY REFERENCES PROCES(ID_PROCESU))
CREATE TABLE DOKUMENTACJA (ID_DOKUMENTACJI INT IDENTITY(1,1) PRIMARY KEY NOT NULL,NR_RYSUNKU NVARCHAR(15) NOT NULL,DATA_WPROWADZENIA DATETIME NOT NULL,ID_PRACOWNIK INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK),ID_PROJEKTU INT FOREIGN KEY REFERENCES PROJEKT(ID_PROJEKTU))
CREATE TABLE DOKUMENTACJA_PROCES (ID_DOKUMENTACJI INT FOREIGN KEY REFERENCES DOKUMENTACJA(ID_DOKUMENTACJI),ID_PROCESU INT FOREIGN KEY REFERENCES PROCES(ID_PROCESU))
CREATE TABLE PARAMETRY_MATERIALU(ID_MATERIAL INT FOREIGN KEY REFERENCES MATERIAL(ID_MATERIALU),ID_PARAMETR INT FOREIGN KEY REFERENCES PARAMETRY(ID_PARAMETR),WARTOŚĆ INT NOT NULL)
CREATE TABLE POLPRODUKTY (ID_POLPRODUKTU INT IDENTITY(1,1) PRIMARY KEY NOT NULL,ID_MATERIAL INT FOREIGN KEY REFERENCES MATERIAL(ID_MATERIALU),ID_DOKUMENTACJI INT FOREIGN KEY REFERENCES DOKUMENTACJA(ID_DOKUMENTACJI),LICZBA_SZTUK INT NOT NULL)
CREATE TABLE PRODUKCJA_POLPRODUKTU (ID_POLPRODUKTU INT FOREIGN KEY REFERENCES POLPRODUKTY(ID_POLPRODUKTU),ID_PRODUKTU INT FOREIGN KEY REFERENCES PRODUKT(ID_PRODUKTU),CZAS_REALIZACJI_MONTAZU DATE NOT NULL,KOSZT_REALIZACJI_MONTAZU MONEY NOT NULL)
--TEJ TABELI NIE WYPEŁNIAMY
CREATE TABLE ZLECENIA_KOSZTY(ID_ZLECENIA INT FOREIGN KEY REFERENCES ZLECENIA(ID_ZLECENIA), KOSZT_MATERIALU INT, KOSZT_TRANSPORTU INT, KOSZT_PRODUKCJI INT, KODZT_DOSTARCZENIA INT)

