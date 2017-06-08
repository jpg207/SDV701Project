<?php include 'includes/head.php';?>

<?php
  $data = array(
    'UserName' => $_POST["UserName"],
    'Email' => $_POST["Email"],
    'Quantity' => $_POST["Quantity"],
    'ShipID' => $_POST["ShipID"]
  );

  $url = "http://localhost/sdv701project/Server/AddOrder";
  $content = json_encode($data);

  $curl = curl_init($url);
  curl_setopt($curl, CURLOPT_HEADER, false);
  curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
  curl_setopt($curl, CURLOPT_HTTPHEADER, array("Content-type: application/json"));
  curl_setopt($curl, CURLOPT_POST, true);
  curl_setopt($curl, CURLOPT_POSTFIELDS, $content);

  $json_response = curl_exec($curl);

  $status = curl_getinfo($curl, CURLINFO_HTTP_CODE);

  if ( $status != 200 ) {
    echo '
      <h2>Order Failiure please try again</h2>
      ';
      die("Error: call to URL $url failed with status $status, response $json_response, curl_error " . curl_error($curl) . ", curl_errno " . curl_errno($curl));
  }else {
    echo '
      <h2>Your order has been submited</h2>
        <p>Name:</p>
        <p>' . $_POST['UserName'] . '</p>
        <br />
        <p>Email:</p>
        <p>' . $_POST['Email'] . '</p>
        <br />
        <p>Ship Name:</p>
        <p>' . $_POST['ShipName'] . '</p>
        <br />
        <p>Quantity:</p>
        <p>' . $_POST['Quantity'] . '</p>
      ';
  }
  echo'
    <a href="ship.php" class="buttonback"><p>Back</p></a>
  ';

  curl_close($curl);

  $response = json_decode($json_response, true);
?>
<?php include 'includes/foot.php';?>
