#include <iostream>
#include <array>
using namespace std;
int main(){
    array<int, 3> tab;
    
    for(int i = 0; i< tab.size(); i++){
        tab[i] = rand() % 22 + 1998;
    }
    
    int* p = &tab[0];
    cout << "Peker\n";
    for(int i = 0; i < tab.size(); i++){
        cout << *p << endl;
        p++;
    }
    cout << "Direkte\n";
    for(int i = 0; i < tab.size(); i++){
        cout << tab[i] << endl;
    }
    cout << "Random: ";
    int s = rand() % 22 + 1998;
    cout << s;
}