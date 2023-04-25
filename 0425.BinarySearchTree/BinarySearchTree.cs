﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure         // 1번
{
    internal class BinarySearchTree<T> where T : IComparable<T>  // 비교가능한 자료형만 T에 넣기        
    {
        private Node root;      // 루트 노드 정의
        
        public BinarySearchTree()   // 생성자 함수
        {
            this.root = null;       // 초기화
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
                else if (item.CompareTo(current.Item)>0)        // 자식이 부모보다 큰 경우
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
            public Node Right { get { return right;} set { right = value; } }     // right의 프로퍼티

            public bool IsRootNode { get { return parent == null; } }     // 루트 노드인지 아닌지 판단 (위에 더이상 부모가 없음)
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }     // 좌측 노드인지 판단 (부모가 있고, this가 부모의 왼쪽에 위치)
            public bool IsRightChild { get { return parent != null && parent.right ==this; } }    // 우측 노드인지 판단

            public bool HasNoChild { get { return left == null && right == null; } }        // 자식이 없을 때 (왼쪽과 오른쪽이 모두 없음)
            public bool HasLeftChild { get { return left != null && right == null; } }      // 좌측 자식만 있을 때 (오른쪽이 없음)
            public bool HasRightChild { get { return left == null && right != null; } }     // 우측 자식만 있음
            public bool HasBothChild { get { return left != null && right != null; } }      // 자식이 둘다 있음

        }
    }
    
}