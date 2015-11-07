<?php

     $servername = "mysql.hostinger.in.th";
     $username = "u804444278_admin";
     $password = "1212312121";

try {
    $conn = new PDO("mysql:host=$servername;dbname=u804444278_ktt", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    echo "Connected successfully KTT GAME";
    }
catch(PDOException $e)
    {
    echo "Connection failed: " . $e->getMessage();
    }

   $conn = null;
?>	