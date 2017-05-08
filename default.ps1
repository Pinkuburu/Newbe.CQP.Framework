Framework "4.6"
Properties{
    $hostNow = $false
}
Task Default -depends DocFx
Task InstallDocFx {
    cinst docfx -y
}

Task Clean {
    Remove-Item "docfx_project\src" -Force -Recurse -ErrorAction SilentlyContinue
}

Task CopySrc -depends Clean{
    Copy-Item "Newbe.CQP.Framework" "docfx_project\src" -Recurse -Force  
}

Task DocFx -depends CopySrc{
    docfx "docfx_project\docfx.json"
    if($hostNow){
        docfx serve "docfx_project\_site"
    }
    Remove-Item "docfx_project\src" -Force -Recurse 
    Remove-Item apidoc -Force -Recurse -ErrorAction SilentlyContinue
    Copy-Item "docfx_project\_site" apidoc -Recurse -Force
}