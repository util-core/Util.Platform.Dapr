try{
    rimraf 2>$null
}
catch{
    Write-Host "install rimraf..."
    npm install -g rimraf 
}

$projects = '../src/Web/Main/ClientApp','../src/Web/Identity/ClientApp'
foreach ($project in $projects)
{
    Write-Host "$project : remove ..."
    rimraf $project/node_modules
    rimraf $project/.angular
    rimraf $project/dist
    rimraf $project/yarn.lock    
    rimraf $project/.nx
}

Write-Host "remove completed."