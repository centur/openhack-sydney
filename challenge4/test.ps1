param(
	[string] $Method = "get",
	[string] $Value
)

$Url = "http://13.72.225.211/api/service"

if ($Method -eq "get")
{
	Invoke-RestMethod -Uri $Url -Method Get
}
elseif ($Method -eq "post")
{
	Invoke-RestMethod -Uri $Url -Method Post
}
elseif ($Method -eq "delete")
{
	Invoke-RestMethod -Uri $Url -Method Delete
} elseif ($Method -eq "other")
{
}
