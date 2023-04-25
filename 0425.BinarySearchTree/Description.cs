using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0425.BinarySearchTree
{
    internal class Description          // 2번
    {

        /*************
         * 이진탐색트리 (BinarySearchTree)
         * 
         * 이진속성과 탐색속성을 적용한 트리
         * 이진탐색을 통한 탐색영역을 절반으로 줄여가며 탐색 가능
         * 이진 : 부모노드는 최대 2개의 자식노드들을 가질 수 있음
         * 탐색 : 자신의 노드보다 작은 값들은 왼쪽, 큰 값들은 오른쪽에 위치
         **************/


        // <이진탐색트리의 시간복잡도>
        // 접근     탐색     삽입      삭제
        // O(log n)		O(log n)	O(log n)	O(log n)


        // <이진탐색트리의 주의점>
        // 이진탐색트리의 노드들이 한쪽 자식으로만 추가되는 불균형 발생 가능
        // 이 경우 탐색영역이 절반으로 줄여지지 않기 떄문에 시간복잡도 증가
        // 이러한 현상을 막기 위해 자가균형ㅇ기능을 추가한 트리의 사용이 일반적
        // 대표적인 방식으로 Red-Black Tree, AVL Tree 등이 있음


        /************************
         * <트리기반 자료구조 순회순서>
         * 
         * 1. 전위순회 : 노드(본인), 왼쪽, 오른쪽
         * 2. 중위순회 : 왼쪽, 노드, 오른쪽    <- 이진탐색트리의 순회 : 오름차순 정렬
         * 3. 후위순회 : 왼쪽, 오른쪽, 노드
         *************************/
    }
}
