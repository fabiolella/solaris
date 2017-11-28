## Introduzione

Nel progetto examApi ho creato un piccolo client con le funzionalit‡ descritte nelle specifiche. Il progetto Ë sviluppato con Angular5 e Bootstrap 4. 
Ho utilizzato un service per mantenere lo stato dell'applicazione, per il resto sono presenti due componenti (login, exams) che  utilizzano le examApi per effettuare le operazioni descritte nelle specifiche.
Per lanciare il progetto Ë necessario angular client, fare npm install per importare tutti i pacchetti necessari, e poi avviare con 'ng serve'.


# Progetto prenotazione esami.

## Descrizione

Attraverso questo progetto gli studenti potranno prenotare un'esame.

### Riassunto specifiche

Di seguito le specifiche principali del progetto:
- Ogni studente potr√† prenotare un solo esame alla volta.
- Ad esame scaduto sar‡† possibile riabilitare la prenotazioni per altri esami.
- L'esame si potr‡† prenotare solo in giorni successivi alla data odierna.

### Casi d'uso principali

Per il progetto ho previsto i seguenti casi d'uso.
Casi d'uso dello studente:
- Login
- Prenotazione Esame

#### Login 

Il seguente caso d'uso prevede le seguenti iterazioni:

**scenario base**

  - 1 Attore (sistema): presenta l'home page con la form di login.
  - 2 Attore (studente): imposta l'utente e la password.
  - 3 Attore (sistema): verifica le credenziali e presenta l'home page dello studente

**variante uno - user o password errati**

  - 3.1 Attore (sistema): riscontra errori nella password o nella user impostati.
  - 3.2 Attore (sistema): presenta un generico messaggio di errore delle crenziali.

#### Prenotazione Esame 

Il seguente caso d'uso prevede le seguenti iterazioni:

**scenario base**

  - 1 Attore (studente): seleziona la funzione elenco esami dalla sua home-page.
  - 2 Attore (sistema): presenta la lista degli esami.
  - 3 Attore (studente): seleziona la funzione prenota
  - 4 Attore (sistema): il sistema presenta il messaggio, esame [nome dell'esame] prenotato.

**variante uno - esami non prenotabili**

  - 2.1 Attore (sistema): il sistema riscontra che l'utente ha gi‡† un'esame prenotato.
  - 2.2 Attore (sistema): il sistema presenta la lista degli esami senza la funzione _prenota_.

### Moduli del progetto

Il progetto prevede i seguenti moduli:
- exampApi: RESTFull API
- examClient: client angular


