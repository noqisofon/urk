@echo off

set msbuild_version=14.0

set msbuild="C:\Program Files (x86)\MSBuild\%msbuild_version%\Bin\MSBuild.exe"

%msbuild% /nologo /t:rebuild /m /v:normal /flp:Summary;Verbosity=normal;LogFile=rebuild.log;Encoding=UTF-8
