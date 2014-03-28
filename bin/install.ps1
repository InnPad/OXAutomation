$packageName = "OXAutomation"
$serviceName = $packageName

try { #error handling is only necessary if you need to do anything in addition to/instead of the main helpers
    $scriptPath = Split-Path $myInvocation.MyCommand.Path
    $installPath = Split-Path $myInvocation.MyCommand.Path
    $existingService = Get-WmiObject -Class Win32_Service -Filter "Name='$serviceName'"
    
    #if ($existingService)
    #{
    #    $PSCmdlet.ThrowTerminatingError("Service exists. Uninstall first.")
    #}
    
    # Install service
    Write-Output "Installing service $packageName from $installPath.." | Out-Null
    
    $exePath = "$installPath\OXAutomationService.exe"
    
    # Log as system service
    New-Service -BinaryPathName $exePath -Name $serviceName -DisplayName $serviceName -StartupType Automatic
    
    Write-Output "Starting service..."  | Out-Null
    
    "Waiting 5 seconds to allow service to be started."
    Start-Sleep -s 5  
    
    Start-Service $serviceName
    #}
} catch {
    throw 
}