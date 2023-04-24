using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0424PriorityQueue
{
    internal class No3          // 응급실 만들기
    {
        static void Emergency()
        {
            // 제네릭 클래스와 인스턴스 생성
            PriorityQueue<string, int> ascendingPQ = new PriorityQueue<string, int>();

             // 포켓몬 응급실 생성
       
                int Golden = 0;

                Console.WriteLine("피카츄 : ");
                Golden = int.Parse(Console.ReadLine());
                ascendingPQ.Enqueue("피카츄", Golden);

                Console.WriteLine("파이리 : ");
                Golden = int.Parse(Console.ReadLine());
                ascendingPQ.Enqueue("파이리", Golden);


                Console.WriteLine("꼬부기 : ");
                Golden = int.Parse(Console.ReadLine());
                ascendingPQ.Enqueue("꼬부기", Golden);

                Console.WriteLine("이상해씨 : ");
                Golden = int.Parse(Console.ReadLine());
                ascendingPQ.Enqueue("이상해씨", Golden);

            while (ascendingPQ.Count > 0)
            {
                Console.WriteLine(ascendingPQ.Dequeue());
            }
            Console.WriteLine("순서대로 응급실에 입장해야 합니다.");
        }
        static void Main(string[] args)
        {
            Emergency();
        }
    }
    }
