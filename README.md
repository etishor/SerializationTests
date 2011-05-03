## Serialization Tests

Collection of object serialization tests using various serialization libraries.

### Scope

The scope of this project is to provide an overview of what each serialization library has to offer and to 
define some guidelines for creating serializable objects ( messages, commands, events ).

### Running the tests

To run the tests you should install [Gallio](http://www.gallio.org/Downloads.aspx) and use the GUI Icarus test runner to see the results.
You can also take a look at [Gallio Test Report](http://dl.dropbox.com/u/20001252/SerializationTests/Gallio%20Test%20Report.htm)

### Serialization Libraries Used
* [BinaryFormatter](http://msdn.microsoft.com/en-us/library/system.runtime.serialization.formatters.binary.binaryformatter.aspx)
* [DataContractSerializer](http://msdn.microsoft.com/en-us/library/system.runtime.serialization.datacontractserializer.aspx)
* [NetDataContractSerializer](http://msdn.microsoft.com/en-us/library/system.runtime.serialization.netdatacontractserializer.aspx)
* [Newtonsoft Json.Net](http://json.codeplex.com/)
* [NServiceBus BinarySerialize](https://github.com/NServiceBus/NServiceBus)
* [NServiceBus XMLSerialize](https://github.com/NServiceBus/NServiceBus)
* [ProtocolBufers.NET Serializer](http://code.google.com/p/protobuf-net/)
* [ServiceStack JsonSerializer](https://github.com/ServiceStack/ServiceStack.Text)
* [SoapFormatter](http://msdn.microsoft.com/en-us/library/system.runtime.serialization.formatters.soap.soapformatter.aspx)
* [XmlSerializer](http://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer.aspx)
* [Raven.Json](https://github.com/ravendb/Raven.Json)

### Conclusion

You can read my conclusions at [.NET Serialization Choices](http://www.erata.net/net/net-serialization-choices/)