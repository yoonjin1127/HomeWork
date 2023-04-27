using System;
using System.Text;

namespace BaekJoonHanoi
{
    internal class Program      // 1번 하노이탑
    {
        /******************************************************
		 * 재귀 (Recursion)
		 * 
		 * 어떠한 것을 정의할 때 자기 자신을 참조하는 것
		 ******************************************************/

        // <재귀함수 조건>
        // 1. 함수내용 중 자기자신함수를 다시 호출해야함
        // 2. 종료조건이 있어야 함

        /**********1번**********/
        // 한 번에 한 개의 원판만을 다른 탑으로 옮길 수 있다.
        // 쌓아놓은 원판은 항상 위의 것이 아래의 것보다 작아야 한다.
        // 이 작업을 수행하는데 필요한 이동순서를 출력하는 프로그램을 작성하라. (단, 이동 횟수는 최소)

        // 첫째 줄에 첫번째 장대에 쌓인 원판의 개수 N(1<=N<=20)이 주어진다.

        // 첫째 줄에 옮긴 횟수 K를 출력한다.
        // 두 번째 줄부터 수행 과정을 출력한다.
        // 두 번째 줄부터 K개의 줄에 걸쳐 두 정수 A B를 빈칸을 사이에 두고 출력하는데,
        // 이는 A번째 탑의 가장 위에 있는 원판을 B번째 탑의 가장 위로 옮긴다는 뜻이다.



        static int InputNumber(string input)        // 원판의 개수를 입력받음
        {
            int number = int.Parse(input);
            return number;
        }

        // StringBuilder를 사용하면 문자열을 조합할때마다 새로운 변수를 생성하지 않고, 결합이 가능함
        // 내부에 함수가 존재해서 값을 조합하거나 삭제할 때에도 새로운 인스턴스가 생성되지 않음
        // 문자열, 원반 개수, 시작 장대, 목적 장대의 변수를 설정
        static void HanoiTower(StringBuilder sb, int disks, int start, int end)
        {
            // 탈출 조건
            if (disks == 0)
                return;

            // 나머지 장대의 번호
            // =  (장대 번호 총합) - (시작 장대 번호) - (목표 장대 번호)
            int other = 6 - start - end;

            // 재귀 조건
            HanoiTower(sb, disks - 1, start, other);    // 맨 밑 하나 빼고 (n-1)개의 원반을 나머지 장대로 이동
            sb.AppendFormat($"{start} {end}\n");        // 맨 밑에 남아있던 원반 하나를 목표 장대로 이동
            HanoiTower(sb, disks - 1, other, end);      // 나머지 장대에 보냈던 것들(n-1)을 목표 장대에 이동시킴  
        }

        static void Main(string[] args)
        {
            int disks = InputNumber(Console.ReadLine());    // 원반 개수 입력
           
            // 최소 이동 횟수 계산
            // Math.Pow(2, disks) == 2^disk개수
            // 만약 원반의 개수가 3개라면, 2^3-1= 7로, 7번 이동해야 함
            Console.WriteLine(Math.Pow(2, disks)-1);   
            
            // 문자열 저장 변수 생성
            StringBuilder sb = new StringBuilder();

            // 하노이타워 메서드 호출
            HanoiTower(sb, disks, 1, 3);

            // 문자열 변환 후 출력
            Console.WriteLine(sb.ToString());
        }
        
    }
}