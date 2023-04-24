using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure     // 네임스페이스를 DataStructure (자료구조)로 변경
{
    /*******
     * 어댑터 패턴 (Adapter)
     * 
     * 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환
     ********/

    internal class AdapterStack<T>      // 클래스명을 어댑터 스택으로 변경
    {
        private List<T> container;
    }
}
