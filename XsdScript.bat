@ECHO off
::SET /p SourceFile= Please enter dll source file location: 
::SET /p DestinationPath= Please enter XSD files destination or Leave it blank to use the current directory: 
::SET /p XsdFileName= Please enter XSD file name or Leave it blank to use default name: 

::IF "%DestinationPath%" == "" SET DestinationPath=%CD%

SET DestinationPath=%CD%
SET SourceFile=%1
SET XsdFileName=%2

IF "%SourceFile%" == "" SET SourceFile=%CD%
ECHO ...................................................
ECHO .          	Start Processing                  .
ECHO ...................................................

START /B /LOW /WAIT "" "C:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools\x64\xsd.exe" %SourceFile% /outputdir:%DestinationPath%

ECHO ...................................................
ECHO .          	     Result                 	  .
ECHO ...................................................
IF %ERRORLEVEL% NEQ 0 GOTO fail
GOTO end

:fail
ECHO XSD generation failed!
ECHO ...................................................
PAUSE
EXIT /B 1

:end
IF NOT "%XsdFileName%" == "" REN "%DestinationPath%\schema0.xsd" "%XsdFileName%.xsd"
ECHO XSD generation succeeded! Your XSD files are in %DestinationPath%.
ECHO ...................................................
PAUSE
EXIT /B 0