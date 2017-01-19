@set stagingDir=stagingDir\

md %stagingDir%

copy Release\packageProduct.exe             %stagingDir%

copy ..\README.md                           %stagingDir%
copy ..\LICENSE                             %stagingDir%

packageProduct.exe %stagingDir%\packageProduct.exe

rmdir /S /Q %stagingDir%
Timeout /t10
