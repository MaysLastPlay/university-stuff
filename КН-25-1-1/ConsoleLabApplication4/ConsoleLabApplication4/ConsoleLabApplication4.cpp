#include <iostream>
using namespace std;

void function(int a[], int size);

int main(){
    setlocale(LC_ALL, "uk_UA");
    int yes[] = { 1, 3, 7, 13, 21, 5, 8, 16, 11 };
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
    int min1 = 2e9, min2 = 2e9, i1 = 0, i2 = 0, sum = 0, count = 0;

    for (int i = 0; i < size; ++i) {
        if (a[i] < min1) { min2 = min1; i2 = i1; min1 = a[i]; i1 = i;
        }
        else if (a[i] < min2 && i != i1) {
            min2 = a[i]; i2 = i;
        }
    }
    int L, R;
if (i1 < i2) {
    L = i1;
    R = i2;
} else {
    L = i2;
    R = i1;
}


    for (int i = L + 1; i < R; ++i) {
        sum += a[i];
        count++;
    }

    cout << "Min1:" << min1 << " Min2:" << min2 << "\nSum:" << sum << " Count:" << count << endl;

}

const int MAX = 100;

void calculateVectorX(double X[], int n, int k) {
    for (int j = 0; j < n; ++j) {
        X[j] = (j + 1 <= k) ? k * sin(j + 1) : cos(j + 1);
    }
}

void multiplyMatrix(const double A[][MAX], const double X[], double Z[], int m, int n) {
    for (int i = 0; i < m; ++i) {
        Z[i] = 0;
        for (int j = 0; j < n; ++j) {
            Z[i] += A[i][j] * X[j];
        }
    }
}

void analyzeResult(const double Z[], int m) {
    cout << "\n-----------------------------------" << endl;
    cout << "Отриманий вектор Z: ";
    for (int i = 0; i < m; ++i) {
        cout << Z[i] << " ";
    }
    cout << endl;

    for (int i = 0; i < m - 1; ++i) {
        if (Z[i] > Z[i+1]) {
            cout << "Результат: Вектор НЕ впорядкований." << endl;
            cout << "Елемент, що порушив порядок: " << Z[i+1] << endl;
            cout << "Порядковий номер елемента: " << i + 2 << endl;
            cout << "-----------------------------------" << endl;
            return;
        }
    }

    cout << "Результат: Вектор впорядкований за збільшенням." << endl;
    cout << "-----------------------------------" << endl;
}

int main() {
    setlocale(LC_ALL, ""); // Для коректного виводу кирилиці

    int m, n, k;
    double A[MAX][MAX];
    double X[MAX];
    double Z[MAX];

    cout << "Введіть кількість рядків (m): ";
    cin >> m;
    cout << "Введіть кількість стовпців (n): ";
    cin >> n;
    cout << "Введіть параметр k: ";
    cin >> k;

    cout << "Введіть елементи матриці A по рядках:\n";
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
            cout << "A[" << i + 1 << "][" << j + 1 << "]: ";
            cin >> A[i][j];
        }
    }

    calculateVectorX(X, n, k);
    multiplyMatrix(A, X, Z, m, n);
    analyzeResult(Z, m);

    return 0;
}
