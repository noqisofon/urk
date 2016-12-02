@echo off

set msbuild_version=14.0

set msbuild="C:\Program Files (x86)\MSBuild\%msbuild_version%\Bin\MSBuild.exe"

%msbuild% /nologo /t:build /m /v:minimal /flp:Verbosity=normal;LogFile=build.log;Encoding=UTF-8
