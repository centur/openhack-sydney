param(
	[string]
	$CustomerId=$env:WorkspaceId,
	[string]
	$SharedKey=$env:OmsSecret,
	[string]
	$Ip=$env:ServerIp,
	[string]
	$Port=$env:ServerPort,
	[string]
	$Message=$env:Message
)

Write-Host "Using variables: $customerId, $SharedKey, $Ip, $Port"

# Specify the name of the record type that you'll be creating
$LogType = "MinecraftMonitoring"

# Specify a field with the created time for the records
$TimeStampField = get-date -Format FileDateTimeUniversal

$r = irm "https://mcapi.us/server/status?ip=$Ip&port=$Port"
$max = $r.players.max
$now = $r.players.now

# Create two records with the same set of properties to create
$json = @"
[{  "Name": "Player count",
    "Now": $now,
    "Max": $max,
    "Message" : "Message: $Message",
    "DateValue": "$TimeStampField",
}]
"@

# Create the function to create the authorization signature
Function Build-Signature ($customerId, $sharedKey, $date, $contentLength, $method, $contentType, $resource)
{
    $xHeaders = "x-ms-date:" + $date
    $stringToHash = $method + "`n" + $contentLength + "`n" + $contentType + "`n" + $xHeaders + "`n" + $resource

    $bytesToHash = [Text.Encoding]::UTF8.GetBytes($stringToHash)
    $keyBytes = [Convert]::FromBase64String($sharedKey)

    $sha256 = New-Object System.Security.Cryptography.HMACSHA256
    $sha256.Key = $keyBytes
    $calculatedHash = $sha256.ComputeHash($bytesToHash)
    $encodedHash = [Convert]::ToBase64String($calculatedHash)
    $authorization = 'SharedKey {0}:{1}' -f $customerId,$encodedHash
    return $authorization
}


# Create the function to create and post the request
Function Post-LogAnalyticsData($customerId, $sharedKey, $body, $logType)
{
    $method = "POST"
    $contentType = "application/json"
    $resource = "/api/logs"
    $rfc1123date = [DateTime]::UtcNow.ToString("r")
    $contentLength = $body.Length
    $signature = Build-Signature `
        -customerId $customerId `
        -sharedKey $sharedKey `
        -date $rfc1123date `
        -contentLength $contentLength `
        -fileName $fileName `
        -method $method `
        -contentType $contentType `
        -resource $resource
    $uri = "https://" + $customerId + ".ods.opinsights.azure.com" + $resource + "?api-version=2016-04-01"

    $headers = @{
        "Authorization" = $signature;
        "Log-Type" = $logType;
        "x-ms-date" = $rfc1123date;
        "time-generated-field" = $TimeStampField;
    }

    $response = Invoke-WebRequest -Uri $uri -Method $method -ContentType $contentType -Headers $headers -Body $body -UseBasicParsing
    return $response.StatusCode

}

Write-Host "JSON request: " + $json

while ($true) {
	# Submit the data to the API endpoint
	Post-LogAnalyticsData -customerId $customerId `
		-sharedKey $sharedKey `
		-body ([System.Text.Encoding]::UTF8.GetBytes($json)) `
		-logType $logType
	sleep 60
}
