<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <title></title>
    <link rel="stylesheet" href="styles/reset.css">
    <link rel="stylesheet" href="styles/styles.css">
    
  </head>

  <?php
    $content=file_get_contents("http://localhost/sdv701project/Server/selectallnations");
    $data=json_decode($content, true);

    $NationsArray = array();

    foreach ($data as $value) {
      array_push($NationsArray, $value);
    }
    $_SESSION["NationsArray"] = $NationsArray;
    //print_r($Nations);
  ?>

  <body class="centered-wrapper">
    <div class="centered-content">
      <h1>Warships.net</h1>
