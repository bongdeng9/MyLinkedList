using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm1
{
    /// <summary>
    /// LinkedListNode 가 생긴 이유! 호텔에 방을 잡는데 연결리스트 방식은 연속된 방일 필요 없음 
    /// 방을 아무데나 잡고 방끼리 워프할 수 있는 장치를 마련함. 아무튼 그럼
    /// 한 방 기준으로 이전 방에 있는것과 다음 방까지 빠르게 이동할 수 있는 알고리즘
    /// 순간이동 개념
    /// </summary>    
    
    // 노드가 제일 중요함
    class MyLinkedListNode<T>
    {
        public T Data;
        // 다음 방으로 빠르게 이동하기 위한 문법 참조를 넘긴다.
        public MyLinkedListNode<T> Next; // 본체가 있는 게 아니라 방을 가리키는 주소값만 들고 있음
        public MyLinkedListNode<T> Prev; // 노드의 개념임
    }
    class MyLinkedList<T> // 예약한  방 리스트
    {
        // 첫번째 방과 마지막 방은 항상 실시간으로 정보가 유효해야 됨.
        public MyLinkedListNode<T> Head = null; // 첫번째 방
        public MyLinkedListNode<T> Tail = null; // 마지막 방
        public int Count = 0;

        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            // 만약 아직 방이 아예 업었다면, 새로 추가한 첫번째 방이 곧 head 이다.
            if (Head == null)
                Head = newRoom;
            
            // 기존의 [마지막 방]과 [새로 추가되는 방]을 연결해준다
            // 101 102 103 104
            if (Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }

            // [새로 추가되는 방]을 [마지막 방]으로 인정한다.
            Tail = newRoom;
            Count++;
            return newRoom;
        }
        // 101 102 103 104 105
        public void Remove(MyLinkedListNode<T> room)
        {
            // [기존의 첫번째 방의 다음 방]을 [첫번째 방]으로 인정한다.
            if (Head == room)
                Head = Head.Next;

            // [기존의 마지막 방의 이전 방]을 [마지막 방]으로 인정한다.
            if (Tail == room)
                Tail = Tail.Prev;

            if (room.Prev != null)
                room.Prev.Next = room.Next;

            if (room.Next != null)
                room.Next.Prev = room.Prev;

            Count--;
        }
    }

    class Board
    {
        public int[] _data = new int[25]; // 배열
        public MyLinkedList<int> _data3 = new MyLinkedList<int>();// 연결리스트

        public void Initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);
            // 결론 LinkedListNode 는 방 자체고 LinkedList 는 방 리스트 (목록) 이다
        }
    }
}
