#include <iostream>
#include <cmath>
using namespace std;

/*void function(int a[], int size);

int main(){
    setlocale(LC_ALL, "uk_UA");
    int yes[] = { 1, 7, 13, 21, 5, 8, 16, 11, 3 };
    int arr[100];
    int choice;

    cout << "Choose:\n1. Test\n2. Enter from keyboard\n3. Exit\nYour choice: ";
    cin >> choice;

    switch (choice) {
    case 1:
        function(yes, 9);
        break;
    case 2:
        int n;
        cout << "Enter array size: ";
        cin >> n;

        if (n < 2) {
            cout << "You need minimum 2 elements." << endl;
        }
        else {
            if (n > 100) n = 100;

            cout << "Enter " << n << " numbers: ";
            for (int i = 0; i < n; i++) {
                cin >> arr[i];
            }
            function(arr, n);
        }
    case 3:
        break;
    default:
        cout << "You entered wrong number." << endl;
        break;
    }
    system("pause");
}

void function(int a[], int size) {
    int min1 = 2e9, min2 = 2e9, i1 = 0, i2 = 0, sum = 0, count = 0, left, right;

    for (int i = 0; i < size; ++i) {
        if (a[i] < min1) {
           min2 = min1;
           i2 = i1;
           min1 = a[i];
           i1 = i;
        }
        else if (a[i] < min2 && i != i1) {
            min2 = a[i];
            i2 = i;
        }
    }

    if (i1 < i2) {
        left = i1;
        right = i2;
    }
    else {
        left = i2;
        right = i1;
    }

    if (left > right) {
        count = left - right - 1;
    }

    for (int i = left + 1; i < right; ++i) {
        sum += a[i];
        count++;
    }

    cout << "Min1:" << min1 << " Min2:" << min2 << "\nSum:" << sum << " Count:" << count << endl;
}*/

// 4.2
const int yay = 100;

void vectorx(double X[], int n, int k) {
    for (int i = 0; i < n; ++i) {
        int j = i + 1;
        if (j <= k)
            X[i] = k * sin(j);
        else
            X[i] = cos(j);
    }
}

    void idkwhattocallthis(const double A[][yay], const double X[], double Z[], int m, int n) {
        for (int i = 0; i < m; ++i) {
            Z[i] = 0;
            for (int j = 0; j < n; ++j) {
                Z[i] += A[i][j] * X[j];
            }
        }
    }
    void show(const double Z[], int m) {
       
        for (int i = 0; i < m; ++i) {
            cout << Z[i] << " ";
        }
        cout << endl;
    }
int result(const double Z[], int m) {
    for (int i = 0; i < m - 1; ++i) {
        if (Z[i] > Z[i + 1]) {
       
            cout << "element that disturbed the order: " << Z[i + 1] << endl;
            cout << "Element number: " << i + 2 << endl;
            return 0;
        }
    }
    return 1;
}

int main() {
    setlocale(LC_ALL, "");

    int m, n, k;
    double A[yay][yay];
    double X[yay];
    double Z[yay];

    cout << "Enter number of rows (m): ";
    cin >> m;
    cout << "Enter number of columns (n): ";
    cin >> n;
    cout << "Enter k: ";
    cin >> k;

    cout << "Enter numbers of matrix A row by row:\n";
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
            cout << "A[" << i + 1 << "][" << j + 1 << "]: ";
            cin >> A[i][j];
        }
    }

    vectorx(X, n, k);
    idkwhattocallthis(A, X, Z, m, n);
    cout << "vector Z: ";
    show(Z, m);

    if (result(Z, m)==1)
        cout << "Result: vector sorted in ascending order." << endl;
    else
        cout << "Result: vector is not ordered." << endl;
    system("pause");
}