import Addressbook.Person

object Main {
  def main(args: Array[String]): Unit = {
    println("hello world :)")
    val person = Person.newBuilder()
      .setId(1234)
      .setName("Ofek hod")
      .setEmail("ofekhod@gmail.com")
      .addPhones(
        Person.PhoneNumber.newBuilder()
          .setNumber("555-4321")
          .setType(Person.PhoneType.HOME))
      .build()

    val bytes = person.toByteArray()
    val parsedPerson = Person.parseFrom(bytes)
    println("finished :)")
  }
}
