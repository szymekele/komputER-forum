# komputER forum – dokumentacja projektu

## Spis treści
1. [Tytuł projektu i skład zespołu](#1-tytuł-projektu-i-skład-zespołu)
2. [Opis problemu, celu i grupy docelowej](#2-opis-problemu-celu-i-grupy-docelowej)
3. [Wymagania funkcjonalne i niefunkcjonalne](#3-wymagania-funkcjonalne-i-niefunkcjonalne)
4. [Zakres podstawowy oraz wykonane funkcje dodatkowe](#4-zakres-podstawowy-oraz-wykonane-funkcje-dodatkowe)
5. [Przypadki użycia](#5-przypadki-użycia)
6. [Makiety najważniejszych ekranów](#6-makiety-najważniejszych-ekranów)
7. [Schemat nawigacji](#7-schemat-nawigacji)
8. [Diagram klas](#8-diagram-klas)
9. [Model bazy danych z opisem encji i relacji](#9-model-bazy-danych-z-opisem-encji-i-relacji)
10. [Opis architektury, struktury pakietów i wykaz zmiennych](#10-opis-architektury-struktury-pakietów-i-wykaz-zmiennych)
11. [Opis wykorzystanych technologii i bibliotek](#11-opis-wykorzystanych-technologii-i-bibliotek)
12. [Podział pracy w zespole i zestawienie wkładu każdego członka](#12-podział-pracy-w-zespole-i-zestawienie-wkładu-każdego-członka)
13. [Harmonogram realizacji](#13-harmonogram-realizacji)
14. [Scenariusze testowe i wyniki testów](#14-scenariusze-testowe-i-wyniki-testów)
15. [Opis wykrytych i poprawionych błędów](#15-opis-wykrytych-i-poprawionych-błędów)
16. [Instrukcja kompilacji i uruchomienia projektu](#16-instrukcja-kompilacji-i-uruchomienia-projektu)
17. [Znane ograniczenia i możliwe kierunki rozwoju](#17-znane-ograniczenia-i-możliwe-kierunki-rozwoju)
18. [Informacje o licencjach wykorzystanych zasobów](#18-informacje-o-licencjach-wykorzystanych-zasobów)

## 1. Tytuł projektu i skład zespołu
* **Nazwa projektu:** komputER forum
* **Skład zespołu:**
  * Szymon Elendt
  * Wiktor Rogowski

## 2. Opis problemu, celu i grupy docelowej
* **Problem:** Pasjonaci nowych technologii i sprzętu komputerowego poszukują dedykowanej, przejrzystej i lekkiej przestrzeni do wymiany doświadczeń, dyskusji oraz rozwiązywania problemów technicznych bez zbędnych rozpraszaczy obecnych na dużych portalach społecznościowych.
* **Cel:** Stworzenie intuicyjnej aplikacji komputerowej funkcjonującej jako serwis społecznościowy („komputER forum"), umożliwiającej obsługę kont użytkowników, publikację wpisów, dyskusję w komentarzach oraz automatyczną archiwizację starych wątków.
* **Grupa docelowa:** Entuzjaści komputerowi, gracze, programiści, osoby poszukujące porady sprzętowej oraz wszyscy użytkownicy zainteresowani tematyką IT.

## 3. Wymagania funkcjonalne i niefunkcjonalne
* **Wymagania funkcjonalne:**
  * Tworzenie nowego konta (rejestracja) oraz autoryzacja (logowanie).
  * Dodawanie nowych postów z tytułem oraz treścią.
  * Edytowanie oraz usuwanie własnych postów.
  * Dodawanie, edycja oraz usuwanie komentarzy pod postami.
  * Mechanizm archiwizacji starych postów i powiązanych z nimi komentarzy.
  * Odświeżanie widoku głównych wpisów forum.
* **Wymagania niefunkcjonalne:**
  * Wysoka wydajność i natychmiastowe przetwarzanie zapytań SQL.
  * Bezpieczna obsługa sesji użytkowników.
  * Czytelny, ergonomiczny i estetyczny interfejs desktopowy.

## 4. Zakres podstawowy oraz wykonane funkcje dodatkowe
* **Zakres podstawowy:** Moduł rejestracji i logowania, tworzenie, edycja oraz usuwanie postów i komentarzy, wyświetlanie listy wpisów na stronie głównej.
* **Funkcje dodatkowe:**
  * System automatycznego przenoszenia starych postów i komentarzy do archiwum.
  * Dynamiczne przyciski akcji (edytuj/usuń) dostosowane do uprawnień autora wpisu lub komentarza.

## 5. Przypadki użycia
* **Dodanie nowego posta:** Zalogowany użytkownik klika przycisk „Stwórz post", wypełnia formularz (`CreatePost.cs`) podając tytuł i treść, a następnie publikuje go na stronie głównej.
* **Dodanie komentarza:** Użytkownik klika „Komentuj" pod wpisem, wprowadza tekst w formularzu (`CreateComment.cs`) i zatwierdza – komentarz natychmiast pojawia się pod postem.
* **Usunięcie posta/komentarza:** Autor wpisu lub komentarza klika przycisk „Usuń", wyzwalając polecenie SQL usuwające dany rekord z bazy danych.

## 6. Makiety najważniejszych ekranów
Interfejs graficzny został zaprojektowany w czytelnym i przejrzystym układzie okienkowym:
* **Ekran startowy:** Zawiera opcje wyboru: „ZALOGUJ SIĘ", „ZAREJESTRUJ SIĘ" oraz „Zamknij".
* **Ekran logowania / rejestracji:** Dedykowane formularze z polami tekstowymi na nazwę użytkownika i hasło oraz przyciskami powrotu.
* **Ekran główny forum (Main):** Posiada nagłówek z informacją o zalogowanym użytkowniku, przycisk „Stwórz post", przycisk „Wyloguj" oraz listę wpisów z podpiętą sekcją komentarzy i zestawem przycisków akcji (Komentuj, Edytuj, Usuń).

## 7. Schemat nawigacji
Struktura nawigacyjna aplikacji została zaprojektowana w sposób intuicyjny:
* Ekran początkowy (`Home.cs`) -> Przejście do formularza logowania (`Login.cs`) lub rejestracji (`Register.cs`).
* Po pomyślnym zalogowaniu -> Przekierowanie do ekranu głównego forum (`Main.cs`).
* Z poziomu ekranu głównego (`Main.cs`):
  * Otwarcie okna dodawania/edycji posta (`CreatePost.cs`).
  * Otwarcie okna dodawania/edycji komentarza (`CreateComment.cs`).
  * Przycisk „Wyloguj" resetuje sesję i przywraca ekran początkowy.

## 8. Diagram klas
Struktura kodu opiera się na modułach okienkowych oraz klasach zarządzających danymi:
* `Home.cs` – Obsługa ekranu startowego.
* `Login.cs` & `Register.cs` – Logika autoryzacji i rejestracji użytkowników.
* `Main.cs` – Kontroler widoku głównego, pobieranie postów z bazy oraz logika archiwizacji.
* `CreatePost.cs` / `CreateComment.cs` – Formularze edycji i tworzenia wpisów oraz komentarzy.
* `UserPost.cs` / `UserComment.cs` – Komponenty reprezentujące pojedyncze posty i komentarze w interfejsie.

## 9. Model bazy danych z opisem encji i relacji
Relacyjna baza danych składa się z kluczowych tabel:
* **Users:** Przechowuje dane kont (`userId`, `username`, `password`).
* **Posts:** Przechowuje wpisy forum (`postId`, `userId`, `title`, `content`, `date`).
* **Comments:** Przechowuje komentarze pod postami (`commentId`, `postId`, `userId`, `content`, `date`).
* **Archiwum:** Tabele przechowujące zarchiwizowane posty i komentarze po upływie określonego czasu.

<img width="960" height="540" alt="diagramdb" src="https://github.com/user-attachments/assets/534a544b-a2c6-4b88-a06d-a576c5563501" />

## 10. Opis architektury, struktury pakietów i wykaz zmiennych
Aplikacja została zbudowana w oparciu o architekturę desktopową w języku C# (.NET / Windows Forms):
* **Formularze UI:** `Home`, `Login`, `Register`, `Main`, `CreatePost`, `CreateComment`.
* **Komponenty widokowe:** `UserPost`, `UserComment`.
* **Warstwa danych:** Komunikacja z bazą danych poprzez zmienne połączeniowe `connectionString` / `cs` oraz zapytania SQL (`insertQuery`, `updateQuery`, `deleteQuery`, `selectQuery`).

### Wykaz zmiennych i pól w klasach

* **CreateComment.cs:**
  * `_postId` – unikalne ID posta przypisanego do komentarza
  * `_userId` – ID użytkownika tworzącego komentarz
  * `_commentId` – ID edytowanego komentarza
  * `_isEditMode` – flaga określająca tryb działania formularza (dodawanie lub edycja)
  * `content` – treść komentarza pobrana z pola tekstowego
  * `cs` – ciąg połączeniowy do bazy danych (*connection string*)
  * `result` – treść komentarza pobrana podczas ładowania danych do edycji
  * `query`, `updateQuery`, `insertQuery` – polecenia SQL obsługujące operacje na bazie

* **CreatePost.cs:**
  * `_mode` – tryb działania formularza (dodawanie lub edytowanie)
  * `_userId` – ID autora posta
  * `_postId` – unikalne ID posta
  * `_commentId` – ID powiązanego komentarza
  * `title` – tytuł posta pobrany z pola tekstowego
  * `content` – treść posta pobrana z pola tekstowego
  * `cs` – ciąg połączeniowy (*connection string*)
  * `insert`, `update`, `query`, `result` – polecenia i wyniki zapytań SQL
  * `reader` – obiekt czytnika odczytujący dane z bazy podczas ładowania posta

* **Home.cs:**
  * `formLogin` – instancja formularza logowania
  * `formRegister` – instancja formularza rejestracji

* **Login.cs:**
  * `ConnectionStringName` / `connectionString` / `cs` – ciąg połączenia z bazą danych
  * `username` – nazwa wprowadzona przez użytkownika
  * `password` – hasło wprowadzone przez logującego użytkownika
  * `userId` – pobrane ID zalogowanego użytkownika
  * `formMain` – instancja głównego okna aplikacji otwierana po autoryzacji
  * `newHomeView` – referencja do ekranu startowego przy powrocie
  * `result` – wynik weryfikacji istnienia i poprawności danych użytkownika w bazie
  * `query`, `cmd`, `conn`, `connection` – obiekty i zapytania SQL do obsługi logowania

* **Main.cs:**
  * `_currentUserId` / `userId` – ID aktualnie zalogowanego użytkownika
  * `createNewPost` – instancja formularza tworzenia nowego posta
  * `newPostId` – identyfikator nowo dodanego posta
  * `postItem` – kontrolka reprezentująca dodany post na liście
  * `connectionString` / `cs` – ciąg połączeniowy do bazy
  * `countQuery`, `selectQuery` – zapytania SQL zliczające i pobierające wpisy
  * `postCout` – łączna liczba postów na liście
  * `toArchive` – liczba postów zakwalifikowanych do archiwizacji
  * `archiveComments` – procedura/zapytanie przenoszące powiązane komentarze do archiwum
  * `deleteComments` – usuwanie komentarzy po pomyślnym zarchiwizowaniu
  * `insertCmd` – polecenie przenoszące post do tabeli archiwalnej
  * `deleteCmd` – polecenie usuwające post z tabeli głównej po przeniesieniu

* **Register.cs:**
  * `ConnectionStringName` – nazwa/ciąg połączenia do bazy
  * `username` – nazwa nowego użytkownika
  * `password` – hasło nowego użytkownika
  * `checkQuery` – zapytanie weryfikujące, czy podana nazwa konta jest już zajęta
  * `maxIdQuery` – zapytanie pobierające maksymalne dotychczasowe ID użytkownika
  * `newId` – wyliczone nowe ID dla tworzonego konta
  * `insertQuery` – zapytanie SQL wstawiające nowy rekord do tabeli użytkowników
  * `result` – wynik wykonania polecenia lub zapytania sprawdzającego
  * `formLogin` – instancja formularza logowania otwierana po rejestracji
  * `newHomeView` – referencja do ekranu startowego

* **UserComment.cs:**
  * `_commentId` – identyfikator danego komentarza
  * `_postId` – identyfikator nadrzędnego posta
  * `_currentUserId` – ID zalogowanego użytkownika
  * `editButton` – dynamiczny przycisk edycji (widoczny wyłącznie dla autora)
  * `deleteButton` – dynamiczny przycisk usuwania (widoczny wyłącznie dla autora)
  * `confirm` – rezultat okna potwierdzenia chęci usunięcia komentarza
  * `cs`, `conn` – parametry połączenia z bazą danych
  * `deleteQuery`, `cmd` – polecenie SQL usuwające komentarz
  * `rows` – liczba wierszy zmodyfikowanych w bazie danych
  * `editForm` – okno edycji komentarza

* **UserPost.cs:**
  * `_postId` – unikalne ID wyświetlanego posta
  * `_currentUserId` – ID zalogowanego użytkownika
  * `authorId` – ID autora posta
  * `commentButton` – przycisk wywołujący formularz dodania komentarza
  * `editButton` – przycisk wywołujący edycję wpisu (dla autora)
  * `deleteButton` – przycisk usuwający post (dla autora)
  * `cs`, `conn` – obsługa połączenia z bazą danych
  * `query`, `cmd`, `result` – obiekty poleceń SQL pobierające dane o wpisie
  * `editForm` – instancja formularza edycji posta
  * `commentForm` – instancja formularza tworzenia komentarza
  * `deleteQuery`, `rows` – polecenie usunięcia wpisu oraz weryfikacja liczby usuniętych rekordów

## 11. Opis wykorzystanych technologii i bibliotek
* **Język programowania:** C#
* **Platforma / Framework:** .NET / Windows Forms / Visual Studio
* **Baza danych:** SQL (Mssql / SQLite / MySQL)
* **Kontrola wersji:** Git, GitHub

## 12. Podział pracy w zespole i zestawienie wkładu każdego członka
* **Szymon Elendt:** Opracowanie strony początkowej (`Home.cs`), implementacja systemu logowania (`Login.cs`) oraz zakładania konta (`Register.cs`), projekt i obsługa bazy danych, opracowanie projektu graficznego, logo oraz favicony, implementacja modułu usuwania postów i komentarzy, sporządzenie dokumentacji.
* **Wiktor Rogowski:** Projekt i obsługa bazy danych, implementacja dodawania i edytowania postów (`CreatePost.cs`, `UserPost.cs`), implementacja dodawania i edytowania komentarzy (`CreateComment.cs`, `UserComment.cs`), opracowanie i implementacja modułu archiwizacji postów i komentarzy (`Main.cs`), sporządzenie dokumentacji.

## 13. Harmonogram realizacji
* **Faza 1:** Analiza wymagań, przygotowanie projektu graficznego (logo), schematu nawigacji i architektury bazy danych.
* **Faza 2:** Implementacja modułu logowania, rejestracji oraz widoku startowego.
* **Faza 3:** Tworzenie logiki dodawania, edycji oraz usuwania postów i komentarzy.
* **Faza 4:** Implementacja automatycznej archiwizacji treści, testowanie aplikacji oraz przygotowanie dokumentacji.

## 14. Scenariusze testowe i wyniki testów
* **Scenariusz 1 (Rejestracja i logowanie):** Utworzenie nowego konta i zalogowanie się poprawnymi danymi – Wynik: Sukces.
* **Scenariusz 2 (Tworzenie wpisu i komentarza):** Opublikowanie nowego wpisu na forum i dodanie odpowiedzi – Wynik: Sukces, dane poprawnie zapisane w bazie SQL i wyświetlone na forum.
* **Scenariusz 3 (Edycja i usuwanie):** Zmiana treści wpisu przez autora oraz usunięcie komentarza – Wynik: Sukces, baza danych zaktualizowana natychmiastowo.

## 15. Opis wykrytych i poprawionych błędów
* **Błąd 1:** Błąd naruszenia klucza obcego przy próbie usunięcia posta zawierającego komentarze. Poprawka: Zaimplementowano sekwencyjne usuwanie/archiwizowanie komentarzy przed usunięciem nadrzędnego posta.
* **Błąd 2:** Brak automatycznego odświeżenia widoku postów po opublikowaniu nowej treści. Poprawka: Dodano wywołanie przeładowania komponentów w `Main.cs` po zamknięciu formularza `CreatePost`.

## 16. Instrukcja kompilacji i uruchomienia projektu
1. Sklonuj repozytorium projektu z serwisu GitHub.
2. Otwórz plik rozwiązania `.sln` w środowisku Visual Studio.
3. Skonfiguruj ciąg połączenia z bazą danych (`ConnectionString`) w pliku konfiguracyjnym aplikacji.
4. Skompiluj i uruchom projekt przyciskiem Start (F5).

## 17. Znane ograniczenia i możliwe kierunki rozwoju
* **Znane ograniczenia:** Aplikacja w obecnej wersji jest programem okienkowym przeznaczonym wyłącznie dla systemu Windows.
* **Możliwe kierunki rozwoju:**
  * Stworzenie wersji webowej serwisu (np. w ASP.NET Core + React).
  * Dodanie role-based access control (RBAC) – uprawnień moderatora i administratora.
  * Wprowadzenie wyszukiwarki postów oraz kategoryzacji wpisów na forum.

## 18. Informacje o licencjach wykorzystanych zasobów
* **Licencja projektu:** MIT License.
* **Zasoby graficzne:** Autorskie logo oraz elementy interfejsu stworzone przez zespół.

---

# komputER forum – instrukcja użytkownika

## Spis treści
1. [Przeznaczenie aplikacji i jej najważniejsze możliwości](#1-przeznaczenie-aplikacji-i-jej-najważniejsze-możliwości-1)
2. [Wymagania systemowe](#2-wymagania-systemowe-1)
3. [Sposób instalacji i uruchomienia](#3-sposób-instalacji-i-uruchomienia-1)
4. [Opis pierwszego uruchomienia](#4-opis-pierwszego-uruchomienia-1)
5. [Objaśnienie menu i nawigacji](#5-objaśnienie-menu-i-nawigacji-1)
6. [Instrukcje wykonania najważniejszych operacji](#6-instrukcje-wykonania-najważniejszych-operacji-1)
7. [Opis walidacji i komunikatów o błędach](#7-opis-walidacji-i-komunikatów-o-błędach-1)
8. [Informacje o wymaganych uprawnieniach](#8-informacje-o-wymaganych-uprawnieniach-1)
9. [Sposób usuwania lub resetowania danych](#9-sposób-usuwania-lub-resetowania-danych-1)
10. [Rozwiązania typowych problemów](#10-rozwiązania-typowych-problemów-1)
11. [Zrzuty ekranów z podpisami](#11-zrzuty-ekranów-z-podpisami-1)

## 1. Przeznaczenie aplikacji i jej najważniejsze możliwości
Aplikacja **komputER forum** służy do prowadzenia dyskusji na tematy związane z komputerami i technologią w wygodnej formie serwisu społecznościowego.

**Najważniejsze możliwości:**
* **Konta użytkowników:** Szybka rejestracja, bezpieczne logowanie oraz wylogowywanie.
* **Tworzenie wątków:** Publikowanie nowych postów z tytułem oraz treścią.
* **Komentowanie:** Dodawanie wypowiedzi pod wpisami innych użytkowników.
* **Zarządzanie treścią:** Pełna edycja i usuwanie własnych wpisów oraz komentarzy.

## 2. Wymagania systemowe
* **System operacyjny:** Windows 10 / 11.
* **Biblioteki runtime:** .NET Framework 4.8 lub nowszy.
* **Sieć:** Dostęp do sieci lokalnej/Internetu (wymagany do połączenia z bazą SQL).

## 3. Sposób instalacji i uruchomienia
1. Pobierz archiwum projektu lub plik instalacyjny z repozytorium GitHub.
2. Rozpakuj zawartość archiwum na dysk lokalny.
3. Uruchom plik wykonywalny `komputER_forum.exe`.

## 4. Opis pierwszego uruchomienia
Po uruchomieniu aplikacji ukaże się ekran powitalny:
1. Kliknij przycisk **"ZAREJESTRUJ SIĘ"**.
2. Podaj swoją nazwę użytkownika oraz hasło w formularzu i kliknij **"UTWÓRZ KONTO"**.
3. Po utworzeniu konta zostaniesz przekierowany do ekranu logowania – wprowadź dane i kliknij **"ZALOGUJ SIĘ"**, aby przejść do strony głównej forum.

## 5. Objaśnienie menu i nawigacji
* **Ekran początkowy:** Przełącznik między logowaniem, rejestracją a zamknięciem programu.
* **Ekran główny forum:**
  * Nagłówek informujący o zalogowanym koncie.
  * Przycisk **"Stwórz post"** otwierający formularz nowego wpisu.
  * Lista postów ułożona chronologicznie.
  * Przycisk **"Wyloguj"** powracający do ekranu startowego.

## 6. Instrukcje wykonania najważniejszych operacji
* **Jak dodać nowy post?**
  1. Kliknij przycisk **"Stwórz post"** na ekranie głównym.
  2. Wpisz Tytuł oraz Treść.
  3. Kliknij **"Opublikuj"**.
* **Jak dodać komentarz?**
  1. Kliknij przycisk **"Komentuj"** umieszczony pod wybranym postem.
  2. Wpisz treść i kliknij **"Opublikuj"**.
* **Jak edytować lub usunąć wpis/komentarz?**
  1. Przy własnym poście/komentarzu kliknij **"Edytuj"**, zmień treść i zatwierdź przyciskiem **"Zapisz"**.
  2. Aby usunąć swój wpis lub komentarz, kliknij przycisk **"Usuń"**.

## 7. Opis walidacji i komunikatów o błędach
* *„Wypełnij wszystkie pola”* – komunikat pojawia się w przypadku braku nazwy użytkownika lub hasła.
* *„Użytkownik już istnieje”* – brak możliwości rejestracji ze względu na zajętą nazwę użytkownika.
* *„Nieprawidłowe dane logowania”* – podano błędne hasło lub nazwę użytkownika.

## 8. Informacje o wymaganych uprawnieniach
* **Uprawnienia sieciowe:** Wymagane zezwolenie w zaporze sieciowej (Firewall) na komunikację z serwerem bazy danych.

## 9. Sposób usuwania lub resetowania danych
* **Usuwanie wpisów:** Wybrany wpis lub komentarz można usunąć w dowolnym momencie przyciskiem **"Usuń"**.
* **Wylogowanie:** Przycisk **"Wyloguj"** kończy obecną sesję i usuwa tymczasowe dane użytkownika z pamięci podręcznej okna.

## 10. Rozwiązania typowych problemów
* **Problem:** Aplikacja zgłasza błąd połączenia z bazą.
  * *Rozwiązanie:* Sprawdź połączenie z siecią oraz zweryfikuj poprawność wpisu w pliku konfiguracji połączenia z bazą SQL.
* **Problem:** Brak widoczności dodanego posta.
  * *Rozwiązanie:* Użyj przycisku odświeżenia widoku lub zrestartuj okno główne aplikacji.

## 11. Zrzuty ekranów z podpisami
<img width="960" height="540" alt="komputER forum - dokumentacja" src="https://github.com/user-attachments/assets/f351896e-dde1-4641-bad3-f7762444b076" />
<img width="960" height="540" alt="komputER forum - dokumentacja (1)" src="https://github.com/user-attachments/assets/5b2c1cbb-c863-4c32-bc88-c1936c0b83b2" />
<img width="960" height="540" alt="komputER forum - dokumentacja (2)" src="https://github.com/user-attachments/assets/212fcd09-c472-4aaf-b211-03b2134cd119" />
<img width="960" height="540" alt="komputER forum - dokumentacja (3)" src="https://github.com/user-attachments/assets/67fc8afd-d7f2-4c4f-9ab0-17a80ecba4d4" />
<img width="960" height="540" alt="komputER forum - dokumentacja (4)" src="https://github.com/user-attachments/assets/cd0e0c3a-060c-4e8e-bf28-6284d3cb403e" />
<img width="960" height="540" alt="komputER forum - dokumentacja (5)" src="https://github.com/user-attachments/assets/9d141cfc-e9c7-45ad-b5f7-2ce7faa64f04" />
<img width="960" height="540" alt="komputER forum - dokumentacja (6)" src="https://github.com/user-attachments/assets/5e524a4c-a3e8-4a8a-9575-9177512cdef2" />
<img width="960" height="540" alt="komputER forum - dokumentacja (7)" src="https://github.com/user-attachments/assets/430d30b3-adb9-4cba-afdc-533bb7176420" />
