## Script
### Intro
"Velkommen tel min videopresentasjon. Vi ska fokuser på
oppgave 5 og sammenhengen mellom DFS og BFS."

### Program Demo
"Her kjør vi oppgave 5 sin fulle meny, som omfatte demonstrasjon av samtlige sentrale metoda, inkludert kanttilfella som isolert node og cycle detection."  
**Program Runs Through All Menu Options...**  
**Make a note of which algorithm is running, and what it represents**  

### Algorithmic choices  
FindRoute.  
"Sjøl om e valgte å skriv begge extensions, har e valgt FindRoute for den her videoen.  
FindRoute e basert på Iterative DFS, og returnere true eller false. Den ser gjennom nodan, og sjekke etter `current == target`. Om den finn at current equals target returnere den true, hvis ikke, false. Bruke en eksplisitt stack, og et HashSet for å track besøkte noda på en effektiv måte."  
**Point to edge case guards and handling**

### HashSet
"D bringe oss videre til valgt datastruktur for videoen: 
HashSet. HashSet vart valgt for sin effektive tracking og raske 
oppslag. Rekkefølge på `visited` e ikke nøye i d hele tatt, men muligheten for å sjekk om en nabo e markert som visited kjapt e 
viktig. Naboa må markeres ved discovery for å unngå infinite loops. Allerede besøkt? Skip.

### DFS and BFS
Comparison still  
Explain differences and similarities

### Challenge and Reflection
DetectCycles/Recursive  
False positives - forklar hvorfor, hvordan det ble løst  
Duplicate resultat - forklar hvorfor og løsning (bool alreadyRecorded)  

- How I worked through it
- future work
- Ai Use

### End
Say byebye...

---