# Uputstvo za Korištenje Sistema

## 0. Početna stranica

<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/Home.png">

 - Na početnoj stranici možete izabrati pregled pacijenata, liječnika ili pregleda.

## 1. Upravljanje Pacijentima

### Pregled Liste Pacijenata
- Da biste vidjeli sve pacijente, idite na stranicu **Pacijenti**.
- **URL:** `/Patients/Index`


<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/PacijentiIndex.png">

# Uputstvo za Korištenje Sistema

## 1. Upravljanje Pacijentima

### Pregled Liste Pacijenata
- Da biste vidjeli sve pacijente, idite na stranicu **Lista Pacijenata**.
- **URL:** `/Patients/Index`

### Dodavanje Novog Pacijenta
- Kliknite na dugme **Dodaj novog pacijenta**.
- **URL:** `/Patients/AddPatient`
- Popunite formu sa osnovnim informacijama o pacijentu (ime, prezime, itd.).
- Kliknite na **Spremi** da dodate pacijenta u bazu podataka.

<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/DodajPacijenta.png">

### Uređivanje Pacijenta
- Na stranici **Lista Pacijenata**, pronađite pacijenta kojeg želite urediti i kliknite na dugme **Uredi** pored njegovog imena.
- **URL:** `/Patients/EditPatient/{id}`
- Izvršite potrebne promjene u formi.
- Kliknite na **Spremi** da sačuvate izmjene.

### Brisanje Pacijenta
- Na stranici **Lista Pacijenata**, pronađite pacijenta kojeg želite obrisati i kliknite na dugme **Obriši** pored njegovog imena.
- Potvrdite brisanje kada vam se zatraži.
- **Obrisani pacijenti ostaju u bazi podataka. Brisanjem pacijenata mijenja se varijabla isDeleted! Mogući je retroaktivni pregled obrisanih pacijenata direktno u bazi podataka**

<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/BrisanjePacijenata.png">


## 2. Upravljanje Liječnicima

### Pregled Liste Liječnika
- Da biste vidjeli sve liječnike, idite na stranicu **Lista Liječnika**.
- **URL:** `/Doctors/Index`


<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/DoktoriIndex.png">

### Dodavanje Novog Liječnika
- Kliknite na dugme **Dodaj novog liječnika**.
- **URL:** `/Doctors/AddDoctor`
- Popunite formu sa osnovnim informacijama o liječniku (ime, prezime, specijalizacija, itd.).
- Kliknite na **Spremi** da dodate liječnika u bazu podataka.

<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/NoviLiječnik.png">

### Uređivanje Liječnika
- Na stranici **Lista Liječnika**, pronađite liječnika kojeg želite urediti i kliknite na dugme **Uredi** pored njegovog imena.
- **URL:** `/Doctors/EditDoctor/{id}`
- Izvršite potrebne promjene u formi.
- Kliknite na **Spremi** da sačuvate izmjene.

<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/UrediLiječnika.png">

### Brisanje Liječnika
- Na stranici **Lista Liječnika**, pronađite liječnika kojeg želite obrisati i kliknite na dugme **Obriši** pored njegovog imena.
- Potvrdite brisanje kada vam se zatraži.

- **Obrisani liječnici ostaju u bazi podataka. Brisanjem liječnika mijenja se varijabla isDeleted! Mogući je retroaktivni pregled obrisanih liječnika direktno u bazi podataka**

<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/ObrišiLiječnika.png">


## 3. Upravljanje Prijemima

### Pregled Liste Prijema
- Da biste vidjeli sve prijeme, idite na stranicu **Lista Prijema**.
- **URL:** `/Admissions/Index`


<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/PrijemiIndex.png">

### Filtriranje Prijema
- Da bi ste vidjeli sve prijeme u željenom vremenskom okviru na stranici liste prijema odaberite vremenski okvir u poljima **Od datuma** i **Do datuma**.
- Nakon biranja željenog vremenskog okvira kliknite dugme **Filtriraj** kako bi vidjeli listu prijema u odabranom vremenskom okviru.

<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/PrijemiFilter.png">

### Dodavanje Novog Prijema
- Kliknite na dugme **Dodaj novi prijem**.
- **URL:** `/Admissions/AddAdmission`
- Popunite formu sa osnovnim informacijama o prijemu (datum prijema, pacijent, liječnik, hitni slučaj).
- Kliknite na **Spremi** da dodate prijem u bazu podataka.


<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/NoviPrijem.png">

- **Nove prijeme nije moguće unijeti prije trenutnog datuma i vremena!**

<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/NoviPrijem2.png">



### Uređivanje Prijema
- Na stranici **Lista Prijema**, pronađite prijem koji želite urediti i kliknite na dugme **Uredi** pored njega.
- **URL:** `/Admissions/EditAdmission/{id}`
- Izvršite potrebne promjene u formi.
- Kliknite na **Spremi** da sačuvate izmjene.

<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/UrediPrijem.png">

### Brisanje Prijema
- Na stranici **Lista Prijema**, pronađite prijem koji želite obrisati i kliknite na dugme **Obriši** pored njega.
- Potvrdite brisanje kada vam se zatraži.
- **Obrisani prijemi ostaju u bazi podataka. Brisanjem prijema mijenja se varijabla isDeleted! Mogući je retroaktivni pregled obrisanih prijmea direktno u bazi podataka**


### Novi Nalaz
- **URL:** `/Admissions/AddReport/{id}`
- Na stranici **Lista Prijema**, pronađite prijem za koji želite dodati nalaz i kliknite na dugme **Dodaj nalaz** pored njega.
- Unesite detalje (dijagnozu) nalaza te dugme **Dodaj novi nalaz**
- Datum novog nalaza se kreira u trenutku dodavanja novog nalaza tj. u trenutku spremanja novog nalaza u bazu.

<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/NoviNalaz.png">

### Detalji Nalaza
- Na stranici **Lista Prijema**, pronađite prijem za koji želite pogledati nalaz i kliknite na dugme **Pogledaj nalaz** pored njega.
- **URL:** `/Admissions/ViewAdmission/{id}`

<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/DetaljiNalaza.png">

### Prezuimanje Nalaza
- Na stranici **Detalji Nalaza** kliknite dugme **Prezumi nalaza** koje automatksi spašava formatiran PDF file sa svim detaljima vašeg nalaza.
- PDF file se spašava pod imenom **NMK_NalazSpecijaliste_(Ime i prezime pacijenta).pdf**

<img title="a title" alt="Alt text" src="https://github.com/dev-arma/NMK/blob/master/Images/NalazPDF.png">




