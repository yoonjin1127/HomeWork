using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0426HashTable
{
    // 제네릭 클래스 Dictionary 생성
    internal class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>   // 비교 가능한 값 
    {
        private const int DefaultCapacity = 1000;       // 기본 용량을 상수로 초기화

        private struct Entry        // Entry 구조체 생성
        {
            public enum State { None, Using, Deleted }       // 상태를 나타내는 자료형 생성

            public State state;
            public int hashCode;
            public TKey key;
            public TValue value;
        }
        private Entry[] table;      // Entry의 항목을 저장하는 table 배열 선언

        public Dictionary()         // 생성자 함수
        {
            table = new Entry[DefaultCapacity];         // Entry 배열의 개수를 기본 용량(1000)으로 초기화
        }

        // this[Tkey key]는 인덱서
        // 객체 인스턴스를 배열처럼 인덱싱할 수 있게 함
        // TKey 형식의 키를 인덱스로 사용해, TValue 형식의 값을 반환
        public TValue this[TKey key]
        {
            get
            {
                // 1. key를 index로 해싱
                // GetHashCode로 key의 해시코드를 계산하고
                // 계산된 해시코드를 table 배열길이로 나눈 나머지값을 구한 다음
                // Math.Abs 메소드를 사용하여 양수로 변환
                int index = Math.Abs(key.GetHashCode() % table.Length);

                // 2. 그 인덱스를 사용중이라면, 계속해서 다른 인덱스를 탐색
                while (table[index].state == Entry.State.Using)
                {
                    // 3-1. 동일한 키 값을 찾았을 때 반환하기
                    if (key.Equals(table[index].key))
                    {
                        return table[index].value;
                    }
                    // 3-2. 동일한 키 값을 못 찾고 비어있는 공간을 만났을 때
                    if (table[index].state == Entry.State.None)
                    {
                        break;
                    }
                    // 3-3. 다음 index로 이동
                    // 배열의 index를 순환 시킴(ex: 0에서 1, 1에서 2, 2에서 3...)
                    index = ++index % table.Length;
                }
                // key에 해당하는 값을 찾지 못한 경우 예외 발생
                throw new KeyNotFoundException();
            }
            set
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);

                // 2. 그 index를 사용중이라면, 계속해서 다른 인덱스를 탐색
                while (table[index].state == Entry.State.Using)
                {
                    // 3-1. 동일한 키 값을 찾았을 때 덮어씌우기
                    if (key.Equals(table[index].key))
                    {
                        table[index].value = value;
                        return;
                    }
                    if (table[index].state == Entry.State.None)
                    {
                        break;
                    }
                    index += index < table.Length - 1 ? index + 1 : 0;
                }
                throw new KeyNotFoundException();
            }
        }
        public void Add(TKey key, TValue value)
        {
            // 1. key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);

            // 2. 그 인덱스를 사용중이라면, 계속해서 다른 인덱스를 탐색
            while (table[index].state == Entry.State.Using)
            {
                // 3-1. 동일한 키값을 찾았을 때 오류 (C# Dictionary는 중복 키를 허용하지 않음)
                if (key.Equals(table[index].key))
                {
                    throw new ArgumentException();
                }
                // 다음 인덱스를 검사
                // 다음 인덱스가 테이블 크기를 넘어가면 다시 0부터 시작
                // 3-2. 다음 index로 이동
                else
                {
                    index = ++index % table.Length;
                }
            }

            // 3. 사용중이 아닌 인덱스를 발견한 경우 그 위치에 저장
            table[index].hashCode = key.GetHashCode();
            table[index].key = key;
            table[index].value = value;
            table[index].state = Entry.State.Using;
        }
        public bool Remove(TKey key)
        {
            // 1. key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);

            // 2.  key값과 동일한 데이터를 찾을때까지 index 증가
            while (table[index].state == Entry.State.Using)
            {
                // 3-1. 동일한 키값을 찾았을 때 지운 상태로 표시
                if (key.Equals(table[index].key))
                {
                    table[index].state = Entry.State.Delected;
                }
                // 3-2. 동일한 키값을 못찾고 비어있는 공간을 만났을때
                if (table[index].state == Entry.State.None)
                {
                    break;
                }
                // 3-3. 다음 index로 이동
                index = index < table.Length - 1 ? index + 1 : 0;
            }
            return false;
        }
    }
}
