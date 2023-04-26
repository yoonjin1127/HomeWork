
namespace _0426HashTable
{
    internal class Program
    {
        void Dictionary()       // 딕셔너리 함수 정의
        {
            // 문자열 키와 문자열 값을 저장하는 제네릭 클래스 Dictionary 생성
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("facebook", "페북");
            dictionary.Add("instagram", "인스타");
            dictionary.Add("kakaotalk", "카톡");

            // 키 값은 인덱서를 통해 접근
            Console.WriteLine(dictionary["facebook"]);
            Console.WriteLine(dictionary["instagram"]);

            // ContainsKey는 지정한 키의 유무를 테스트함
            if (dictionary.ContainsKey("instagram"))
                Console.WriteLine("instagram 키 값의 데이터가 있음");    // 키가 있는 경우, 있다고 출력
            else
                Console.WriteLine("instagram 키 값의 데이터가 없음");    // 없으면 없다고 출력

            // Remove는 지정한 키를 삭제함
            if (dictionary.Remove("instagram"))
                Console.WriteLine("instagram 키 값에 해당하는 데이터를 지움");   // 키를 제거할 수 있는 경우, 제거함
            else                 
                Console.WriteLine("instagram 키 값에 해당하는 데이터를 못 지움"); // 키를 제거할 수 없는 경우, 제거하지 않음

            // 결과 변수 정의
            string output;
            // TryGetValue와 out 키워드를 이용해 키의 값을 가져올 수 잇음
            if (dictionary.TryGetValue("kakaotalk", out output))
                Console.WriteLine(output);
            else
                Console.WriteLine("kakaotalk 키 값의 데이터가 없음");
        }

        static void Main(string[] args)
        {
            DataStructure.Dictionary<string, string> Dictionary = new DataStructure.Dictionary<string, string>();

            Dictionary.Add("facebook", "페북");
            Dictionary.Add("instagram", "인스타");
            Dictionary.Add("kakaotalk", "카톡");

            Console.WriteLine(Dictionary["facebook"]);       // 키값은 인덱서를 통해 접근

            if (Dictionary.ContainsKey("kakaotalk"))
                Console.WriteLine("kakaotalk 키 값의 데이터가 있음");
            else
                Console.WriteLine("kakaotalk 키 값의 데이터가 없음");

            if (Dictionary.Remove("kakaotalk"))
                Console.WriteLine("kakaotalk 키 값에 해당하는 데이터를 지움");
            else
                Console.WriteLine("kakaotalk 키 값에 해당하는 데이터를 못지움");

            if (Dictionary.ContainsKey("kakaotalk"))
                Console.WriteLine("kakaotalk 키 값의 데이터가 있음");
            else
                Console.WriteLine("kakaotalk 키 값의 데이터가 없음");

            string output;
            if (Dictionary.TryGetValue("instagram", out output))
                Console.WriteLine(output);
            else
                Console.WriteLine("instagram 키 값의 데이터가 없음");
        }
    }
}