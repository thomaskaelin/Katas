using System.IO;
using Google.Protobuf;
using KataProtobuf.Generated;

namespace KataProtobuf
{
    public class AddressbookClient
    {
        public byte[] Serialize(AddressBook addressBook)
        {
            return addressBook.ToByteArray();
        }

        public AddressBook Deserialize(byte[] serializedAddressbook)
        {

            return AddressBook.Parser.ParseFrom(serializedAddressbook);
        }
    }
}