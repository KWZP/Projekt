﻿--USE MASTER
--DROP DATABASE PROJEKTV9;
--GO
CREATE DATABASE PROJEKTV9;
GO
USE PROJEKTV9;

--CREATING TABLES
<<<<<<< HEAD
CREATE TABLE Miasta (id_miasta INT IDENTITY(1,1) PRIMARY KEY NOT NULL, nazwa VARCHAR(50) NOT NULL);
CREATE TABLE ADRESY (ID_ADRESU int IDENTITY(1,1) PRIMARY KEY NOT NULL, ULICA varchar(30), NR_BUDYNKU varchar(10), NR_LOKALU varchar(10), KOD_POCZTOWY varchar(5), ID_MIASTA int FOREIGN KEY REFERENCES MIASTA(ID_MIASTA), KRAJ varchar(15))
CREATE TABLE LOKALIZACJA (ID_LOKALIZACJI int IDENTITY(1,1) PRIMARY KEY NOT NULL, SEKTOR varchar(30), ALEJKA varchar(30), REAGAL varchar(30), POZIOM varchar(30), KOSZ varchar(30))
CREATE TABLE Produkt (id_Produktu int IDENTITY(1,1) PRIMARY KEY NOT NULL, Nazwa_Produktu varchar(30) NOT NULL, Opis nvarchar(50) NOT NULL)
CREATE TABLE STATUS_ZAM (ID_STATUSUS_ZAM int IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA varchar(30))
CREATE TABLE STATUS_ZLEC (ID_STATUSU_ZLEC int IDENTITY(1,1) PRIMARY KEY NOT NULL, ETAP varchar(30))
CREATE TABLE DOSTAWCY (ID_DOSTAWCY int IDENTITY(1,1) PRIMARY KEY NOT NULL, MARKA varchar(30), MODEL varchar(30), NUMER_REJESTRACYJNY varchar(7), STAWKA money, NOSNOSC varchar(10), GABARYTY varchar(20))
CREATE TABLE Pracownicy (id_pracownik INT IDENTITY(1,1) PRIMARY KEY NOT NULL, nazwisko VARCHAR(30) NOT NULL, imie VARCHAR(30) NOT NULL, telefon VARCHAR(12) NULL, Id_Adresu int FOREIGN KEY REFERENCES Adresy(Id_Adresu),Pesel nvarchar(11) NOT NULL  )
CREATE TABLE Dostawa (id_Dostawy int IDENTITY(1,1) PRIMARY KEY NOT NULL, id_Pracownika int FOREIGN KEY REFERENCES Pracownicy(id_Pracownik), Id_Adresu int FOREIGN KEY REFERENCES Adresy(Id_Adresu), Id_Pojazdu int FOREIGN KEY REFERENCES Dostawcy(Id_Dostawcy), Długość_Trasy int)
CREATE TABLE Dost_Prod (id_Produktu int FOREIGN KEY REFERENCES Produkt(Id_Produktu), Id_Dostawy int FOREIGN KEY REFERENCES Dostawa(Id_Dostawy), Ilosc int)
CREATE TABLE Firmy (id_Firmy int IDENTITY(1,1) PRIMARY KEY NOT NULL, Nazwa_firmy varchar(30), Adres_email varchar(30), Nr_telefonu varchar(12), NIP varchar(10))
CREATE TABLE Zlecenia (id_Zlecenia int IDENTITY(1,1) PRIMARY KEY NOT NULL, Data_zlecenia varchar(8), Data_realizacji varchar(8), Id_Firmy int FOREIGN KEY REFERENCES Firmy(Id_Firmy), Id_Statusu_zlec int FOREIGN KEY REFERENCES Status_zlec(Id_Statusu_zlec))
CREATE TABLE Zlec_Dost (id_Zlecenia int FOREIGN KEY REFERENCES Zlecenia(Id_Zlecenia), Id_Dostawy int FOREIGN KEY REFERENCES Dostawa(Id_Dostawy), Ilość int)
CREATE TABLE Faktury (id_Faktury int IDENTITY(1,1) PRIMARY KEY NOT NULL, Id_Zlecenia int FOREIGN KEY REFERENCES Zlecenia(Id_Zlecenia), Id_Pracownika int FOREIGN KEY REFERENCES Pracownicy(id_Pracownik), Data_wystawienia varchar(8))
CREATE TABLE Firma_adres (id_Firmy int FOREIGN KEY REFERENCES Firmy(Id_Firmy), Id_Adresu int FOREIGN KEY REFERENCES Adresy(Id_Adresu))  
CREATE TABLE Material (id_Materialu int IDENTITY(1,1) PRIMARY KEY NOT NULL, Nazwa varchar(30) NOT NULL, Pelna_nazwa_materialu varchar(30) NOT NULL, Oznaczenie_surowca varchar(15))
CREATE TABLE StanMag_Mat (id_Lokalizacji int FOREIGN KEY REFERENCES Lokalizacja(Id_Lokalizacji), ID_Materialu int FOREIGN KEY REFERENCES Material(Id_Materialu),Ilosc int, Data_wpisu varchar(8))
CREATE TABLE StanMag_Prod (id_Lokalizacji int FOREIGN KEY REFERENCES Lokalizacja(Id_Lokalizacji), Id_Produktu int FOREIGN KEY REFERENCES Produkt(Id_Produktu),Ilosc int, Data_wpisu varchar(8))
CREATE TABLE Zamowienia (id_Zamowienia int IDENTITY(1,1) PRIMARY KEY NOT NULL, Data_zamowienia varchar(30), Data_realizacji varchar(8), Id_Firmy int FOREIGN KEY REFERENCES Firmy(Id_Firmy), Id_Statusu_zam int FOREIGN KEY REFERENCES Status_zam(Id_Statusu_zam)) 
CREATE TABLE Zam_mat (id_Zamowienia int FOREIGN KEY REFERENCES Zamowienia(id_Zamowienia), id_Materialu int FOREIGN KEY REFERENCES Material(Id_Materialu), Ilosc int)
CREATE TABLE Zlec_prod (id_Zlecenia int FOREIGN KEY REFERENCES Zlecenia(id_Zlecenia), Id_Produktu int FOREIGN KEY REFERENCES Produkt(Id_Produktu), Ilosc int NOT NULL)
CREATE TABLE Stanowisko (id_stanowisko INT IDENTITY(1,1) PRIMARY KEY NOT NULL , nazwa char(30) NOT NULL);
CREATE TABLE StanowiskoPracownicy (id_pracownik INT FOREIGN KEY REFERENCES pracownicy(id_pracownik) NOT NULL, id_stanowisko INT FOREIGN KEY REFERENCES stanowisko(id_stanowisko) NOT NULL, data_start DATE DEFAULT GETDATE() NOT NULL, data_koniec DATE NULL);
CREATE TABLE Podatek (id_podatek INT IDENTITY(1,1) PRIMARY KEY NOT NULL, stawka FLOAT NOT NULL, data DATE DEFAULT GETDATE() NOT NULL);
CREATE TABLE Waluty (id_waluty INT IDENTITY(1,1) PRIMARY KEY NOT NULL, nazwa CHAR(30) NOT NULL, kurs_do_pln float(24) DEFAULT 1 NOT NULL, data_kurs DATE DEFAULT GETDATE() NOT NULL);
CREATE TABLE Szkolenia (id_szkolenia INT IDENTITY(1,1) PRIMARY KEY NOT NULL, nazwa_szkolenia VARCHAR(50) NOT NULL, opis_szkolenia VARCHAR NULL, data_start DATE DEFAULT GETDATE() NOT NULL, data_koniec DATE NOT NULL);
CREATE TABLE Wolne (id_wolne INT IDENTITY(1,1) PRIMARY KEY NOT NULL, symbol CHAR(10) NOT NULL, nazwa VARCHAR(30) NOT NULL);
CREATE TABLE WolnePracownicy (id_wolne INT FOREIGN KEY REFERENCES wolne(id_wolne) NOT NULL, id_pracownik INT FOREIGN KEY REFERENCES pracownicy(id_pracownik) NOT NULL, data_start DATE DEFAULT GETDATE() NOT NULL, data_koniec DATE DEFAULT GETDATE() NOT NULL);
CREATE TABLE Miesiac (id_miesiac INT IDENTITY(1,1) PRIMARY KEY NOT NULL, miesiac CHAR NOT NULL);
CREATE TABLE Okres (id_okres INT IDENTITY(1,1) PRIMARY KEY NOT NULL, nazwa VARCHAR(50) NOT NULL);
CREATE TABLE Stawka (id_stawka INT IDENTITY(1,1) PRIMARY KEY NOT NULL, wartosc MONEY NOT NULL, id_okres INT FOREIGN KEY REFERENCES okres(id_okres) NOT NULL);
CREATE TABLE StawkaPracownicy (id_pracownik INT FOREIGN KEY REFERENCES pracownicy(id_pracownik) NOT NULL, id_stawka INT FOREIGN KEY REFERENCES stawka(id_stawka)NOT NULL, data_start DATE NOT NULL DEFAULT GETDATE(), data_koniec DATE NULL); 
CREATE TABLE SzkoleniePracownicy (id_pracownik INT FOREIGN KEY REFERENCES pracownicy(id_pracownik) NOT NULL, id_szkolenia INT FOREIGN KEY REFERENCES szkolenia(id_szkolenia) NOT NULL);
CREATE TABLE PARAMETRY (ID_Parametr int IDENTITY(1,1) PRIMARY KEY NOT NULL,Nazwa nvarchar(50) NOT NULL,Jednostka_miary nvarchar(50) NOT NULL)
CREATE TABLE MODELE_MASZYN (ID_Model_maszyny int IDENTITY(1,1) PRIMARY KEY NOT NULL,Model nvarchar(50) NOT NULL,Marka nvarchar(50) NOT NULL,Typ_Maszyny nvarchar(50) NOT NULL,Prędkość int NOT NULL,Posuw int NOT NULL,Koszt_za_h money NOT NULL)
CREATE TABLE PAR_MASZYNY (ID_Parametr int FOREIGN KEY REFERENCES PARAMETRY(ID_Parametr),ID_Model_maszyny int FOREIGN KEY REFERENCES MODELE_MASZYN(ID_Model_maszyny),Wartość int NOT NULL)
CREATE TABLE MASZYNY (ID_Maszyny int IDENTITY(1,1) PRIMARY KEY NOT NULL,ID_Model_maszyny int FOREIGN KEY REFERENCES MODELE_MASZYN(ID_Model_maszyny),Nr_ewidencyjny nvarchar(20) NOT NULL)
CREATE TABLE NARZEDZIA (ID_Narzedzia int IDENTITY(1,1) PRIMARY KEY NOT NULL,Nazwa nvarchar(50) NOT NULL,Model nvarchar(50) NOT NULL,Nr_ewidencyjny nvarchar(20) NOT NULL,Koszt_za_h money NOT NULL)
CREATE TABLE SLOWNIK_PROCES_TECHNOLOGICZNY(ID_Slownik_proces_technologiczny int IDENTITY(1,1) PRIMARY KEY NOT NULL,Nazwa_procesu nvarchar(50) NOT NULL)
CREATE TABLE PROCES (ID_Procesu int IDENTITY(1,1) PRIMARY KEY NOT NULL,ID_Slownik_proces_technologiczny int FOREIGN KEY REFERENCES SLOWNIK_PROCES_TECHNOLOGICZNY(ID_Slownik_proces_technologiczny),ID_Maszyny int FOREIGN KEY REFERENCES MASZYNY(ID_Maszyny),Nazwa_procesu nvarchar(50) NOT NULL,Czas_trwania int )
CREATE TABLE PROCES_NARZEDZIA (ID_Narzedzia int FOREIGN KEY REFERENCES NARZEDZIA(ID_Narzedzia),ID_Procesu int FOREIGN KEY REFERENCES PROCES(ID_Procesu))
CREate TABLE PROJEKT (ID_Projektu int IDENTITY(1,1) PRIMARY KEY NOT NULL,Czy_istnieje bit NOT NULL,Koszt money NOT NULL,Czas_realizacji datetime NOT NULL)
CREATE TABLE DOKUMENTACJA (ID_Dokumentacji int IDENTITY(1,1) PRIMARY KEY NOT NULL,Nr_rysunku nvarchar(15) NOT NULL,Data_wprowadzenia datetime NOT NULL,ID_Pracownik int FOREIGN KEY REFERENCES PRACOWNICY(ID_Pracownik),ID_Projektu int FOREIGN KEY REFERENCES PROJEKT(ID_Projektu))
CREATE TABLE DOKUMENTACJA_PROCES (ID_Dokumentacji int FOREIGN KEY REFERENCES DOKUMENTACJA(ID_Dokumentacji),ID_Procesu int FOREIGN KEY REFERENCES PROCES(ID_Procesu))
CREATE TABLE PAR_MAT(ID_Material int FOREIGN KEY REFERENCES MATERIAL(id_Materialu),ID_Parametr int FOREIGN KEY REFERENCES PARAMETRY(ID_Parametr),Wartość int NOT NULL)
CREATE TABLE POLPRODUKTY (ID_Polproduktu int IDENTITY(1,1) PRIMARY KEY NOT NULL,ID_Material int FOREIGN KEY REFERENCES MATERIAL(ID_Materialu),ID_Dokumentacji int FOREIGN KEY REFERENCES DOKUMENTACJA(ID_Dokumentacji),Liczba_sztuk int NOT NULL)
CREATE TABLE PROD_POLPROD (ID_Polproduktu int FOREIGN KEY REFERENCES POLPRODUKTY(ID_Polproduktu),ID_Produktu int FOREIGN KEY REFERENCES PRODUKT(ID_Produktu),Czas_realizacji_montazu date NOT NULL,Koszt_realizacji_montazu money NOT NULL)
--Tej tabeli nie wypełniamy
CREATE TABLE Zlecenia_KOSZTY(Id_Zlecenia int FOREIGN KEY REFERENCES Zlecenia(id_Zlecenia), Koszt_Materialu int, Koszt_Transportu int, Koszt_Produkcji int, Kodzt_Dostarczenia int)
=======
CREATE TABLE MIASTA (ID_MIASTA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA VARCHAR(50) NOT NULL);
CREATE TABLE ADRESY (ID_ADRESU INT IDENTITY(1,1) PRIMARY KEY NOT NULL, ULICA VARCHAR(30), NR_BUDYNKU VARCHAR(10), NR_LOKALU VARCHAR(10), KOD_POCZTOWY VARCHAR(5), ID_MIASTA INT FOREIGN KEY REFERENCES MIASTA(ID_MIASTA), KRAJ VARCHAR(15))
CREATE TABLE LOKALIZACJA (ID_LOKALIZACJI INT IDENTITY(1,1) PRIMARY KEY NOT NULL, SEKTOR VARCHAR(30), ALEJKA VARCHAR(30), REGAŁ VARCHAR(30), POZIOM VARCHAR(30), KOSZ VARCHAR(30))
CREATE TABLE PRODUKT (ID_PRODUKTU INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA_PRODUKTU VARCHAR(30) NOT NULL, OPIS NVARCHAR(50) NOT NULL)
CREATE TABLE STATUS_ZAM (ID_STATUSU_ZAM INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA VARCHAR(30))
CREATE TABLE STATUS_ZLECENIA (ID_STATUSU_ZLECENIA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, ETAP VARCHAR(30))
CREATE TABLE DOSTAWCY (ID_DOSTAWCY INT IDENTITY(1,1) PRIMARY KEY NOT NULL, MARKA VARCHAR(30), MODEL VARCHAR(30), NUMER_REJESTRACYJNY VARCHAR(7), STAWKA MONEY, NOSNOSC VARCHAR(10), GABARYTY VARCHAR(20))
CREATE TABLE PRACOWNICY (ID_PRACOWNIK INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWISKO VARCHAR(30) NOT NULL, IMIE VARCHAR(30) NOT NULL, TELEFON VARCHAR(12) NULL, ID_ADRESU INT FOREIGN KEY REFERENCES ADRESY(ID_ADRESU),PESEL NVARCHAR(11) NOT NULL  )
CREATE TABLE DOSTAWA (ID_DOSTAWY INT IDENTITY(1,1) PRIMARY KEY NOT NULL, ID_PRACOWNIKA INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK), ID_ADRESU INT FOREIGN KEY REFERENCES ADRESY(ID_ADRESU), ID_POJAZDU INT FOREIGN KEY REFERENCES DOSTAWCY(ID_DOSTAWCY), DŁUGOŚĆ_TRASY INT)
CREATE TABLE DOST_PROD (ID_PRODUKTU INT FOREIGN KEY REFERENCES PRODUKT(ID_PRODUKTU), ID_DOSTAWY INT FOREIGN KEY REFERENCES DOSTAWA(ID_DOSTAWY), ILOSC INT)
CREATE TABLE FIRMY (ID_FIRMY INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA_FIRMY VARCHAR(30), ADRES_EMAIL VARCHAR(30), NR_TELEFONU VARCHAR(12), NIP VARCHAR(10))
CREATE TABLE ZLECENIA (ID_ZLECENIA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, DATA_ZLECENIA VARCHAR(8), DATA_REALIZACJI VARCHAR(8), ID_FIRMY INT FOREIGN KEY REFERENCES FIRMY(ID_FIRMY), ID_STATUSU_ZLEC INT FOREIGN KEY REFERENCES STATUS_ZLEC(ID_STATUSU_ZLEC))
CREATE TABLE ZLEC_DOST (ID_ZLECENIA INT FOREIGN KEY REFERENCES ZLECENIA(ID_ZLECENIA), ID_DOSTAWY INT FOREIGN KEY REFERENCES DOSTAWA(ID_DOSTAWY), ILOŚĆ INT)
CREATE TABLE FAKTURY (ID_FAKTURY INT IDENTITY(1,1) PRIMARY KEY NOT NULL, ID_ZLECENIA INT FOREIGN KEY REFERENCES ZLECENIA(ID_ZLECENIA), ID_PRACOWNIKA INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK), DATA_WYSTAWIENIA VARCHAR(8))
CREATE TABLE FIRMA_ADRES (ID_FIRMY INT FOREIGN KEY REFERENCES FIRMY(ID_FIRMY), ID_ADRESU INT FOREIGN KEY REFERENCES ADRESY(ID_ADRESU))  
CREATE TABLE MATERIAL (ID_MATERIALU INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA VARCHAR(30) NOT NULL, PELNA_NAZWA_MATERIALU VARCHAR(30) NOT NULL, OZNACZENIE_SUROWCA VARCHAR(15))
CREATE TABLE STANMAG_MAT (ID_LOKALIZACJI INT FOREIGN KEY REFERENCES LOKALIZACJA(ID_LOKALIZACJI), ID_MATERIALU INT FOREIGN KEY REFERENCES MATERIAL(ID_MATERIALU),ILOSC INT, DATA_WPISU VARCHAR(8))
CREATE TABLE STANMAG_PROD (ID_LOKALIZACJI INT FOREIGN KEY REFERENCES LOKALIZACJA(ID_LOKALIZACJI), ID_PRODUKTU INT FOREIGN KEY REFERENCES PRODUKT(ID_PRODUKTU),ILOSC INT, DATA_WPISU VARCHAR(8))
CREATE TABLE ZAMOWIENIA (ID_ZAMOWIENIA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, DATA_ZAMOWIENIA VARCHAR(30), DATA_REALIZACJI VARCHAR(8), ID_FIRMY INT FOREIGN KEY REFERENCES FIRMY(ID_FIRMY), ID_STATUSU_ZAM INT FOREIGN KEY REFERENCES STATUS_ZAM(ID_STATUSU_ZAM)) 
CREATE TABLE ZAM_MAT (ID_ZAMOWIENIA INT FOREIGN KEY REFERENCES ZAMOWIENIA(ID_ZAMOWIENIA), ID_MATERIALU INT FOREIGN KEY REFERENCES MATERIAL(ID_MATERIALU), ILOSC INT)
CREATE TABLE ZLEC_PROD (ID_ZLECENIA INT FOREIGN KEY REFERENCES ZLECENIA(ID_ZLECENIA), ID_PRODUKTU INT FOREIGN KEY REFERENCES PRODUKT(ID_PRODUKTU), ILOSC INT NOT NULL)
CREATE TABLE STANOWISKO (ID_STANOWISKO INT IDENTITY(1,1) PRIMARY KEY NOT NULL , NAZWA CHAR(30) NOT NULL);
CREATE TABLE STANOWISKO_PRACOWNICY (ID_PRACOWNIK INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK) NOT NULL, ID_STANOWISKO INT FOREIGN KEY REFERENCES STANOWISKO(ID_STANOWISKO) NOT NULL, DATA_START DATE DEFAULT GETDATE() NOT NULL, DATA_KONIEC DATE NULL);
CREATE TABLE PODATEK (ID_PODATEK INT IDENTITY(1,1) PRIMARY KEY NOT NULL, STAWKA FLOAT NOT NULL, DATA DATE DEFAULT GETDATE() NOT NULL);
CREATE TABLE WALUTY (ID_WALUTY INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA CHAR(30) NOT NULL, KURS_DO_PLN FLOAT(24) DEFAULT 1 NOT NULL, DATA_KURS DATE DEFAULT GETDATE() NOT NULL);
CREATE TABLE SZKOLENIA (ID_SZKOLENIA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA_SZKOLENIA VARCHAR(50) NOT NULL, OPIS_SZKOLENIA VARCHAR NULL, DATA_START DATE DEFAULT GETDATE() NOT NULL, DATA_KONIEC DATE NOT NULL);
CREATE TABLE WOLNE (ID_WOLNE INT IDENTITY(1,1) PRIMARY KEY NOT NULL, SYMBOL CHAR(10) NOT NULL, NAZWA VARCHAR(30) NOT NULL);
CREATE TABLE WOLNEPRACOWNICY (ID_WOLNE INT FOREIGN KEY REFERENCES WOLNE(ID_WOLNE) NOT NULL, ID_PRACOWNIK INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK) NOT NULL, DATA_START DATE DEFAULT GETDATE() NOT NULL, DATA_KONIEC DATE DEFAULT GETDATE() NOT NULL);
CREATE TABLE MIESIAC (ID_MIESIAC INT IDENTITY(1,1) PRIMARY KEY NOT NULL, MIESIAC CHAR NOT NULL);
CREATE TABLE OKRES (ID_OKRES INT IDENTITY(1,1) PRIMARY KEY NOT NULL, NAZWA VARCHAR(50) NOT NULL);
CREATE TABLE STAWKA (ID_STAWKA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, WARTOSC MONEY NOT NULL, ID_OKRES INT FOREIGN KEY REFERENCES OKRES(ID_OKRES) NOT NULL);
CREATE TABLE STAWKAPRACOWNICY (ID_PRACOWNIK INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK) NOT NULL, ID_STAWKA INT FOREIGN KEY REFERENCES STAWKA(ID_STAWKA)NOT NULL, DATA_START DATE NOT NULL DEFAULT GETDATE(), DATA_KONIEC DATE NULL); 
CREATE TABLE SZKOLENIEPRACOWNICY (ID_PRACOWNIK INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK) NOT NULL, ID_SZKOLENIA INT FOREIGN KEY REFERENCES SZKOLENIA(ID_SZKOLENIA) NOT NULL);
CREATE TABLE PARAMETRY (ID_PARAMETR INT IDENTITY(1,1) PRIMARY KEY NOT NULL,NAZWA NVARCHAR(50) NOT NULL,JEDNOSTKA_MIARY NVARCHAR(50) NOT NULL)
CREATE TABLE MODELE_MASZYN (ID_MODEL_MASZYNY INT IDENTITY(1,1) PRIMARY KEY NOT NULL,MODEL NVARCHAR(50) NOT NULL,MARKA NVARCHAR(50) NOT NULL,TYP_MASZYNY NVARCHAR(50) NOT NULL,PRĘDKOŚĆ INT NOT NULL,POSUW INT NOT NULL,KOSZT_ZA_H MONEY NOT NULL)
CREATE TABLE PARAMETRY_MASZYNY (ID_PARAMETR INT FOREIGN KEY REFERENCES PARAMETRY(ID_PARAMETR),ID_MODEL_MASZYNY INT FOREIGN KEY REFERENCES MODELE_MASZYN(ID_MODEL_MASZYNY),WARTOŚĆ INT NOT NULL)
CREATE TABLE MASZYNY (ID_MASZYNY INT IDENTITY(1,1) PRIMARY KEY NOT NULL,ID_MODEL_MASZYNY INT FOREIGN KEY REFERENCES MODELE_MASZYN(ID_MODEL_MASZYNY),NR_EWIDENCYJNY NVARCHAR(20) NOT NULL)
CREATE TABLE NARZEDZIA (ID_NARZEDZIA INT IDENTITY(1,1) PRIMARY KEY NOT NULL,NAZWA NVARCHAR(50) NOT NULL,MODEL NVARCHAR(50) NOT NULL,NR_EWIDENCYJNY NVARCHAR(20) NOT NULL,KOSZT_ZA_H MONEY NOT NULL)
CREATE TABLE SLOWNIK_PROCES_TECHNOLOGICZNY(ID_SLOWNIK_PROCES_TECHNOLOGICZNY INT IDENTITY(1,1) PRIMARY KEY NOT NULL,NAZWA_PROCESU NVARCHAR(50) NOT NULL)
CREATE TABLE PROCES (ID_PROCESU INT IDENTITY(1,1) PRIMARY KEY NOT NULL,ID_SLOWNIK_PROCES_TECHNOLOGICZNY INT FOREIGN KEY REFERENCES SLOWNIK_PROCES_TECHNOLOGICZNY(ID_SLOWNIK_PROCES_TECHNOLOGICZNY),ID_MASZYNY INT FOREIGN KEY REFERENCES MASZYNY(ID_MASZYNY),NAZWA_PROCESU NVARCHAR(50) NOT NULL,CZAS_TRWANIA INT )
CREATE TABLE PROCES_NARZEDZIA (ID_NARZEDZIA INT FOREIGN KEY REFERENCES NARZEDZIA(ID_NARZEDZIA),ID_PROCESU INT FOREIGN KEY REFERENCES PROCES(ID_PROCESU))
CREATE TABLE PROJEKT (ID_PROJEKTU INT IDENTITY(1,1) PRIMARY KEY NOT NULL,CZY_ISTNIEJE BIT NOT NULL,KOSZT MONEY NOT NULL,CZAS_REALIZACJI DATETIME NOT NULL)
CREATE TABLE DOKUMENTACJA (ID_DOKUMENTACJI INT IDENTITY(1,1) PRIMARY KEY NOT NULL,NR_RYSUNKU NVARCHAR(15) NOT NULL,DATA_WPROWADZENIA DATETIME NOT NULL,ID_PRACOWNIK INT FOREIGN KEY REFERENCES PRACOWNICY(ID_PRACOWNIK),ID_PROJEKTU INT FOREIGN KEY REFERENCES PROJEKT(ID_PROJEKTU))
CREATE TABLE DOKUMENTACJA_PROCES (ID_DOKUMENTACJI INT FOREIGN KEY REFERENCES DOKUMENTACJA(ID_DOKUMENTACJI),ID_PROCESU INT FOREIGN KEY REFERENCES PROCES(ID_PROCESU))
CREATE TABLE PARAMETRY_MATERIALU(ID_MATERIAL INT FOREIGN KEY REFERENCES MATERIAL(ID_MATERIALU),ID_PARAMETR INT FOREIGN KEY REFERENCES PARAMETRY(ID_PARAMETR),WARTOŚĆ INT NOT NULL)
CREATE TABLE POLPRODUKTY (ID_POLPRODUKTU INT IDENTITY(1,1) PRIMARY KEY NOT NULL,ID_MATERIAL INT FOREIGN KEY REFERENCES MATERIAL(ID_MATERIALU),ID_DOKUMENTACJI INT FOREIGN KEY REFERENCES DOKUMENTACJA(ID_DOKUMENTACJI),LICZBA_SZTUK INT NOT NULL)
CREATE TABLE PRODUKCJA_POLPRODUKTU (ID_POLPRODUKTU INT FOREIGN KEY REFERENCES POLPRODUKTY(ID_POLPRODUKTU),ID_PRODUKTU INT FOREIGN KEY REFERENCES PRODUKT(ID_PRODUKTU),CZAS_REALIZACJI_MONTAZU DATE NOT NULL,KOSZT_REALIZACJI_MONTAZU MONEY NOT NULL)
--TEJ TABELI NIE WYPEŁNIAMY
CREATE TABLE ZLECENIA_KOSZTY(ID_ZLECENIA INT FOREIGN KEY REFERENCES ZLECENIA(ID_ZLECENIA), KOSZT_MATERIALU INT, KOSZT_TRANSPORTU INT, KOSZT_PRODUKCJI INT, KODZT_DOSTARCZENIA INT)
>>>>>>> 5383d82200dcd2c0f31cbdd879eff7581d1fddcc
