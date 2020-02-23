# Notes til eksamen i DAT154

By Sondre Lindaas Gjesdal

## Pensumliste DAT154 Vår 2020

### C# 6 for programmers / Paul Deitel, Harvey Deitel.

Hele boken er i utgangspunktet pensum, MEN:

* Mange konsepter skal være kjent fra tidligere programmeringskurs, slik som klasser, objekter, kontrollstrukturer, metoder, arv, unntakshåndtering. Kapitlene som omhandler dette kan leses vært verfladisk eller hoppes over om dere allerede føler dere behersker dette. Det vil ikke være naturlig å ha utdypende spørsmål om dette på eksamen, MEN dere kan bli bedt om å forlate kode eller  krive kode som inneholder disse tingene, så det er viktig dere har forståelse av det.
* Boken bruker en del sider på å utdype spesifikke kontroller i grafiske elementer. Det er ikke spesielt relevant å pugge disse, en oversikt over den overordnende virkemåten til slike kontroller generelt er nok.
* Hold fokus på det vi har snakket om i timene

### Windowsprogrammering med Windows SDK/C++

* SDK-delen av boken er pensum (til og med side 72)
* Hold fokus på det vi har snakket om i timene

### Microsoft Application Architecture Guide 2nd Edition

* Del 1 (Kapittel 1 t.o.m. 4) er pensum

### Forlesningsnotater

Forelesningsnotater/slides og tilhørende kodeksempler som lagt ut på Canvas er pensum

### Laboppgaver

Laboppgavene er pensum. Det er her viktig at dere skjønner hva dere har gjort og hvorfor/hvordan
det virker. Det forutsettes at dere har implementert alt som oppgavebeskrivelsen ba om.

## Stikkord

(Listen inneholder sentrale elementer, men det kan selvsagt dukke opp temaer fra pensum som ikke
står på denne kortlisten under eksamen)

### C++
#### What is C

C is a functional programming language form the 70s. Used to make complex systems like drivers and OS

#### What is C++

* C++ is a high-level programming language developed by Bjarne Stroustrup at Bell Labs. Based on C
* C++ adds OO features to it's predecessor, C.
C from 1970s, and C++ from 1980s.

#### Where is C/C++ used

* OS like Linux, Windows etc
* Drivers for different hardware units
* Advanced logic
* A lot of programs written between 1970 and now.

#### Differences from Java
1. C++ makes machine code directly
2. Has Pointers
3. Handles memory manually - No garbage collection

#### Similarities
Object oriented

### C++

Typical C/C++ Development Environment usually goes through five phases:

1. Edit
2. preprocess
3. compile
4. link
5. execute.

* Edit: Make a text file
* Preprocess: 1 part compiling - include header files and resolve constant symbols
* Compile: After symbols and include files have been resolved and included - transfers text to machine code
* Link: Bind your machine code modules together with libraries and make a complete program
* Execute: Run the program

### Hello World

````` c++
#include <iostream>
using namespace std;
int main()
{
    cout << "Hello World!\n";
    cin.get();
}
`````

#### Header files in C++

The C/C++ Standard Library gives a variety of functions, which signature/prototype is in a header files.

In C normally all the header files begin with the .h extension, but in C++ not always like ``<iostream>``
A header file in C/C++ contains:

* Function definitions
* Data type definitions
* Macros

Header files offer of a preprocessor directive called ``#include``. These preprocessor directives are responsible for instructing the C/C++ compiler that these files need to be processed before compilation.

C++ program normally contains the header file ``<istream>`` which has input and output functions/objects

* cin for input
* cout for output

#### The Preprocessor and ``#include``

Before the source code is compiled, it gets automatically processed due to the presence of preprocessor directives. All preprocessor instructions typically start with a # sign. The most common is ``#include`` and ``#define``.




* Klasser
* Konstuktører/Destruktører
* Minnehåndtering
* Pekere/addresser
* Struktur

### SDK

* Struktur
* Vindusmeldinger
  * Meldingsløkke
  * Meldingshåndtering
* Resurser
* Dialoger
* Grafikk
  * Device Contexts
  * GDI-Objekter
  * Virtuelle device contexts/kopiering
  * Animasjon
* Funksjonspekere
* Tråder

### .Net

* Struktur
* CLR
* Typer
* Assemblies/metadata
* Navnerom/referanser
* FCL (Framwork Class Library)
* Biblioteker
* Grafiske grensesnitt
  * Windows Forms
  * WPF
  * Universal Apps
  * Delgater
* Hendelser (Events)
  * Håndtering
  * Typer
* Grafikk
  * Tegneverktøy
  * Animasjon
* Linq
  * Databaser
  * XML
* Web
  * ASP.NET
  * MVC
  * WebAPI
* Databaser
  * ADO.NET
  * Linq
* Lambda

### Arkitektur

* Modulær oppbygning
* Bruk av multiple programmeringsspråk
* Programvarearkitektur
* Arkitekturmønstre
* Universell utforming