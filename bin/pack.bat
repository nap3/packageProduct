del Release\packageProduct.exe.config
del Release\packageProduct.vshost.exe
del Release\packageProduct.vshost.exe.config
del Release\packageProduct.vshost.exe.manifest

packageProduct.exe Release\packageProduct.exe
Timeout /t10
