while ($true) {
    $r = irm "https://mcapi.us/server/status?ip=$env:ip&port=25565"
    $r.players.max
    start-sleep -Seconds 10
}