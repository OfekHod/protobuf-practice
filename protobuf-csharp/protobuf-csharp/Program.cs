using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Google.Protobuf;

// from protobuf-scala-to-csharp folder
//protoc --csharp_out=protobuf-csharp\protobuf-csharp addressbook.proto

namespace protobuf_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World :)");

            Person john = new Person
            {
                Id = 1234,
                Name = "John Doe",
                Email = "jdoe@example.com",
                Phones = { new Person.Types.PhoneNumber { Number = "555-4321", Type = Person.Types.PhoneType.HOME } }
            };

            using (var output = File.Create("john.dat"))
            {
                john.WriteTo(output);
            }

            Person john2;

            using (var input = File.OpenRead("john.dat"))
            {
                john2 = Person.Parser.ParseFrom(input);
            }

            System.Console.WriteLine("Holy moly it's working!");
        }
    }
}
