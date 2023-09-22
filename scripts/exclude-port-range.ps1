Write-Host "netsh interface ipv4 show excludedportrange protocol=tcp"
netsh interface ipv4 show excludedportrange protocol=tcp
$array = 1521,3306,5380,5432,5433,5672,6379,9000,9090,9200,9300,9411,15672,27017,50000
foreach ($item in $array)
{
    Write-Host "netsh int ipv4 add excludedportrange protocol=tcp startport=$item numberofports=1 store=persistent"
    netsh int ipv4 add excludedportrange protocol=tcp startport=$item numberofports=1 store=persistent
}
Write-Host "netsh int ipv4 add excludedportrange protocol=tcp startport=30100 numberofports=100 store=persistent"
netsh int ipv4 add excludedportrange protocol=tcp startport=30100 numberofports=100 store=persistent
Write-Host "netsh interface ipv4 show excludedportrange protocol=tcp"
netsh interface ipv4 show excludedportrange protocol=tcp