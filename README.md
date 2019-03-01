# amagram
anagram app for Helmes coding challenge

This is a .net core 2 app. It's binary was built with linux-x64 runtime identifier. It should be enough for most linux distributions. 

To run the app, go to ```bin\Release\netcoreapp2.1\linux-x64\publish``` directory and run ```AnagramApp``` binary with text file and an input string for params.

If you want to build it for some other runtime, you can use the following command

```sh dotnet publish -c release  --runtime RUNTIME ID ```

Runtime ids are found here [here](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog) 
