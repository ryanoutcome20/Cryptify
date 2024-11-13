@echo off
setlocal

:: Set the MSBuild path
set MSBUILD_PATH="C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe"

:: Set the path to your .csproj file
set PROJECT_PATH="src\Cryptify.csproj"

:: Build the project
echo Building the WinForms project...
%MSBUILD_PATH% %PROJECT_PATH% /p:Configuration=Release /p:TargetFrameworkVersion=v4.7.2

:: Check for errors
if %errorlevel% neq 0 (
    echo Build failed! Press any key to exit...
    pause
    exit /b %errorlevel%
)

echo Build succeeded! Press any key to exit...
pause
