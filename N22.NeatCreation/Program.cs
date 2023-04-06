// Jiří Činčura님의 다음의 글을 분석하는 코드 입니다.
// https://www.tabsoverspaces.com/233907-my-csharp-array-tuple-delegate-declaration-dilemma?utm_source=feed


// 일반적으로 우리는 C#에서 다음 처럼 배열을 초기화 합니다.
// 원소의 타입이 모두 동일하다고 예측할 수 있으므로 `new int[]` 대신 `new[]`로 배열을 초기화 할 수 있습니다.
var data = new[] { 1, 2, 3 };

// 그런데 다음 처럼도 됩니다. C# 개발자 중 아는 사람만 안다는 그 코드입니다.
// 어떤 면에서는 위의 코드보다 좋습니다. int형의 배열(int[])이라고 명확히 알 수 있으며, 이후 배열 요소의 나열은 더이상 간단할 수 없습니다.
int[] data2 = { 1, 2, 3 };

// 그런데 동일한 시각으로 다음의 코드가 컴파일 되지 않는 것은 아쉽습니다.
// 
void Foo(int[] data) { }
// Foo({ 1, 2, 3 }); // 이 코드는 컴파일 오류가 발생합니다.
Foo(new[] { 1, 2, 3 });
Foo(new int[] { 1, 2, 3 });

// 하지만 다음의 코드를 살펴봅시다. 대리자로 특정한 규칙으로 실행 집합을 만들면 유용한 경우가 있습니다.

float Bar(float x) => x; // 이런 함수 언어 스타일의 표현은 익숙해지면 매력적입니다.

// 암시적으로는 컴파일 오류가 발생합니다.
//(string Key, Func<float, float> Func)[] FuncList = new[]
//{
//    ("test", Bar),
//};

// 다음처럼 명시적으로 표현해야 합니다.
(string Key, Func<float, float> Func)[] FuncList2 = new (string, Func<float, float>)[]
{
    ("test", Bar),
};

// 그런데 `int[] data2 = { 1, 2, 3 }` 처럼 다음과 같이 표현이 가능합니다.
// 매력적이군요!
(string Key, Func<float, float> Func)[] FuncList3 =
{
    ("test", Bar),
};

// C#으로 오랫동안 코딩한 입장에서는 `new[]`를 생략할 수 있다는 점이 매력적이면서 이상합니다. 이 축약으로 인해 배열은 어느 메모리에 생성되는것일까요? 당연히 표현의 차이일 뿐이므로 여전히 힙 메모리입니다.
// 한편 struct도 new로 생성할 수 있으므로 이점은 모호한 점인것은 맞습니다.
var p1 = new Point(5, 10);
Point p2 = new(5, 10);
// Point p3 = (5, 10); // ??!? 암시적 변환 연산자를 구현하면 이렇게도 사용은 가능합니다.

// 한편 스택 메모리에서 배열을 생성하는 방법은 무엇일까요? 가능은 하지만 제한적입니다.
Span<int> numbers = stackalloc int[] { 1, 2, 3 };
Span<int> numbers2 = stackalloc[] { 1, 2, 3 };
// Span<int> numbers3 = { 1, 2, 3 }; // 이건 또 안되는군요...


readonly record struct Point(int X, int Y);

