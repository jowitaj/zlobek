-------KRÓTKI OPIS --------

Aplikacja dla żłobka to projekt ASP.NET, który umożliwia zarządzanie listą dzieci, grupami, nauczycielami, menu oraz użytkownikami. Dzięki aplikacji, pracownicy żłobka mogą dodawać nowe dzieci do listy, przypisywać je do odpowiednich grup, usuwać lub modyfikować dane dzieci na podstawie ID.

--------URUCHAMIANIE-------

Aby móc skorzystać z projektu Zlobek, potrzebujemy środowiska z zainstalowanym .NET i Microsoft SQL Server. W projekcie zostały użyte różne biblioteki, w tym EntityFrameworkCore, MoQ, NLog, Web i Xunit.

Aby skompilować i uruchomić aplikację, należy najpierw pobrać i zainstalować wymagane biblioteki przy użyciu menedżera pakietów NuGet. Następnie należy skonfigurować połączenie z bazą danych w pliku konfiguracyjnym, aby umożliwić aplikacji dostęp do bazy.

Aby przetestować aplikację, należy użyć narzędzia do testowania, takiego jak np. xUnit, a także zainstalować odpowiednie narzędzia, takie jak Moq, które umożliwiają testowanie kodu.

Projekt należy sklonować z Githuba: https://github.com/jowitaj/zlobek

Aby skonfigurować projekt Zlobek, należy najpierw ustawić połączenie z bazą danych w pliku NurseyDbContext. W celu połączenia z bazą danych Microsoft SQL Server, należy zmodyfikować w tym pliku pole "_connectionString" na podstawie swoich potrzeb. Przykładowa konfiguracja wygląda następująco:

Server=;Database=;Trusted_Connection=True; Należy zastąpić odpowiednim adresem serwera bazy danych, a - nazwą bazy danych, którą chcemy utworzyć lub wykorzystać.

Aby uruchomić projekt, należy zainstalować menedżer pakietów NuGet i dodać migracje, które umożliwią utworzenie bazy danych. Można to zrobić za pomocą konsoli menedżera pakietów NuGet, wpisując następujące polecenia:

Add-Migration Update-Database Po wykonaniu tych kroków, baza danych zostanie utworzona, a aplikacja będzie gotowa do użycia.

---------UŻYTKOWNICY I ROLE--------
W projekcie aplikacji dla żłobka dostępne są trzy konta użytkowników służące do testowania funkcjonalności systemu logowania. Poniżej przedstawione są informacje o tych użytkownikach:

Użytkownik (rola "User") • Email: user@example.com • Hasło: password123 • Imię: Jan • Nazwisko: Kowalski • Numer telefonu: 123456789 • Data urodzenia: 1 stycznia 1990

Menadżer (rola "Manager") • Email: manager@example.com • Hasło: password123 • Imię: Anna • Nazwisko: Nowak • Numer telefonu: 987654321 • Data urodzenia: 1 stycznia 1985

Administrator (rola "Admin") • Email: admin@example.com • Hasło: password123 • Imię: Janusz • Nazwisko: Wiśniewski • Numer telefonu: 135791113 • Data urodzenia: 1 stycznia 1980

Powyższe dane, są jedynie danymi testowymi.

-------- USER EXPERIENCE & DZIAŁANIE APLIKACJI--------

Po uruchomieniu projektu, zostaniesz przeniesiony na stronę główną placówki. Na stronie głównej znajdziesz wiele ciekawych elementów, w tym opis placówki, zajęcia dodatkowe, aktywną mapę z lokalizacją, nagłówek, przycisk przewijania, stopkę i dwa przyciski. Jeden z przycisków jest odnośnikiem do strony na Facebooku, drugi umożliwia logowanie.

Klikając przycisk logowania, zostaniesz przekierowany na stronę rejestracji, gdzie możesz wpisać swój email oraz hasło. Hasło jest zaszyfrowane, dzięki czemu Twoje dane są bezpieczne. Po pomyślnym zalogowaniu zostaniesz przeniesiony do strony z menu, gdzie możesz zarządzać kilkoma obszarami: Użytkownikami, Dziećmi, Menu, Grupami i Nauczycielami. W każdym z tych obszarów możesz wyświetlić listę wszystkich danych, dodać nowe dane, edytować istniejące dane lub je usunąć.

Administrator ma dostęp do wszystkich funkcjonalności, a Nauczyciel może wyświetlać wszystkie listy, edytować dane dziecka oraz zarządzać wszystkimi funkcjonalnościami w menu. Rodzic może jedynie wyświetlać listy.

Wszystkie listy wyświetlane są w postaci tabeli, a dodawanie, edytowanie i usuwanie danych odbywa się za pomocą formularza. Aby wykonać akcję edycji lub usunięcia, musisz podać ID danej pozycji.
