$packageName = "OXAutomation"
$serviceName = $packageName

try {

    $existingService = Get-WmiObject -Class Win32_Service -Filter "Name='$serviceName'"
    
    if ($existingService) 
    {
        # Stop service
        Write-Output "Stopping service..."  | Out-Null
        Stop-Service $serviceName
        
        "Waiting 3 seconds to allow existing service to stop."
        Start-Sleep -s 3
        
        # Uninstall service
        Write-Output "Uninstalling service..."  | Out-Null
        
        $existingService.Delete()
        
        "Waiting 5 seconds to allow service to be uninstalled."
        Start-Sleep -s 5  
    }
    
    # Error handling
    Write-ChocolateySuccess $packageName
} catch {
    Write-ChocolateyFailure $packageName "$($_.Exception.Message)"
    #throw 
}