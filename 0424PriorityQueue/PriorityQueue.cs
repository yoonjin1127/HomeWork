using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{    
    // 완전 이진트리는 배열로도 만들 수 있다

    /***********
     * 이진트리의 이동법
     * 
     * 왼쪽 : index * 2 + 1 (ex: 1번 노드에서 3번 노드로 이동)
     * 오른쪽 : index * 2 + 2 (ex: 1번 노드에서 4번 노드로 이동)
     * 부모: (index - 1) / 2 (ex: 3번 노드에서 1번 노드로 이동)
    *******************/

    // 이진트리에서 우선순위가 높은 녀석이 위에 있는 상태를 힙 상태라고 함

    // 힙에서 우선순위가 더 높은 노드가 추가됐을 때, 부모노드와 교체됨(계속해서 승격)


    internal class PriorityQueue<TElement>      // 제네릭(일반화) 사용
    {
        private struct Node     // Node 구조체 생성
        {
            public TElement element;        // 변수 정의
            public int priority;
        }

        private List<Node> nodes;       // Node 구조체의 리스트 객체 nodes 선언

        public PriorityQueue()          // 생성자 함수로 nodes변수 초기화
        {
            this.nodes = new List<Node>();
        }

        public int Count { get { return nodes.Count; } }    // 우선순위 큐의 크기(요소의 개수)를 반환

       public void Enqueue(TElement element, int priority)  // 큐에 값을 추가하는 함수
        {
            Node newNode = new Node() { element = element, priority = priority };
            // 새로운 노드 생성

            // 1. 가장 뒤에 데이터 추가
            nodes.Add(newNode);         // 리스트의 Add 메소드를 사용해 새로운 노드 추가
            int newNodeIndex = nodes.Count - 1;     // 새로운 노드의 순서 = 우선순위 큐의 크기 - 1
                                                    // ex : 마지막 순서인 4번째 = 크기가 5인 큐에서 1을 뺌

            // 2. 새로운 노드를 힙상태가 유지되도록 승격 작업 반복
            while (newNodeIndex > 0)    // 새로운 노드의 순서가 0보다 클 때 반복
            {                              // 0이 되면 가장 우선순위가 높은 노드가 되기 때문에 종료함
                // 2-1. 부모 노드 확인
                int parentIndex = GetParentIndex(newNodeIndex);     // 부모 노드의 순서를 구하는 함수를 사용
                Node parentNode = nodes[parentIndex];               // 구한 순서를 대입

                // 2-2. 자식 노드가 부모 노드보다 우선순위가 높으면 교체
                if(newNode.priority < parentNode.priority)  // 기본적으로 내림차순(숫자가 작을수록 우선순위가 높다)
                {
                    nodes[newNodeIndex] = parentNode;       // 새 자식 노드 값에 부모노드 값을 넣음
                    nodes[parentIndex] = newNode;           // 부모노드 값에 새 자식노드 값을 넣음 (교체)
                    newNodeIndex = parentIndex;             // 새 자식노드 위치에 부모노드 위치를 넣음
                }
                else    // 아닌 경우 그냥 둔다
                {
                    break;
                }

            }
       }
       public TElement Dequeue ()   // TElement를 매개변수로 하는 함수
        {                           // 큐에서 값을 제거
            Node rootNode = nodes[0];   // 0번째 맨 위의 노드를 rootNode로 초기화

            // 1. 가장 마지막 노드를 최상단으로 위치
        }
    }
}
