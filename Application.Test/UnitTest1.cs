using System;
using System.Collections.Generic;
using System.Diagnostics;
using Bogus;
using Xunit;

namespace Application.Test
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            System.Console.WriteLine("���캯��");
        }
        [Theory]
        //[InlineData]
        [MemberData(nameof(Testa.TestData), MemberType = typeof(Testa))]
        public void MyFirstTheory(TestDto testDto)
        {
            Console.WriteLine("Console.WriteLine ���");
            Trace.WriteLine("Trace.WriteLine ���");
            Debug.Print("Debug.Print ���");
            Debug.WriteLine("Debug.WriteLine ���");

        }

        [Fact]
        public void Tt()
        {
            System.Console.WriteLine("����һ��");
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }
    }

    public class Testa
    {
        public static IEnumerable<object[]> TestData()
        {
            var datas = new Faker<TestDto>()
                .RuleFor(x => x.Age, x => x.Random.Int(20,30))
                .Generate(10);
            foreach (var item in datas)
            {
                yield return new object[] { item };
            }
        }
    }

    public class TestDto
    {
        public int Age { get; set; }
    }
}
