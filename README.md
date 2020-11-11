# Create runnable

dotnet publish --configuration Release --self-contained  -r win-x64 -p:PublishReadyToRun=true -p:PublishSingleFile=true
