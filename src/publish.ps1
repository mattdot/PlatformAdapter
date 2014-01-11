$outdir = [guid]::NewGuid().ToString("N")
New-Item -ItemType directory -Path "..\deploy\$outdir"
nuget pack PlatformAdapter\PlatformAdapter.csproj -Build -Prop Configuration=Release -OutputDirectory "..\deploy\$outdir" -Symbols

#push the nuget package to nuget
gci "..\deploy\$outdir\*.nupkg" | where { $_.Name  -Match '(?<!.symbols).nupkg$' } | % { nuget push $_.FullName }

#push the symbols to symbol store
gci "..\deploy\$outdir\*.symbols.nupkg" | % { nuget push $_.FullName }
