set PROTOC = "C:\Users\loanaalbisser\Desktop\protoc.exe"
set inputPath = "C:\Users\loanaalbisser\Documents\Projects\YP_Katas\KataProtobuf"
set outputPath = "C:\Users\loanaalbisser\Documents\Projects\YP_Katas\KataProtobuf\KataProtobuf\Generated"
set protoFile = %inputPath%"\addressbook.proto"
%PROTOC% -I=%inputPath% --csharp_out=%outputPath% %protoFile%