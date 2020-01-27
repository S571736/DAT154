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

`````c++
int main(){
    X a("Hello");
    X* pb= new X("World");
    
    a.Print();
    pb -> Print();
    delete pb;
}
````