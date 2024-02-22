#include <iostream>
#include <vector>
#include <unordered_map>
#include <algorithm>

using namespace std;

bool checkConsistency(vector<int>& order, vector<int>& screenshot) {
    unordered_map<int, int> orderMap;
    for (int i = 0; i < order.size(); ++i) {
        orderMap[order[i]] = i;
    }

    for (int i = 0; i < screenshot.size(); ++i) {
        if (orderMap[screenshot[i]] != i) {
            return false;
        }
    }

    return true;
}

int main() {
    int n;
    cin >> n;

    for (int i = 0; i < n; ++i) {
        int k, m;
        cin >> k >> m;

        vector<int> order(k);
        for (int j = 0; j < k; ++j) {
            cin >> order[j];
        }

        bool consistent = true;
        for (int j = 0; j < m - 1; ++j) {
            vector<int> screenshot(k);
            for (int l = 0; l < k; ++l) {
                cin >> screenshot[l];
            }
            if (!checkConsistency(order, screenshot)) {
                consistent = false;
                break;
            }
        }

        if (consistent) {
            cout << "YES" << endl;
        } else {
            cout << "NO" << endl;
            // Skip remaining screenshots for this test case
            for (int j = 0; j < m - 1; ++j) {
                for (int l = 0; l < k; ++l) {
                    cin >> order[l];
                }
            }
        }
    }

    return 0;
}

