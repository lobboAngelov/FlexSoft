$protoExetDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$commonProtoDir = Join-Path -Path $protoExetDir -ChildPath Protobuf.NET

.\protoc.exe $protoExetDir\SeverSocketMessages.proto --proto_path=$protoExetDir --csharp_out=$commonProtoDir
.\protoc.exe $protoExetDir\ClientSocketMessages.proto --proto_path=$protoExetDir --csharp_out=$commonProtoDir

Write-Host "Press any key to continue ..."

$x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")