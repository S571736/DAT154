## Windows SDK
* Based on functions
  * Not object oriented
* Can make object oriented programs by creating ovjects that encapsulate functions
* Uses normally C and C++....

### Windows messages
* The windows OS is based on messages
  * Sends messages to programs when events occur
  * Messages are out into the message queue
  * Message loop in program retrieves messages and handles the message
* Message handling example
  1. Mouse click
  2. Mouse driver
  3. I/O manager
  4. User32
  5. Message queue
  6. WinMain
  7. User32
  8. WndProc


### Pointers, SDK Deci(?)
**Compact C/C++ notations**

````c++
int tab[] = {0,1,2,3,5,8,-1}
int* pi = tab;
while({)*++pi != -1){
    cout << *pi << ',';
}
cout << endl;
````

**Pointers and functions**
````c++
#include <iostream>
using namespace std;

void Double(int* pi)
{
    int tall = *pi;
    tall = tall * 2;
    *pi = tall;
}

int main()
{
int n;
cout << "Enter n : ";
cin >> n;
Double(&n);
cout << "n x 2 = : " << n << endl;
}
````

**Dynamic variables** must always be deleted

````c++
int main(){
    X a("Hello");
    X* pb= new X("World");
    
    a.Print();
    pb -> Print();
    delete pb;
}
````
### C#

````C#
class HelloWorld{
    public static void main(){
        System.Console.WriteLine("Hello World");
    }
}
````
### Compile
````
csc /target:exe helloworld.cs
````

### .NET components
* Common language runtime(CLR)
  * Kernel, Required to run CIL code
* Framework class library(FCL)
  * Contains 6000+ classes for use in .NET library(replaces API calls)
* Compilers
  * Create assemblies containing CIL to run on the CLR
  
### Namespaces
* A namespace is a way to organize .NET classes
* A namespace groups together classes with similar functions
* A namespace also makes it easier to avoid duplicate class names
* All the classes in the FCL are divided into namespaces based on their functionality
* A class is identified by both its namespace and actual name
* When we use a class, we need to tell the compiler both the namespace and the name of the class
* Examples:
  * ``System.Console.WriteLine("Hello World);``
  * ``Library.Book book = new Library.Book("Title");``
  
#### Namespaces - Importing
* For  commonly used namespaces, we can import the namespace by using the using directive
* Example:
````c#
using System;
class CelloWorld {
    public static void Main(){
        Console.WriteLine("Cello World");
    }
}
````
#### Namespaces - creating
* A namespace is created by wrapping our class(es) in a namespace block

#### Namespaces - nesting
* Namespaces can be nested
* The using keyword does not provide access to namespaces nested below the specified level
  
#### Namespaces - aliases
* One can use aliases to provide a simplified name for a class or namespace
````c#
using s = System; // Namespace alias
using c = System.Console; // Class alias

s::Console.WriteLine();
c.WriteLine();
````

### References
* References points to external libraries
* By default, not everything is referenced from a project.
* Might need to set up a reference to access a given namespace.
* References can be browsed in the object browser in VS

### Managed Code
* Managed code is code that targets the CLR
* Code that does not target the CLR(old DLL's...) is unmanaged code
* Managed code is handled by the CLR, that provides
  * Security checks
  * Memory Management/Garbage Collection
  * Access to managed data

### Assemblies
* An assembly is a .NET library or executable with the following properties:
  * Contains IL code which is compiled .NET source for example C# or VB.NET
  * Contains metadata which describes the interface.
  
### Libraries

### Value Types vs Reference types
* .NET has two kind of types
  * Value Types
  * Reference types
  
### Reference types
* Reference types are stored on the heap
* A pointer to the memory location occupied by the type is store on the stack


### Value types
* A value type does not point to the heap, it kepps its value on the stack*
* When assigned to a new variable, the content is copied
* Still behaves as an Object, and has methods
* Implicit inheretance from System.ValueType
  
### Boxing
* Boxing is the process that happens then a Value Type is encapsulated in a Reference Type, and placed on the stack
* This creates a new copy of the value type
* Using a non-generics data structudre causes all Value Types to be boxed(And needs to be unboxed upon retrieval)
* Boxing is a resource intensive
* When using a data structure that supports generics, Boxing does not take place

### REP: Common intermediate Language
* Visual Studio does not let us mix different languages in the same VS project
* But it is possible to create different projects inside a solution, where each project uses its own language
* It is also possible to manually assemble the .NET modules into .NET assemblies
* All .NET code no matter the language are compile to CIL code
* Possible to use several different .NET languages in the same project
* One language can use or subclass classes written in another language
* One language can throw an exception that is caught in another language

### Subclasses
* As seem subclasses across languages
* This is written the exact same way as you would extend a native class
* Just remember to import the required namespaces(There might be implicit namespaces in the foreign language)
  
### Compiling
* Normally, when code is compiled with a .NET compiler, we get a standalone assembly, which contains
  * Metadata
  * Executable CIL code
* Linking, as known from C++ is normally no longer done manually, but done automatically at runtime.

### Demo - IL code similarity
* IL code output will be similar for similar code, no matter the original language
* Differences are due to compiler handling
* Note that some languages might lack some features, so writing identical code in two languages might not always be possible