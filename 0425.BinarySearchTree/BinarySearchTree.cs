using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0425.BinarySearchTree         // 1번
{
    internal class BinarySearchTree<T> where T : IComparable<T>  // 비교가능한 자료형만 T에 넣기        
    {
        private Node root;      // 루트 노드 정의

        public BinarySearchTree()   // 생성자 함수
        {
            root = null;       // 초기화
        }

        public bool Add(T item)     // 추가 함수 생성
        {
            Node newNode = new Node(item, null, null, null);    // item, left, right, parent를 초기화한 새로운 노드 생성

            if (root == null)       // 루트가 비어있는 경우, 새로 넣는 노드가 루트 노드가 된다
            {
                root = newNode;
                return true;
            }
            Node current = root;    // 최근 노드를 정의, 루트로 초기화
            while (current != null) // 최근 노드가 존재하면 계속 반복
            {
                // CompareTo는 IComparable의 메서드
                // 두 문자열의 정렬 순서가 동일하면 0
                // 첫 번째 문자열이 두 번째 문자열보다 빠른 경우 0보다 큰 값
                // 첫 번째 문자열이 두 번째 문자열보다 느린 경우 0보다 작은 값

                if (item.CompareTo(current.Item) < 0)   // 아이템이 current 아이템보다 빠른 경우(우선순위에 있는/숫자가 작은 경우)
                {                                       // = 자식이 부모보다 작은 경우
                    // 루트의 좌측 자식이 존재하는 경우
                    if (current.Left != null)
                    {
                        // 자식과 또 비교하기 위해 current 왼쪽 자식으로 설정
                        // 기존 좌측 자식의 값이 부모 위치에 들어가, if문 밖으로 나간 뒤,
                        // 새로운 값을 자식 삼아 판단함
                        current = current.Left;
                    }
                    // 비교 노드가 좌측 자식이 없는 경우
                    else
                    {
                        // 그 자리가 지금 추가가 될 자리
                        current.Left = newNode;     // 새로운 노드를 좌측 자식에 추가
                        newNode.Parent = current;   // 새로운 노드의 부모가 현재 있던 노드
                        break;
                    }
                }
                else if (item.CompareTo(current.Item) > 0)        // 자식이 부모보다 큰 경우
                {
                    // 루트의 우측 자식이 존재하는 경우
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                    // 루트의 우측 자식이 존재하지 않는 경우
                    else
                    {
                        current.Right = newNode;     // 새로운 노드를 우측 자식에 추가
                        newNode.Parent = current;    // 새로운 노드의 부모가 현재 있던 노드
                        break;
                    }
                }
                // 동일한 데이터가 들어온 경우
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool Remove(T item)      // 제거 함수 생성
        {
            if (root == null)           // 루트가 없다면 거짓
                return false;

            Node findNode = FindNode(item);     // 메서드 FindNode의 인스턴스 findNode 생성
            // 찾는 값이 비었을 때
            if (findNode == null)
            {
                return false;
            }
            // 찾는 값이 존재할 때
            else
            {
                EraseNode(findNode);        // 찾는 값을 삭제
                return true;
            }

        }

        public void Clear()             // 전체 삭제 함수 생성
        {
            root = null;                // 루트에 null 삽입
        }

        public bool TryGetValue(T item, out T outValue)     // 노드 탐색 함수 생성
        {
            if (root == null)       // 루트가 없을 때 (트리가 비어있을 때)
            {
                outValue = default;  // outValue 기본값으로 초기화
                return false;
            }

            Node findNode = FindNode(item);                 // 탐색 노드의 인스턴스 생성
            if (findNode == null)                           // 탐색 노드가 비어있을 때
            {
                outValue = default;
                return false;
            }
            else                                            // 탐색 노드가 차 있을 때
            {
                outValue = findNode.Item;
                return true;
            }
        }

        private Node FindNode(T item)       // 해당 아이템을 가지는 노드를 찾는 메서드
        {
            if (root == null)               // 루트가 비었을 때 null 반환
                return null;

            Node current = root;            // 루트부터 노드를 정의
            while (current != null)         // 노드가 비어있지 않은 경우 계속 반복
            {
                // 찾는 아이템이 노드의 아이템보다 작을 때
                if (item.CompareTo(current.Item) < 0)
                {
                    current = current.Left;                 // 새로운 값을 자식 삼아 판단
                }
                // 찾는 아이템이 노드의 아이템보다 클 때
                else if (item.CompareTo(current.Item) > 0)
                {
                    current = current.Right;
                }
                // 찾는 아이템과 노드의 아이템이 동일할 때
                {
                    return current;                         // 노드의 아이템을 그대로 출력
                }
            }
            return null;
        }

        private void EraseNode(Node node)                   // 삭제 함수 생성
        {
            if (node.HasNoChild)                             // 자식이 없는 노드의 경우
            {
                if (node.IsLeftChild)
                    node.Parent.Left = null;                // 노드가 좌측 자식인 경우, 부모의 좌측 자식에 null 삽입

                else if (node.IsRightChild)
                    node.Parent.Right = null;                // 노드가 우측 자식인 경우, 부모의 우측 자식에 null 대입

                else
                    root = null;                             // 부모도 자식도 없는 노드는 루트이므로, 루트에 null 삽입
            }
            else if (node.HasLeftChild || node.HasRightChild)   // 우측 or 좌측 자식이 있는 노드의 경우
            {
                Node parent = node.Parent;                      // 자식 node의 부모 노드인 parent
                // 삼항 연산자
                // 좌측 자식이 있으면 좌측을, 좌측 자식이 존재하지 않으면 우측 자식을 child 변수에 대입
                Node child = node.HasLeftChild ? node.Left : node.Right;

                if (node.IsLeftChild)                           // 노드가 좌측 자식인 경우
                {
                    parent.Left = child;
                    child.Parent = parent;                       // 자식변수를 부모 노드 좌측에 삽입
                }                                                // 부모를 자식의 부모노드에 삽입

                else if (node.IsRightChild)
                {
                    parent.Right = child;
                    child.Parent = parent;
                }
                else                                            // 부모가 없으므로, 자식변수는 루트 노드이다
                {
                    root = child;
                    child.Parent = parent;
                }
            }
            else                                                 // if (HasBothChild) 자식노드가 두 개인 노드일 경우
            {
                // 왼쪽 자식 중 가장 큰 값과 데이터 교환한 후, 그 노드를 지워주는 방식으로 대체
                Node replaceNode = node.Left;
                while (replaceNode.Right != null)
                {
                    replaceNode = replaceNode.Right;        // 왼쪽 자식의 가장 아래쪽 오른쪽 자식으로 내려감 
                }
                node.Item = replaceNode.Item;
                EraseNode(replaceNode);
            }
        }

        private class Node      // 노드 클래스 생성
        {
            private T item;     // 노드, 부모, 좌측 자식, 우측 자식
            private Node parent;
            private Node left;
            private Node right;

            public Node(T item, Node parent, Node left, Node right)    // 생성자 함수
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }


            // 프로퍼티 작성

            public T Item { get { return item; } set { item = value; } }      // item의 프로퍼티
            public Node Parent { get { return parent; } set { parent = value; } }   // parent의 프로퍼티
            public Node Left { get { return left; } set { left = value; } }       // left의 프로퍼티
            public Node Right { get { return right; } set { right = value; } }     // right의 프로퍼티

            public bool IsRootNode { get { return parent == null; } }     // 루트 노드인지 아닌지 판단 (위에 더이상 부모가 없음)
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }     // 좌측 노드인지 판단 (부모가 있고, this가 부모의 왼쪽에 위치)
            public bool IsRightChild { get { return parent != null && parent.right == this; } }    // 우측 노드인지 판단

            public bool HasNoChild { get { return left == null && right == null; } }        // 자식이 없을 때 (왼쪽과 오른쪽이 모두 없음)
            public bool HasLeftChild { get { return left != null && right == null; } }      // 좌측 자식만 있을 때 (오른쪽이 없음)
            public bool HasRightChild { get { return left == null && right != null; } }     // 우측 자식만 있음
            public bool HasBothChild { get { return left != null && right != null; } }      // 자식이 둘다 있음

        }
    }

}
