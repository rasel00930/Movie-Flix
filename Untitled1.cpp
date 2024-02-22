#include<bits/stdc++.h>
using namespace std;
const int N=550;
int a[N];


void solve()
{
  int n;
  cin>>n;

  int countt=-1;
  for(int i=1;i<=n;i++)

      cin>>a[i];

  for(int i=1;i<=n;i++)

      for(int j=i+1;j<=n;j++)
      {
          int x =a[j]-a[i];


           countt=max(countt,x);


      }
      if (countt>0)
      {
        cout<<countt<<endl;
      }
      else
      {
          cout<< 0;
      }




}


int main()
{
    int t;
    cin>>t;
    while(t--)
        solve();
    return 0;
}
