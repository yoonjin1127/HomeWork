﻿namespace BaekJoonNM
{
    internal class Program  // 2번 N과 M
    {
        /*****************
          * 백트래킹 (Backtracking)
          * 
          * 모든 경우의 수를 전부 고려하는 알고리즘
          * 후보해를 검증 도중 해가 아닌 경우 되돌아가서 다시 해를 찾아가는 기밥
          ******************/

        /************2번****************
        *자연수 N과 M이 주어졌을 때, 아래 조건을 만족하는 길이가 M인 수열을 모두 구하는 프로그램을 작성하시오.
        *
        * 1부터 N까지 자연수 중에서 M개를 고른 수열
        * 같은 수를 여러 번 골라도 된다.
        * 
        * 첫째 줄에 자연수 N과 M이 주어진다. (1 ≤ M ≤ N ≤ 7)
        * 
        * 한 줄에 하나씩 문제의 조건을 만족하는 수열을 출력한다. 
        * 중복되는 수열을 여러 번 출력하면 안되며, 각 수열은 공백으로 구분해서 출력해야 한다.
        * 수열은 사전 순으로 증가하는 순서로 출력해야 한다.
         ******************************/
        
        static void Array()
        {
            // 수열의 길이는 M의 개수와 동일
            int n = 0;
            int m = 0;

            int[] arr = new int[m];
            arr = new int[] { };

            // 중복 for문을 사용해 배열을 만듦
            // 동윤이가 List 쓰라고 함
            for (int i = 0; i <= n; i++)
            {

            }
        }

        static void Main(string[] args)
        {
          
        }
    }
}